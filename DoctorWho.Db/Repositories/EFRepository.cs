using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DoctorWho.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public abstract class EFRepository<TDomain, TDbModel, TLocator, TDbContext> : IRepository<TDomain,TLocator>
        where TDomain : class where TDbContext : DbContext, IMetadataLogger where TDbModel : class
    {
        protected TDbContext Context;
        private readonly IMapper _mapper;
        private ILocatorPredicate<TDbModel, TLocator> LocatorPredicate { get; }

        protected EFRepository(TDbContext context,
            ILocatorPredicate<TDbModel, TLocator> locatorPredicate, IMapper mapper)
        {
            Context = context;
            LocatorPredicate = locatorPredicate;
            _mapper = mapper;
        }

        public TDomain GetById(int id)
        {
            var entity = Context.Set<TDbModel>().Find(id);
            return GetRepresentation<TDbModel,TDomain>(entity);
        }

        public TDomain GetByLocator(TLocator locator)
        {
            var entity = Context.Set<TDbModel>().FirstOrDefault(LocatorPredicate.GetExpression(locator));
            return GetRepresentation<TDbModel,TDomain>(entity);
        }

        public IEnumerable<TDomain> GetAllWithLocator(TLocator locator)
        {
            var entities = Context.Set<TDbModel>().Where(LocatorPredicate.GetExpression(locator));
            return GetRepresentation<IEnumerable<TDbModel>,IEnumerable<TDomain>>(entities);
        }

        public abstract TDomain GetByIdWithRelatedData(int id);

        public virtual IEnumerable<TDomain> GetAllEntities()
        {
            var entities = Context.Set<TDbModel>();
            return GetRepresentation<IEnumerable<TDbModel>,IEnumerable<TDomain>>(entities);
        }

        public abstract IEnumerable<TDomain> GetAllEntitiesWithRelatedData();

        public void Add(TDomain newEntity)
        {
            var entity = GetRepresentation<TDomain, TDbModel>(newEntity);
            Context.Add(entity);
        }

        public void Update(TDomain updatedEntity)
        {
            TDbModel dbModel = GetRepresentation<TDomain, TDbModel>(updatedEntity);
            Context.Update(dbModel);
        }

        public void Delete(TDomain deletedEntity)
        {
            TDbModel dbModel = GetRepresentation<TDomain, TDbModel>(deletedEntity);
            Context.Remove(dbModel);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        
        public void CommitBy(string userId)
        {
            Context.SaveChangesWithMetadata(userId);
        }

        protected TOutput GetRepresentation<TInput, TOutput>(TInput input)
        {
            return _mapper.Map<TOutput>(input);
        }

    }
}