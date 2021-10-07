using System.Collections.Generic;
using AutoMapper;
using DoctorWho.Db.Access;
using DoctorWho.Db.DBModels;
using DoctorWho.Db.Interfaces;

namespace DoctorWho.Db.Repositories
{
    public class
        AccessRequestEfRepository<TLocator> : EFRepository<AccessRequest, AccessRequestDbModel, TLocator,
            AccessRequestDbContext>
    {
        public AccessRequestEfRepository(AccessRequestDbContext context,
            ILocatorPredicate<AccessRequestDbModel, TLocator> locatorPredicate, IMapper mapper) : base(context,
            locatorPredicate, mapper)
        {
        }

        public override AccessRequest GetByIdWithRelatedData(int id)
        {
            return GetById(id);
        }

        public override IEnumerable<AccessRequest> GetAllEntitiesWithRelatedData()
        {
            return GetAllEntities();
        }
    }
}