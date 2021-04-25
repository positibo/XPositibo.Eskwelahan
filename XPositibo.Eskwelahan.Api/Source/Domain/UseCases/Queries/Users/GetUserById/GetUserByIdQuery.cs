using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories;

namespace XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Queries.Users
{
    public class GetUserByIdQuery : IRequest<GetUserByIdDto>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id) => this.Id = id;

        private class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private IMapper mapper;

            public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }

            public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await unitOfWork.Users.GetByIdAsync(request.Id);

                return mapper.Map<GetUserByIdDto>(user);
            }
        }
    }
}
