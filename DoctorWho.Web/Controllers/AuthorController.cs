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
    [Route("api/authors")]
    public class AuthorController : DoctorWhoController<Author, string>
    {
        private readonly AccessManager _accessManager;

        public AuthorController(IRepository<Author, string> repository, IMapper mapper,
            ILocatorTranslator<Author, string> locatorTranslator, AccessManager accessManager) : base(repository,
            mapper, locatorTranslator)
        {
            _accessManager = accessManager;
        }

        [HttpPut]
        [Route("{authorName}")]
        public ActionResult<AuthorDto> UpdateAuthor(string authorName,AuthorForUpdate input)
        {
            string userId = GetUserId();
            
            if (!_accessManager.HasWritePrivileges(userId))
            {
                return RedirectToAction("GetAllRequestsForAUser","Access",new
                {
                    userId,
                    Access = AccessLevel.Unknown,
                });
            }
            
            if (!EntityExists(authorName))
            {
                return NotFound();
            }

            var authorEntity = GetEntity(authorName);

            UpdateAndCommit(userId, input, authorName);

            var authorDto = GetRepresentation<Author, AuthorDto>(authorEntity);
            
            return Ok(authorDto);
        }
        
    }
}