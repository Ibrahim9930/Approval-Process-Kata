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
    public class EnemyEfRepository<TLocator> : EFRepository<Enemy,EnemyDbModel, TLocator,DoctorWhoCoreDbContext>
    {

        public EnemyEfRepository(DoctorWhoCoreDbContext context, ILocatorPredicate<EnemyDbModel, TLocator> locatorPredicate, IMapper mapper) : base(context, locatorPredicate, mapper)
        {
        }
        
        public override Enemy GetByIdWithRelatedData(int id)
        {
            var enemies = Context.Enemies
                .Include(en => en.Episodes)
                .First(en => en.EnemyId == id);
            return GetRepresentation<EnemyDbModel, Enemy>(enemies);
        }

        public override IEnumerable<Enemy> GetAllEntitiesWithRelatedData()
        {
            var enemies = Context.Enemies
                .Include(en => en.Episodes);
            return GetRepresentation<IQueryable<EnemyDbModel>, IQueryable<Enemy>>(enemies);
        }

      
    }
}