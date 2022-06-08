using System.Collections.Generic;
using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public record GetAllCustomerQuery : IRequest<List<Customer>>;
