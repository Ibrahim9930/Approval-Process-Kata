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
    public class DoctorEfRepository<TLocator> : EFRepository<Doctor, DoctorDbModel, TLocator, DoctorWhoCoreDbContext>
    {
        public DoctorEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<DoctorDbModel, TLocator> locatorPredicate, IMapper mapper) : base(context,
            locatorPredicate, mapper)
        {
        }

        public override Doctor GetByIdWithRelatedData(int id)
        {
            var doctor = Context.Doctors
                .Include(d => d.Episodes)
                .First(d => d.DoctorId == id);
            return GetRepresentation<DoctorDbModel, Doctor>(doctor);
        }

        public override IEnumerable<Doctor> GetAllEntitiesWithRelatedData()
        {
            var doctors = Context.Doctors
                .Include(d => d.Episodes);
            return GetRepresentation<IQueryable<DoctorDbModel>, IQueryable<Doctor>>(doctors);
        }
    }
}