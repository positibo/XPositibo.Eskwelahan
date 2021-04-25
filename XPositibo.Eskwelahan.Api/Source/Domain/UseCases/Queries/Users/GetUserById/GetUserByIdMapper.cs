using AutoMapper;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;

namespace XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Queries.Users
{
    public class GetUserByIdMapper : Profile
    {
        public GetUserByIdMapper()
        {
            CreateMap<GetUserByIdDto, User>();
            CreateMap<User, GetUserByIdDto>();
        }
    }
}
