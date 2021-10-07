using System;
using DoctorWho.Db.Domain;

namespace DoctorWho.Db.DBModels
{
    public static class DomainConvertor
    {
        public static Type GetCorrespondingDomainType(Type dbModelType)
        {
            if ((dbModelType) == typeof(AuthorDbModel))
            {
                return typeof(Author);
            }

            if ((dbModelType) == typeof(DoctorDbModel))
            {
                return typeof(Doctor);
            }

            if ((dbModelType) == typeof(EpisodeDbModel))
            {
                return typeof(Episode);
            }

            if ((dbModelType) == typeof(EnemyDbModel))
            {
                return typeof(Enemy);
            }

            if ((dbModelType) == typeof(CompanionDbModel))
            {
                return typeof(Companion);
            }

            return null;
        } 
    }
}