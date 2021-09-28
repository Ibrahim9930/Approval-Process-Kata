using System.Collections.Generic;
using System.Linq;
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
    public class AccessController : DoctorWhoController<AccessRequest, string, AccessRequestDbContext>
    {
        private readonly AccessManager _accessManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccessController(EFRepository<AccessRequest, string, AccessRequestDbContext> repository, IMapper mapper,
            ILocatorTranslator<AccessRequest, string> locatorTranslator, AccessManager accessManager, UserManager<IdentityUser> userManager) : base(repository,
            mapper, locatorTranslator)
        {
            _accessManager = accessManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Approver,Admin")]
        [HttpGet]
        public IActionResult GetRequestsWithId([FromQuery(Name = "Access")] AccessLevel accessLevel)
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
            
            if (User.IsInRole("Approver") || User.IsInRole("Admin"))
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
        public async Task<ActionResult<AccessRequestWithIdDto>> CreateRequest(AccessForCreationRequestDto input)
        {
            if (!await UserExists(input.UserId))
                return NotFound();
            
            AddAndCommit(input);

            var requestsForTheUser = _accessManager.GetRequestsForUser(input.UserId);

            var output =
                GetRepresentation<IEnumerable<AccessRequest>, IEnumerable<AccessRequestWithIdDto>>(requestsForTheUser);

            return CreatedAtRoute("GetRequestsForUser", new
            {
                input.UserId
            }, output);
        }

        private async Task<bool> UserExists(string userId)
        {
            return await _userManager.FindByNameAsync(userId) != null;
        }

        [Authorize(Roles = "Approver,Admin")]
        [HttpOptions]
        [Route("approve/{requestId:int}")]
        public IActionResult ApproveRequest(int requestId)
        {
            _accessManager.ApproveRequest(requestId);

            return Ok();
        }
    }
}