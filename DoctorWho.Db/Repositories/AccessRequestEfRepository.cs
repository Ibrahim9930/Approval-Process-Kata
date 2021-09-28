using System.Collections.Generic;
using DoctorWho.Db.Access;
using DoctorWho.Db.Interfaces;

namespace DoctorWho.Db.Repositories
{
    public class AccessRequestEfRepository<TLocator> : EFRepository<AccessRequest, TLocator,AccessRequestDbContext>
    {
        public AccessRequestEfRepository(AccessRequestDbContext context,
            ILocatorPredicate<AccessRequest, TLocator> locatorPredicate) : base(context, locatorPredicate)
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