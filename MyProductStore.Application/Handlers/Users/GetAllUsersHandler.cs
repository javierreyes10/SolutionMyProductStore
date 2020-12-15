using AutoMapper;
using MediatR;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Application.Queries.User;
using MyProductStore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace MyProductStore.Application.Handlers.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PagedListOutputDto<UserOutputDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedListOutputDto<UserOutputDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync(request.CustomQueryParameter);
            var usersAsEnumerable = await users.ToListAsync();

            return new PagedListOutputDto<UserOutputDto>
            {
                Items = _mapper.Map<IEnumerable<Core.Entities.User>, IEnumerable<UserOutputDto>>(usersAsEnumerable),
                Metadata = new PaginationMetadataOutput
                {
                    TotalCount = users.TotalItemCount,
                    PageSize = users.PageSize,
                    TotalPages = users.PageCount,
                    CurrentPage = users.PageNumber,
                    IsFirstPage = users.IsFirstPage,
                    IsLastPage = users.IsLastPage,
                    HasNextPage = users.HasNextPage,
                    HasPreviousPage = users.HasPreviousPage
                }
            };
        }
    }
}
