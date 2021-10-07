using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DoctorWho.Db.DBModels;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class
        CompanionEfRepository<TLocator> : EFRepository<Companion, CompanionDbModel, TLocator, DoctorWhoCoreDbContext>
    {
        public CompanionEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<CompanionDbModel, TLocator> locatorPredicate, IMapper mapper) : base(context,
            locatorPredicate, mapper)
        {
        }

        public override Companion GetByIdWithRelatedData(int id)
        {
            var companion = Context.Companions
                .Include(c => c.Episodes)
                .First(c => c.CompanionId == id);
            return GetRepresentation<CompanionDbModel, Companion>(companion);
        }

        public override IEnumerable<Companion> GetAllEntitiesWithRelatedData()
        {
            var companions = Context.Companions
                .Include(c => c.Episodes);
            return GetRepresentation<IQueryable<CompanionDbModel>, IEnumerable<Companion>>(companions);
        }
    }
}