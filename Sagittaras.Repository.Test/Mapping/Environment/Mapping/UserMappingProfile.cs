using AutoMapper;

namespace Sagittaras.Repository.Test.Mapping.Environment.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}