using AutoMapper;
using DoctorWho.Db.Access;
using DoctorWho.Db.DBModels;
using DoctorWho.Db.Domain;

namespace DoctorWho.Db.Profiles
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<DoctorDbModel, Doctor>();
            CreateMap<Doctor, DoctorDbModel>();
            CreateMap<AuthorDbModel, Author>();
            CreateMap<Author, AuthorDbModel>();
            CreateMap<CompanionDbModel, Companion>();
            CreateMap<Companion, CompanionDbModel>();
            CreateMap<EnemyDbModel, Enemy>();
            CreateMap<Enemy, EnemyDbModel>();
            CreateMap<EpisodeDbModel, Episode>();
            CreateMap<Episode, EpisodeDbModel>();
            CreateMap<AccessRequestDbModel, AccessRequest>();
            CreateMap<AccessRequest, AccessRequestDbModel>();
        }
    }
}