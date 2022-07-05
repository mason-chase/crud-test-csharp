using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Application.Common.Mappings;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Exceptions;

namespace Mc2.CrudTest.Application.Administration.Customers.Queries
{
    #region query

    public class GetCustomerQuery : IRequest<GetCustomerQueryResponse>
    {
        public int Id { get; set; }

        public GetCustomerQuery()
        {
        }

        public GetCustomerQuery(int id)
        {
            Id = id;
        }
    }

    #endregion;

    #region response

    public class GetCustomerQueryResponse : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string DateOfBirth { get; set; }
    }

    #endregion;

    #region handler

    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetCustomerQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customers), request.Id);
            }

            var result = _mapper.Map<GetCustomerQueryResponse>(entity);

            return result;
        }
    }

    #endregion;
}
