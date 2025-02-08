using AutoMapper;

namespace Sagittaras.Repository.Tests.Projection.AutoMapper.Environment.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}