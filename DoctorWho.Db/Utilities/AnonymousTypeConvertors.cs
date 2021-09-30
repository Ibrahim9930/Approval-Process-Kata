using System;
using System.Collections.Generic;
using DoctorWho.Db.Domain;
using DoctorWho.Db.SeededModels;
using Newtonsoft.Json;

namespace DoctorWho.Db.Utilities
{
    public static class AnonymousTypeConvertors
    {
        public static IEnumerable<object> ConvertEntitiesToAnonymous<T>(IEnumerable<T> entities)
        {
            var anonEntities = new List<object>();

            var type = typeof(T);
            if (type == typeof(SeededDoctor))
            {
                var doctorAnonObject = new
                {
                    DoctorId = 0,
                    DoctorNumber = 0,
                    DoctorName = "",
                    Birthdate = DateTime.MinValue,
                    FirstEpisodeDate = DateTime.MinValue,
                    LastEpisodeDate = DateTime.MinValue,
                    CreatedOn = DateTime.MinValue,
                    CreatedBy = "",
                    ModifiedOn = DateTime.MinValue,
                    ModifiedBy = "",
                };
                foreach (var entity in entities)
                {
                    var entityString = JsonConvert.SerializeObject(entity);

                    var anonEntity = JsonConvert.DeserializeAnonymousType(entityString, doctorAnonObject);

                    anonEntities.Add(anonEntity);
                }

                return anonEntities;
            }

            if (type == typeof(SeededAuthor))
            {
                var authorAnonObject = new
                {
                    AuthorId = 0,
                    AuthorName = "",
                    CreatedOn = DateTime.MinValue,
                    CreatedBy = "",
                    ModifiedOn = DateTime.MinValue,
                    ModifiedBy = "",
                };
                foreach (var entity in entities)
                {
                    var entityString = JsonConvert.SerializeObject(entity);

                    var anonEntity = JsonConvert.DeserializeAnonymousType(entityString, authorAnonObject);

                    anonEntities.Add(anonEntity);
                }

                return anonEntities;
            }

            if (type == typeof(SeededEnemy))
            {
                var enemyAnonObject = new
                {
                    EnemyId = 0,
                    EnemyName = "",
                    Description = "",
                    CreatedOn = DateTime.MinValue,
                    CreatedBy = "",
                    ModifiedOn = DateTime.MinValue,
                    ModifiedBy = "",
                };

                foreach (var entity in entities)
                {
                    var entityString = JsonConvert.SerializeObject(entity);

                    var anonEntity = JsonConvert.DeserializeAnonymousType(entityString, enemyAnonObject);

                    anonEntities.Add(anonEntity);
                }

                return anonEntities;
            }

            if (type == typeof(SeededCompanion))
            {
                var companionAnonObject = new
                {
                    CompanionId = 0,
                    CompanionName = "",
                    WhoPlayed = 0,
                    CreatedOn = DateTime.MinValue,
                    CreatedBy = "",
                    ModifiedOn = DateTime.MinValue,
                    ModifiedBy = "",
                };
                foreach (var entity in entities)
                {
                    var entityString = JsonConvert.SerializeObject(entity);

                    var anonEntity = JsonConvert.DeserializeAnonymousType(entityString, companionAnonObject);

                    anonEntities.Add(anonEntity);
                }

                return anonEntities;
            }

            if (type == typeof(SeededEpisode))
            {
                var episodeAnonObject = new
                {
                    EpisodeId = 0,
                    SeriesNumber = 0,
                    EpisodeNumber = 0,
                    EpisodeType = "",
                    Title = "",
                    EpisodeDate = DateTime.MinValue,
                    Notes = "",
                    Enemies = new Enemy[0],
                    Companions = new Companion[0],
                    AuthorId = 0,
                    Author = new Author(),
                    DoctorId = 0,
                    Doctor = new Doctor(),
                    CreatedOn = DateTime.MinValue,
                    CreatedBy = "",
                    ModifiedOn = DateTime.MinValue,
                    ModifiedBy = "",
                };

                foreach (var entity in entities)
                {
                    var entityString = JsonConvert.SerializeObject(entity);

                    var anonEntity = JsonConvert.DeserializeAnonymousType(entityString, episodeAnonObject);

                    anonEntities.Add(anonEntity);
                }

                return anonEntities;
            }

            throw new NotSupportedException("the provided entity type is not supported");
        }
    }
}