using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using DoctorWho.Db.Domain;
using DoctorWho.Db.SeededModels;
using DoctorWho.Db.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EpisodeDetails> EpisodeDetails { get; set; }

        private IEntityReader _entityReader;

        public DoctorWhoCoreDbContext(IEntityReader entityReader = null)
        {
            if (entityReader != null)
            {
                _entityReader = entityReader;
                return;
            }

            _entityReader = new FakeDataReaderWriter();
        }

        public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options,
            IEntityReader entityReader = null) : base(options)
        {
            if (entityReader != null)
            {
                _entityReader = entityReader;
                return;
            }

            _entityReader = new FakeDataReaderWriter();
        }

        public string GetCompanionNamesForEpisode(int episodeId)
        {
            throw new NotSupportedException();
        }

        public string GetEnemyNamesForEpisode(int episodeId)
        {
            throw new NotSupportedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            GetJoinEntityBuilder<Enemy, Episode>(modelBuilder).UsingEntity(j =>
            {
                j.ToTable("EpisodeEnemy");
                j.Property("EpisodesEpisodeId").HasColumnName("EpisodeId");
                j.Property("EnemiesEnemyId").HasColumnName("EnemyId");
                j.Property<int>("EpisodeEnemyId");
                j.HasKey("EpisodeEnemyId");
            });

            GetJoinEntityBuilder<Companion, Episode>(modelBuilder).UsingEntity(j =>
            {
                j.ToTable("EpisodeCompanion");
                j.Property("EpisodesEpisodeId").HasColumnName("EpisodeId");
                j.Property("CompanionsCompanionId").HasColumnName("CompanionId");
                j.Property<int>("EpisodeCompanionId");
                j.HasKey("EpisodeCompanionId");
            });

            modelBuilder
                .HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(GetCompanionNamesForEpisode),
                    new[] {typeof(int)})).HasName("fnCompanions");
            modelBuilder
                .HasDbFunction(
                    typeof(DoctorWhoCoreDbContext).GetMethod(nameof(GetEnemyNamesForEpisode), new[] {typeof(int)}))
                .HasName("fnEnemies");

            modelBuilder.Entity<EpisodeDetails>().HasNoKey().ToView("viewEpisodes");
            modelBuilder.Entity<EpisodeDetails>().Property(ed => ed.CompanionsNames)
                .HasColumnName("Companions");
            modelBuilder.Entity<EpisodeDetails>().Property(ed => ed.EnemiesNames)
                .HasColumnName("Enemies");

            AccessRequestDbContext.AddShadowProperties(modelBuilder);

            SeedModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedModel(ModelBuilder modelBuilder)
        {
            SeedEntities(modelBuilder);
            SeedJoinEntities(modelBuilder);
        }

        private void SeedEntities(ModelBuilder modelBuilder)
        {
            SeedEntity<Author, SeededAuthor>(modelBuilder);
            SeedEntity<Enemy, SeededEnemy>(modelBuilder);
            SeedEntity<Doctor, SeededDoctor>(modelBuilder);
            SeedEntity<Companion, SeededCompanion>(modelBuilder);
            SeedEntity<Episode, SeededEpisode>(modelBuilder);
        }

        private void SeedEntity<TEntity, TSeed>(ModelBuilder modelBuilder)
            where TEntity : class where TSeed : class, TEntity
        {
            var entities = _entityReader.ReadAllFakeEntities<TSeed>() ?? new List<TSeed>();
            
            var seedEntities = AnonymousTypeConvertors.ConvertEntitiesToAnonymous(entities).ToArray();
            
            modelBuilder.Entity<TEntity>().HasData(seedEntities);
        }

        private void SeedJoinEntities(ModelBuilder modelBuilder)
        {
            List<IDictionary<string, object>> enemyEpisodeEntities =
                (List<IDictionary<string, object>>) _entityReader.ReadAllFakeJoinEntities<Enemy, Episode>() ??
                new List<IDictionary<string, object>>();
            ;

            var mappedEnemyEpisodes
                = enemyEpisodeEntities.Select(e => new
                {
                    EpisodesEpisodeId = ((JsonElement) e["EpisodesEpisodeId"]).GetInt32(),
                    EnemiesEnemyId = ((JsonElement) e["EnemiesEnemyId"]).GetInt32(),
                    EpisodeEnemyId = ((JsonElement) e["EpisodeEnemyId"]).GetInt32(),
                    CreatedOn = Convert.ToDateTime(((JsonElement) e["CreatedOn"]).ToString()),
                    CreatedBy = ((JsonElement) e["CreatedBy"]).GetString(),
                    ModifiedOn = Convert.ToDateTime(((JsonElement) e["ModifiedOn"]).ToString()),
                    ModifiedBy = ((JsonElement) e["ModifiedBy"]).GetString(),
                });

            GetJoinEntityBuilder<Enemy, Episode>(modelBuilder)
                .UsingEntity(j => j.HasData(mappedEnemyEpisodes));


            List<IDictionary<string, object>> companionEpisodeEntities =
                (List<IDictionary<string, object>>) _entityReader.ReadAllFakeJoinEntities<Companion, Episode>() ??
                new List<IDictionary<string, object>>();

            var mappedCompanionEpisodes
                = companionEpisodeEntities.Select(e => new
                {
                    EpisodesEpisodeId = ((JsonElement)e["EpisodesEpisodeId"]).GetInt32(),
                    CompanionsCompanionId = ((JsonElement)e["CompanionsCompanionId"]).GetInt32(),
                    EpisodeCompanionId = ((JsonElement)e["EpisodeCompanionId"]).GetInt32(),
                    CreatedOn = Convert.ToDateTime(((JsonElement) e["CreatedOn"]).ToString()),
                    CreatedBy = ((JsonElement) e["CreatedBy"]).GetString(),
                    ModifiedOn = Convert.ToDateTime(((JsonElement) e["ModifiedOn"]).ToString()),
                    ModifiedBy = ((JsonElement) e["ModifiedBy"]).GetString(),
                });

            GetJoinEntityBuilder<Companion, Episode>(modelBuilder)
                .UsingEntity(j => j.HasData(mappedCompanionEpisodes));
        }

        private static CollectionCollectionBuilder<TSecondEntityType, TFirstEntityType>
            GetJoinEntityBuilder<TFirstEntityType, TSecondEntityType>(ModelBuilder modelBuilder)
            where TFirstEntityType : class where TSecondEntityType : class
        {
            var firstEntityCollectionProperty = GetNavigationCollectionProperty<TFirstEntityType, TSecondEntityType>();
            var secondEntityCollectionProperty = GetNavigationCollectionProperty<TSecondEntityType, TFirstEntityType>();

            var entityBuilder = modelBuilder.Entity<TFirstEntityType>()
                .HasMany<TSecondEntityType>(
                    firstEntityCollectionProperty.Name
                )
                .WithMany(
                    secondEntityCollectionProperty.Name
                );

            return entityBuilder;
        }

        private static PropertyInfo GetNavigationCollectionProperty<TFirstEntityType, TSecondEntityType>()
            where TFirstEntityType : class where TSecondEntityType : class
        {
            var properties = typeof(TFirstEntityType).GetProperties();

            PropertyInfo collectionProperty = null;
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(ICollection<TSecondEntityType>))
                    collectionProperty = property;
            }

            return collectionProperty;
        }
    }
}