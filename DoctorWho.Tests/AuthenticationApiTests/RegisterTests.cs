using System.Net;
using System.Threading.Tasks;
using DoctorWho.Db.Authentication;
using DoctorWho.Tests.Utils;
using DoctorWho.Web;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.AuthenticationApiTests
{
    public class RegisterTests : ApiTests<AuthDbContext>
    {
        public RegisterTests(InMemDbWebApplicationFactory<Startup, AuthDbContext> fixture) : base(fixture)
        {
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_Register_ValidDto_UsernameDoesNotExist_StatusCode_Should_200StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var registerDto = new RegisterDto()
            {
                Username = "new-user",
                Password = "password"
            };
            
            var response = await client.PostAsync("/api/auth/register",
                ResponseParser.GetResponseBody(registerDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_Register_ValidDto_UsernameExists_StatusCode_Should_400StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var registerDto = new RegisterDto()
            {
                Username = "testing-user",
                Password = "password"
            };
            
            var response = await client.PostAsync("/api/auth/register",
                ResponseParser.GetResponseBody(registerDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_Register_InvalidDto_StatusCode_Should_422StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var registerDto = new RegisterDto()
            {
                Username = "new-user",
            };
            
            var response = await client.PostAsync("/api/auth/register",
                ResponseParser.GetResponseBody(registerDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_RegisterWithRole_ValidDto_UsernameDoesNotExist_UserIsAdmin_StatusCode_Should_200StatusCode()
        {
            var client = GetAuthenticatedClient();
            
            var registerDto = new RegisterWithRoleDto()
            {
                Username = "new-user-with-role",
                Password = "password",
                Role = "Approver"
            };
            
            var response = await client.PostAsync("/api/auth/register",
                ResponseParser.GetResponseBody(registerDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_RegisterWithRole_ValidDto_UserIsNotAdmin_StatusCode_Should_401StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var registerDto = new RegisterWithRoleDto()
            {
                Username = "new-user-with-role",
                Password = "password",
                Role = "Approver"
            };
            
            var response = await client.PostAsync("/api/auth/registerWithRole",
                ResponseParser.GetResponseBody(registerDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_RegisterWithRole_InValidDto_UserIsAdmin_StatusCode_Should_422StatusCode()
        {
            var client = GetAuthenticatedClient();
            
            var registerDto = new RegisterWithRoleDto()
            {
                Username = "new-user",
                Password = "password",
            };
            
            var response = await client.PostAsync("/api/auth/registerWithRole",
                ResponseParser.GetResponseBody(registerDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}