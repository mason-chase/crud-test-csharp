using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Bootstrapper.Exceptions;
using Mc2.CrudTest.Bootstrapper.Notifications;
using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Services.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Bootstrapper.Handlers.Commands;

public class CreateCustomerCommand : IRequest<Guid>
{
    public CreateCustomerDTO Model { get; }
    public CreateCustomerCommand(CreateCustomerDTO model) => Model = model;
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    public CreateCustomerCommandHandler(
        ICustomerService customerService!!,
        IMapper mapper!!,
        IValidator<CreateCustomerDTO> validator!!,
        IMediator mediator!!)
    {
        CustomerService = customerService;
        Mapper = mapper;
        Validator = validator;
        Mediator = mediator;
    }

    public ICustomerService CustomerService { get; }
    public IMapper Mapper { get; }
    public IValidator<CreateCustomerDTO> Validator { get; }
    public IMediator Mediator { get; }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var model = request.Model;

        var getPhoneNumber =
            await CustomerService.GetPhoneNumberAsync(model.PhoneNumber, model.CountryCodeSelected);

        var result = Validator.Validate(model);

        if (result.IsValid is false)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();

            throw new InvalidRequestBodyException { Errors = errors };
        }

        var entity = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            PhoneNumber = model.PhoneNumber,
            CountryCodeSelected = model.CountryCodeSelected,
            Email = model.Email,
            BankAccountNumber = model.BankAccountNumber,
        };

        var customer = Mapper.Map<Customer>(model);

        await CustomerService.AddAsync(customer, cancellationToken, true);

        //throw new Exception("Custom Exception .. !!!!");

        await Mediator
            .Publish(new CustomerCreatedEvent(customer.FirstName, customer.LastName, DateTimeOffset.UtcNow), cancellationToken)
        ;

        return customer.Id;
    }
}