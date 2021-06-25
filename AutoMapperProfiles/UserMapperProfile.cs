using AutoMapper;
using CoreServiceApi.DataTransferModels;
using CoreServiceApi.Models;

namespace CoreServiceApi.AutoMapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}