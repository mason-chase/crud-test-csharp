using System;
using MediatR;
using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Mc2.CrudTest.Application.Common.Models;
using Mc2.CrudTest.Application.Common.Mappings;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Exceptions;
using Mc2.CrudTest.Application.Common.Extensions;

namespace Mc2.CrudTest.Application.Administration.Customers.Queries
{
    #region query

    public class GetCustomersQuery : PagingRequest, IRequest<PagingResult<GetCustomersQueryResponse>>
    {
    }

    #endregion;

    #region response

    public class GetCustomersQueryResponse : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    #endregion;

    #region handler

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, PagingResult<GetCustomersQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetCustomersQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task<PagingResult<GetCustomersQueryResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Customer> query = _dbContext.Customers
                .AsNoTracking();

            var result = query
                .ProjectTo<GetCustomersQueryResponse>(_mapper.ConfigurationProvider)
                .ApplyPaging(request.Page, request.PageSize);

            return Task.FromResult(result);
        }
    }

    #endregion;
}
