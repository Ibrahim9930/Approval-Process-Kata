using System.Collections.Generic;
using DoctorWho.Db.Access;
using DoctorWho.Db.Interfaces;

namespace DoctorWho.Db.Repositories
{
    public class AccessRequestEfRepository : EFRepository<AccessRequest, string,AccessRequestDbContext>
    {
        public AccessRequestEfRepository(AccessRequestDbContext context,
            ILocatorPredicate<AccessRequest, string> locatorPredicate) : base(context, locatorPredicate)
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