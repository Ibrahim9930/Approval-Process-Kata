using AutoMapper;
using DoctorWho.Db.Access;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class AccessRequestProfile : Profile
    {
        public AccessRequestProfile()
        {
            CreateMap<AccessRequest, AccessRequestDto>();
            CreateMap<AccessForCreationRequestDto, AccessRequest>();
            CreateMap<AccessForCreationRequestDto, AccessRequestDto>();
        }
    }
}