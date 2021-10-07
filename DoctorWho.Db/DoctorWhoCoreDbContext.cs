using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using DoctorWho.Db.DBModels;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using DoctorWho.Db.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext, IMetadataLogger
    {
        public DbSet<EpisodeDbModel> Episodes { get; set; }
        public DbSet<DoctorDbModel> Doctors { get; set; }
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<CompanionDbModel> Companions { get; set; }
        public DbSet<EnemyDbModel> Enemies { get; set; }
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
            BuildJoinEntities(modelBuilder);

            AssignKeys(modelBuilder);

            BuildFunctions(modelBuilder);

            BuildViews(modelBuilder);

            SeedModel(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        private void BuildJoinEntities(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EpisodeDbModel>()
                .HasMany(ep => ep.Enemies)
                .WithMany(en => en.Episodes)
                .UsingEntity<Dictionary<string, object>>(
                    "EpisodeEnemy",
                    en => en.HasOne<EnemyDbModel>().WithMany().HasForeignKey("EnemiesEnemyId"),
                    en => en.HasOne<EpisodeDbModel>().WithMany().HasForeignKey("EpisodesEpisodeId"),
                    j =>
                    {
                        j.ToTable("EpisodeEnemy");
                        j.Property<int>("EpisodeEnemyId");
                        j.Property("EnemiesEnemyId").HasColumnName("EnemyId");
                        j.Property("EpisodesEpisodeId").HasColumnName("EpisodeId");
                        j.HasKey("EpisodeEnemyId");
                    });

            modelBuilder.Entity<EpisodeDbModel>()
                .HasMany(ep => ep.Companions)
                .WithMany(c => c.Episodes)
                .UsingEntity<Dictionary<string, object>>(
                    "EpisodeCompanion",
                    en => en.HasOne<CompanionDbModel>().WithMany().HasForeignKey("CompanionsCompanionId"),
                    en => en.HasOne<EpisodeDbModel>().WithMany().HasForeignKey("EpisodesEpisodeId"),
                    j =>
                    {
                        j.ToTable("EpisodeCompanion");
                        j.Property<int>("EpisodeCompanionId");
                        j.Property("CompanionsCompanionId").HasColumnName("CompanionId");
                        j.Property("EpisodesEpisodeId").HasColumnName("EpisodeId");
                        j.HasKey("EpisodeCompanionId");
                    });
        }

        private void AssignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorDbModel>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<CompanionDbModel>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<DoctorDbModel>().HasKey(doc => doc.DoctorId);
            modelBuilder.Entity<EnemyDbModel>().HasKey(en => en.EnemyId);
            modelBuilder.Entity<EpisodeDbModel>().HasKey(ep => ep.EpisodeId);
        }

        private void BuildFunctions(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(GetCompanionNamesForEpisode),
                    new[] {typeof(int)})).HasName("fnCompanions");
            modelBuilder
                .HasDbFunction(
                    typeof(DoctorWhoCoreDbContext).GetMethod(nameof(GetEnemyNamesForEpisode), new[] {typeof(int)}))
                .HasName("fnEnemies");
        }

        private void BuildViews(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpisodeDetails>().HasNoKey().ToView("viewEpisodes");
            modelBuilder.Entity<EpisodeDetails>().Property(ed => ed.CompanionsNames)
                .HasColumnName("Companions");
            modelBuilder.Entity<EpisodeDetails>().Property(ed => ed.EnemiesNames)
                .HasColumnName("Enemies");
        }

        private void SeedModel(ModelBuilder modelBuilder)
        {
            SeedEntities(modelBuilder);
            SeedJoinEntities(modelBuilder);
        }

        private void SeedEntities(ModelBuilder modelBuilder)
        {
            SeedEntity<AuthorDbModel>(modelBuilder);
            SeedEntity<EnemyDbModel>(modelBuilder);
            SeedEntity<DoctorDbModel>(modelBuilder);
            SeedEntity<CompanionDbModel>(modelBuilder);
            SeedEntity<EpisodeDbModel>(modelBuilder);
        }

        private void SeedEntity<TEntity>(ModelBuilder modelBuilder)
            where TEntity : class
        {
            var entities = _entityReader.ReadAllFakeEntities<TEntity>() ?? new List<TEntity>();

            modelBuilder.Entity<TEntity>().HasData(entities);
        }

        private void SeedJoinEntities(ModelBuilder modelBuilder)
        {
            List<IDictionary<string, object>> enemyEpisodeEntities =
                (List<IDictionary<string, object>>)
                _entityReader.ReadAllFakeJoinEntities<EnemyDbModel, EpisodeDbModel>() ??
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

            GetJoinEntityBuilder<EnemyDbModel, EpisodeDbModel>(modelBuilder)
                .UsingEntity(j => j.HasData(mappedEnemyEpisodes));


            List<IDictionary<string, object>> companionEpisodeEntities =
                (List<IDictionary<string, object>>) _entityReader
                    .ReadAllFakeJoinEntities<CompanionDbModel, EpisodeDbModel>() ??
                new List<IDictionary<string, object>>();

            var mappedCompanionEpisodes
                = companionEpisodeEntities.Select(e => new
                {
                    EpisodesEpisodeId = ((JsonElement) e["EpisodesEpisodeId"]).GetInt32(),
                    CompanionsCompanionId = ((JsonElement) e["CompanionsCompanionId"]).GetInt32(),
                    EpisodeCompanionId = ((JsonElement) e["EpisodeCompanionId"]).GetInt32(),
                    CreatedOn = Convert.ToDateTime(((JsonElement) e["CreatedOn"]).ToString()),
                    CreatedBy = ((JsonElement) e["CreatedBy"]).GetString(),
                    ModifiedOn = Convert.ToDateTime(((JsonElement) e["ModifiedOn"]).ToString()),
                    ModifiedBy = ((JsonElement) e["ModifiedBy"]).GetString(),
                });

            GetJoinEntityBuilder<CompanionDbModel, EpisodeDbModel>(modelBuilder)
                .UsingEntity(j => j.HasData(mappedCompanionEpisodes));
        }

        public int SaveChangesWithMetadata(string userId)
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added))
            {
                entry.Property("ModifiedOn").CurrentValue = DateTime.Now;
                entry.Property("ModifiedBy").CurrentValue = userId;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedOn").CurrentValue = DateTime.Now;
                    entry.Property("CreatedBy").CurrentValue = userId;
                }
            }

            return base.SaveChanges();
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