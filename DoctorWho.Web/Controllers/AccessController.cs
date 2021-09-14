using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Access;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Access;
using DoctorWho.Web.Locators;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/InformationRequest")]
    public class AccessController : DoctorWhoController<AccessRequest,string,AccessRequestDbContext>
    {
        private readonly AccessManager _accessManager;
        public AccessController(EFRepository<AccessRequest, string,AccessRequestDbContext> repository, IMapper mapper,
            ILocatorTranslator<AccessRequest, string> locatorTranslator, AccessManager accessManager) : base(repository,
            mapper, locatorTranslator)
        {
            _accessManager = accessManager;
        }
        
        [HttpGet]
        [Route("",Name = "GetRequestsForUser")]
        public ActionResult<IEnumerable<AccessRequestDto>> GetAllRequestsForAUser([FromQuery]string userId,[FromQuery(Name = "Access")]AccessLevel accessLevel)
        {
            if (!_accessManager.HasRequestsForLevel(userId,accessLevel))
            {
                return NotFound();
            }
         
            var requests = _accessManager.GetRequestsWithLevel(userId, accessLevel).ToList();
            var output = GetRepresentation<IEnumerable<AccessRequest>, IEnumerable<AccessRequestDto>>(requests);

            return Ok(output);
        }
        
        [HttpPost]
        public ActionResult<AccessRequestDto> CreateRequest(AccessForCreationRequestDto input)
        {
            AddAndCommit(input);

            var requestsForTheUser = _accessManager.GetRequestsWithLevel(input.UserId, input.AccessLevel);
            
            var output = GetRepresentation<IEnumerable<AccessRequest>, IEnumerable<AccessRequestDto>>(requestsForTheUser);
            
            return CreatedAtRoute("GetRequestsForUser", new
            {
            }, output);
        }
    }
}