using System.Collections.Generic;
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
    [Route("api/episodes")]
    public class EpisodeController : DoctorWhoController<Episode, string,DoctorWhoCoreDbContext>
    {
        private ILocatorTranslator<EpisodeForCreationWithPostDto, string> PostInputLocatorTranslator { get; }

        private EpisodeEfRepository<string> EpisodeRepository => (EpisodeEfRepository<string>) Repository;
        private readonly AccessManager _accessManager;
        public EpisodeController(EFRepository<Episode, string,DoctorWhoCoreDbContext> repository, IMapper mapper,
            ILocatorTranslator<Episode, string> locatorTranslator,
            ILocatorTranslator<EpisodeForCreationWithPostDto, string> postInputLocatorTranslator, AccessManager accessManager) : base(
            repository,
            mapper,
            locatorTranslator)
        {
            PostInputLocatorTranslator = postInputLocatorTranslator;
            _accessManager = accessManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Episode>> GetAllResources()
        {
            var userId = GetUserId();
            
            if (!_accessManager.HasReadPrivileges(userId))
            {
                return RedirectToAction("GetAllRequestsForAUser","Access",new
                {
                    userId,
                    Access = AccessLevel.Unknown,
                });
            }
            
            var episodeEntities = Repository.GetAllEntities();

            if (_accessManager.AccessIsRedacted(userId))
            {
                foreach (var episode in episodeEntities)
                {
                    episode.Redact();
                }
            }
            
            var output = GetRepresentation<IEnumerable<Episode>, IEnumerable<EpisodeDto>>(episodeEntities);

            return Ok(output);
        }

        [HttpGet]
        [Route("{episodeLocator}", Name = "GetEpisode")]
        public ActionResult<Episode> GetResource(string episodeLocator)
        {
            var userId = GetUserId();
            
            if (!_accessManager.HasReadPrivileges(userId))
            {
                return RedirectToAction("GetAllRequestsForAUser","Access",new
                {
                    userId,
                    Access = AccessLevel.Unknown,
                });
            }
            
            var episodeEntity = GetEntity(episodeLocator);

            if (episodeEntity == null)
                return NotFound();
            
            if (_accessManager.AccessIsRedacted(userId))
            {
                episodeEntity.Redact();
            }
            
            var output = GetRepresentation<Episode, EpisodeDto>(episodeEntity);
            return Ok(output);
        }

        [HttpPost]
        public ActionResult<EpisodeDto> CreateEpisode(EpisodeForCreationWithPostDto input)
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
            
            if (EntityExists(PostInputLocatorTranslator.GetLocator(input)))
            {
                return Conflict();
            }

            AddAndCommit(input);

            return CreatedAtRoute("GetEpisode", new {episodeLocator = PostInputLocatorTranslator.GetLocator(input)},
                GetResource(PostInputLocatorTranslator.GetLocator(input)));
        }

        [HttpOptions]
        [Route("{episodeLocator}/addCompanion")]
        public ActionResult AddCompanionToEpisode(string episodeLocator,
            CompanionForCreationDto companionForCreation)
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
            
            Companion companion = GetRepresentation<CompanionForCreationDto, Companion>(companionForCreation);

            if (!EntityExists(episodeLocator))
                return NotFound();

            Episode episodeEntity = GetEntity(episodeLocator);

            EpisodeRepository.AddCompanion(episodeEntity, companion);
            EpisodeRepository.Commit();

            return Ok();
        }
        
        [HttpOptions]
        [Route("{episodeLocator}/addEnemy")]
        public ActionResult AddEnemyToEpisode(string episodeLocator,
            EnemyForCreationDto enemyForCreation)
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
            
            Enemy enemy = GetRepresentation<EnemyForCreationDto, Enemy>(enemyForCreation);

            if (!EntityExists(episodeLocator))
                return NotFound();

            Episode episodeEntity = GetEntity(episodeLocator);

            EpisodeRepository.AddEnemy(episodeEntity, enemy);
            EpisodeRepository.Commit();

            return Ok();
        }
    }
}