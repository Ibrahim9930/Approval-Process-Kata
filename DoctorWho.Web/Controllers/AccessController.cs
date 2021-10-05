using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Access;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Access;
using DoctorWho.Web.Locators;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/InformationRequest")]
    public class AccessController : DoctorWhoController<AccessRequest, string>
    {
        private readonly AccessManager _accessManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccessController(IRepository<AccessRequest, string> repository, IMapper mapper,
            ILocatorTranslator<AccessRequest, string> locatorTranslator, AccessManager accessManager,
            UserManager<IdentityUser> userManager) : base(repository,
            mapper, locatorTranslator)
        {
            _accessManager = accessManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetRequests([FromQuery(Name = "Access")] AccessLevel accessLevel)
        {
            var requests = accessLevel == AccessLevel.Unknown
                ? _accessManager.GetRequests()
                : _accessManager.GetRequests(accessLevel);

            var output = GetRepresentation<IEnumerable<AccessRequest>, IEnumerable<AccessRequestWithIdDto>>(requests);

            return Ok(output);
        }

        [HttpGet]
        [Route("{userId}", Name = "GetRequestsForUser")]
        public async Task<IActionResult> GetAllRequestsForAUser(string userId,
            [FromQuery(Name = "Access")] AccessLevel accessLevel)
        {
            if (!await UserExists(userId))
                return NotFound();
            var requests =
                accessLevel == AccessLevel.Unknown
                    ? _accessManager.GetRequestsForUser(userId).ToList()
                    : _accessManager.GetRequestsForUser(userId, accessLevel).ToList();

            if (_accessManager.HasApprovePrivileges(userId) || User.IsInRole("Admin"))
            {
                var output =
                    GetRepresentation<IEnumerable<AccessRequest>, IEnumerable<AccessRequestWithIdDto>>(requests);

                return Ok(output);
            }
            else
            {
                var output = GetRepresentation<IEnumerable<AccessRequest>, IEnumerable<AccessRequestDto>>(requests);

                return Ok(output);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AccessRequestDto>> CreateRequest(AccessForCreationRequestDto input)
        {
            if (!await UserExists(input.UserId))
                return NotFound();

            string userId = GetUserId();
            AddAndCommit(userId, input);

            var requestsForTheUser = _accessManager.GetRequestsForUser(input.UserId);

            var output =
                GetRepresentation<IEnumerable<AccessRequest>, IEnumerable<AccessRequestDto>>(requestsForTheUser);

            return CreatedAtRoute("GetRequestsForUser", new
            {
                input.UserId
            }, output);
        }

        [HttpOptions]
        [Route("approve/{requestId:int}")]
        public IActionResult ApproveRequest(int requestId)
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            if (!_accessManager.HasApprovePrivileges(userId))
            {
                return Forbid();
            }

            if (!_accessManager.RequestExists(requestId))
                return NotFound();
            
            _accessManager.ApproveRequest(requestId);

            return Ok();
        }

        private async Task<bool> UserExists(string userId)
        {
            return await _userManager.FindByNameAsync(userId) != null;
        }
    }
}