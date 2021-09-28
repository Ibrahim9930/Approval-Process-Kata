using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Access;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Access;
using DoctorWho.Web.Locators;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : DoctorWhoController<Doctor, int?,DoctorWhoCoreDbContext>
    {
        private ILocatorTranslator<DoctorForCreationWithPostDto, int?> PostInputLocatorTranslator { get; }
        private AccessManager _accessManager;
        public DoctorController(EFRepository<Doctor, int?,DoctorWhoCoreDbContext> repository, IMapper mapper,
            ILocatorTranslator<Doctor, int?> locatorTranslator,
            ILocatorTranslator<DoctorForCreationWithPostDto, int?> postInputLocatorTranslator, AccessManager accessManager) : base(repository,
            mapper, locatorTranslator)
        {
            PostInputLocatorTranslator = postInputLocatorTranslator;
            _accessManager = accessManager;
        }


        [HttpGet]
        public IActionResult GetAllResources()
        {
            string userId = GetUserId();
            
            if (!_accessManager.HasReadPrivileges(userId))
            {
                var x = RedirectToAction("GetAllRequestsForAUser","Access",new
                {
                    userId,
                    Access = AccessLevel.Unknown,
                });
                
                return x;
            }
            
            
            var doctorEntities = Repository.GetAllEntities().ToArray();
            
            if (_accessManager.AccessIsRedacted(userId))
            {
                foreach (var doctor in doctorEntities)
                {
                    doctor.Redact();
                }
            }
            
            var output = GetRepresentation<IEnumerable<Doctor>, IEnumerable<DoctorDto>>(doctorEntities);

            return Ok(output);
        }
        
        [HttpGet]
        [Route("{doctorNumber}", Name = "GetDoctor")]
        public ActionResult<Doctor> GetResource(int? doctorNumber)
        {
            string userId = GetUserId();
            
            if (!_accessManager.HasReadPrivileges(userId))
            {
                return RedirectToAction("GetAllRequestsForAUser","Access",new
                {
                    userId,
                    Access = AccessLevel.Unknown,
                });
            }

            
            var doctorEntity = GetEntity(doctorNumber);

            if (doctorEntity == null)
                return NotFound();

                      
            if (_accessManager.AccessIsRedacted(userId))
            {
                doctorEntity.Redact();
            }
            
            var output = GetRepresentation<Doctor, DoctorDto>(doctorEntity);

            return Ok(output);
        }

        [HttpPost]
        public ActionResult<DoctorDto> CreateDoctor(DoctorForCreationWithPostDto input)
        {
            if (EntityExists(PostInputLocatorTranslator.GetLocator(input)))
            {
                return Conflict();
            }

            AddAndCommit(input);

            return CreatedAtRoute("GetDoctor", new {doctorNumber = PostInputLocatorTranslator.GetLocator(input)},
                GetResource(PostInputLocatorTranslator.GetLocator(input)));
        }

        [HttpPut]
        [Route("{doctorNumber}")]
        public ActionResult<DoctorDto> UpsertDoctor([FromRoute] int? doctorNumber,
            [FromBody] DoctorForUpsertWithPut input)
        {
            if (EntityExists(doctorNumber))
            {
                UpdateAndCommit(input, doctorNumber);

                var doctorDto = GetRepresentation<Doctor, DoctorDto>(GetEntity(doctorNumber));
                
                return Ok(doctorDto);
            }

            AddAndCommit(input, doctorNumber);

            return CreatedAtRoute("GetDoctor", new {doctorNumber},
                GetResource(doctorNumber));
        }

        [HttpDelete]
        [Route("{doctorNumber}")]
        public ActionResult DeleteResource(int? doctorNumber)
        {
            if (!EntityExists(doctorNumber))
                return NotFound();

            var doctorEntity = GetEntity(doctorNumber);

            DeleteAndCommit(doctorEntity);

            return NoContent();
        }
        
    }
}