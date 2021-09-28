using AutoMapper;
using DoctorWho.Db.Access;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class AccessRequestProfile : Profile
    {
        public AccessRequestProfile()
        {
            CreateMap<AccessRequest, AccessRequestWithIdDto>().ForMember(
                dto => dto.Status,
                opt => opt.MapFrom(ar => ar.Status.ToString())
            ).ForMember(
                dto => dto.AccessLevel,
                opt => opt.MapFrom(ar => ar.AccessLevel.ToString())
                );
            
            CreateMap<AccessRequest, AccessRequestDto>().ForMember(
                dto => dto.Status,
                opt => opt.MapFrom(ar => ar.Status.ToString())
            ).ForMember(
                dto => dto.AccessLevel,
                opt => opt.MapFrom(ar => ar.AccessLevel.ToString())
                );
            
            CreateMap<AccessForCreationRequestDto, AccessRequest>();
            
            CreateMap<AccessForCreationRequestDto, AccessRequestWithIdDto>();
        }
    }
}