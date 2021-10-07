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
    public class AuthorEfRepository<TLocator> : EFRepository<Author, AuthorDbModel, TLocator, DoctorWhoCoreDbContext>
    {
        public AuthorEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<AuthorDbModel, TLocator> locatorPredicate, IMapper mapper) : base(context,
            locatorPredicate, mapper)
        {
        }

        public override Author GetByIdWithRelatedData(int id)
        {
            var author = Context.Authors
                .Include(a => a.Episodes)
                .First(a => a.AuthorId == id);
            return GetRepresentation<AuthorDbModel, Author>(author);
        }

        public override IEnumerable<Author> GetAllEntitiesWithRelatedData()
        {
            var authors = Context.Authors
                .Include(a => a.Episodes);
            return GetRepresentation<IQueryable<AuthorDbModel>, IQueryable<Author>>(authors);
        }
    }
}