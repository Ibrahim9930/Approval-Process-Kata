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
    public class EpisodeEfRepository<TLocator> : EFRepository<Episode, EpisodeDbModel, TLocator, DoctorWhoCoreDbContext>
    {
        public EpisodeEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<EpisodeDbModel, TLocator> locatorPredicate, IMapper mapper) : base(context,
            locatorPredicate, mapper)
        {
        }

        public override Episode GetByIdWithRelatedData(int id)
        {
            var episode = Context.Episodes
                .Include(ep => ep.Author)
                .Include(ep => ep.Doctor)
                .Include(ep => ep.Companions)
                .Include(ep => ep.Enemies)
                .First(ep => ep.EpisodeId == id);
            return GetRepresentation<EpisodeDbModel, Episode>(episode);
        }

        public override IEnumerable<Episode> GetAllEntitiesWithRelatedData()
        {
            var episodes = Context.Episodes
                .Include(ep => ep.Author)
                .Include(ep => ep.Doctor)
                .Include(ep => ep.Companions)
                .Include(ep => ep.Enemies);
            return GetRepresentation<IQueryable<EpisodeDbModel>, IQueryable<Episode>>(episodes);
        }

        public void AddEnemy(Episode episode, Enemy enemy)
        {
            var episodeDbModel = GetRepresentation<Episode, EpisodeDbModel>(episode);
            var enemyDbModel = GetRepresentation<Enemy, EnemyDbModel>(enemy);

            Context.Attach(episodeDbModel);

            episodeDbModel.Enemies.Add(enemyDbModel);

            Context.ChangeTracker.DetectChanges();
        }

        public void AddCompanion(Episode episode, Companion companion)
        {
            var episodeDbModel = GetRepresentation<Episode, EpisodeDbModel>(episode);
            var companionDbModel = GetRepresentation<Companion, CompanionDbModel>(companion);

            Context.Attach(companionDbModel);

            episodeDbModel.Companions.Add(companionDbModel);

            Context.ChangeTracker.DetectChanges();
        }
    }
}