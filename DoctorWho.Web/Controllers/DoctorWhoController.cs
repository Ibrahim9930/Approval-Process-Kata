using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using DoctorWho.Db.Interfaces;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Locators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    public class DoctorWhoController<TEntity, TLocator> : Controller
        where TEntity : class
    {
        protected IRepository<TEntity, TLocator> Repository { get; }
        private IMapper Mapper { get; }
        private TEntity CachedEntity { get; set; }

        protected ILocatorTranslator<TEntity, TLocator> LocatorTranslator { get; }

        public DoctorWhoController(IRepository<TEntity, TLocator> repository, IMapper mapper,
            ILocatorTranslator<TEntity, TLocator> locatorTranslator)
        {
            Repository = repository;
            Mapper = mapper;
            LocatorTranslator = locatorTranslator;
        }
        
        protected TOutput GetRepresentation<TInput, TOutput>(TInput doctorInputDto)
        {
            return Mapper.Map<TOutput>(doctorInputDto);
        }

        protected void AddAndCommit<TInput>(string userId, TInput inputDto, TLocator locator = default)
        {
            TEntity entity = Mapper.Map<TEntity>(inputDto);

            if (locator != null)
            {
                LocatorTranslator.SetLocator(entity, locator);
            }

            Repository.Add(entity);
            Repository.CommitBy(userId);

            CachedEntity = entity;
        }

        protected void UpdateAndCommit<TInput>(string userId, TInput inputDto, TLocator locator)
        {
            TEntity entity = GetEntity(locator);
            Mapper.Map(inputDto, entity);

            Repository.Update(entity);
            Repository.CommitBy(userId);

            CachedEntity = entity;
        }

        protected void DeleteAndCommit(TEntity entity)
        {
            Repository.Delete(entity);
            Repository.Commit();

            CachedEntity = null;
        }

        protected bool EntityExists(TLocator locator)
        {
            return GetEntity(locator) != null;
        }

        protected TEntity GetEntity(TLocator locator)
        {
            if (CachedEntity == null || !LocatorTranslator.GetLocator(CachedEntity).Equals(locator))
            {
                CachedEntity = Repository.GetByLocator(locator);
            }

            return CachedEntity;
        }

        protected string GetUserId()
        {
            return User.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}