using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Authentication;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace DoctorWho.Web.Controllers
{
    
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private static int ExpirationDuration = 3;
        private readonly UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password)) return Unauthorized();

            var authClaims = await GetClaims(user);

            var authSigningKey = GetAuthSigningKey();

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddYears(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        private SymmetricSecurityKey GetAuthSigningKey()
        {
            return new (Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.Username);
            if (userExists != null)
                return BadRequest();

            var user = new IdentityUser()
            {
                UserName = registerDto.Username,
            };

            var registrationResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!registrationResult.Succeeded)
                return BadRequest();
            
            await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("registerWithRole")]
        public async Task<IActionResult> RegisterWithRole(RegisterWithRoleDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.Username);
            if (userExists != null)
                return BadRequest();

            var user = new IdentityUser()
            {
                UserName = registerDto.Username,
            };

            var registrationResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!registrationResult.Succeeded)
                return Unauthorized();

            await _userManager.AddToRoleAsync(user, registerDto.Role);

            return Ok();
        }

        private async Task<List<Claim>> GetClaims(IdentityUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            return authClaims;
        }
    }
}