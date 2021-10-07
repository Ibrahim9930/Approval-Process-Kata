using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db.Domain;
using Bogus;
using DoctorWho.Db.DBModels;

namespace DoctorWho.Db.Utilities
{
    public static class FakeDataGenerator
    {
        private const string FAKES_PATH =
            "C:\\Users\\IbrhaimMasri\\Documents\\Foothill Internship\\EF\\DoctorWho\\fakes";

        private static IEntityWriter _entityWriter = new FakeDataReaderWriter();

        public static string GetFilePathForTypeFakes<T>() where T : class
        {
            var domainType = DomainConvertor.GetCorrespondingDomainType(typeof(T));
            return $"{FAKES_PATH}/{domainType.Name}.json";
        }

        public static string GetFilePathForJoinTypeFakes<TEntityType1, TEntityType2>()
        {
            var entity1DomainType = DomainConvertor.GetCorrespondingDomainType(typeof(TEntityType1));
            var entity2DomainType = DomainConvertor.GetCorrespondingDomainType(typeof(TEntityType2));
            return $"{FAKES_PATH}/{entity1DomainType.Name}_{entity2DomainType.Name}.json";
        }

        public static void GenerateData(int itemCount)
        {
            GenerateFakeEntities(itemCount);
            GenerateFakeJoinEntities(itemCount);
        }

        private static void GenerateFakeEntities(int itemCount)
        {
            GenerateFakeEntity<Author>(itemCount);
            GenerateFakeEntity<Doctor>(itemCount);
            GenerateFakeEntity<Enemy>(itemCount);
            GenerateFakeEntity<Companion>(itemCount);
            GenerateFakeEntity<Episode>(itemCount);
        }

        private static void GenerateFakeEntity<T>(int itemCount) where T : class
        {
            List<T> entities = FakerGenerator.GenerateFakeList<T>(itemCount);

            _entityWriter.WriteFakeEntities<T>(entities);
        }

        private static void GenerateFakeJoinEntities(int itemCount)
        {
            ArrayList episodeEnemyRelations = new ArrayList();
            ArrayList episodeCompanionRelations = new ArrayList();

            Faker faker = new Faker();
            for (int i = 0; i < itemCount; i++)
            {
                episodeCompanionRelations.Add(new
                {
                    EpisodesEpisodeId = faker.PickRandom(Enumerable.Range(1, itemCount)),
                    CompanionsCompanionId = faker.PickRandom(Enumerable.Range(1, itemCount)),
                    EpisodeCompanionId = i + 1
                });
            }

            for (int i = 0; i < itemCount; i++)
            {
                episodeEnemyRelations.Add(new
                {
                    EpisodesEpisodeId = faker.PickRandom(Enumerable.Range(1, itemCount)),
                    EnemiesEnemyId = faker.PickRandom(Enumerable.Range(1, itemCount)),
                    EpisodeEnemyId = i + 1
                });
            }

            _entityWriter.WriteFakeJoinEntities<Enemy, Episode>(episodeEnemyRelations);
            _entityWriter.WriteFakeJoinEntities<Companion, Episode>(episodeCompanionRelations);
        }
    }
}