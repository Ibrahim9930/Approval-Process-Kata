using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Repositories
{
    public interface IRepository<TDomain, TLocator>
    {
        public TDomain GetById(int id);
        public TDomain GetByIdWithRelatedData(int id);
        public IEnumerable<TDomain> GetAllEntities();
        public IEnumerable<TDomain> GetAllEntitiesWithRelatedData();

        public TDomain GetByLocator(TLocator locator);

        public IEnumerable<TDomain> GetAllWithLocator(TLocator locator);

        public void Add(TDomain newEntity);

        public void Update(TDomain updatedEntity);

        public void Delete(TDomain deletedEntity);

        public void Commit();
        
    }
}