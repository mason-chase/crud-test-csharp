using Mc2.CrudTest.Database;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using DotNetCore.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Mc2.CrudTest.Application;

public sealed class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerFactory _CustomerFactory;
    private readonly ICustomerRepository _CustomerRepository;

    public CustomerService
    (
        IUnitOfWork unitOfWork,
        ICustomerFactory CustomerFactory,
        ICustomerRepository CustomerRepository
    )
    {
        _unitOfWork = unitOfWork;
        _CustomerFactory = CustomerFactory;
        _CustomerRepository = CustomerRepository;
    }

    public async Task<IResult<long>> AddAsync(CustomerModel model)
    {
        try
        {
            var validation = new AddCustomerModelValidator().Validation(model);

            if (validation.Failed) return validation.Fail<long>();

            var Customer = _CustomerFactory.Create(model);

            await _CustomerRepository.AddAsync(Customer);

            await _unitOfWork.SaveChangesAsync();

            return Customer.Id.Success();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result<long>.Fail(ex.InnerException.Message);
            else
                throw;
        }
    }

    public async Task<IResult> DeleteAsync(long id)
    {
        await _CustomerRepository.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public Task<CustomerModel> GetAsync(long id)
    {
        return _CustomerRepository.GetModelAsync(id);
    }

    public Task<Grid<CustomerModel>> GridAsync(GridParameters parameters)
    {
        return _CustomerRepository.GridAsync(parameters);
    }

    public async Task<IEnumerable<CustomerModel>> ListAsync()
    {
        return await _CustomerRepository.ListModelAsync();
    }

    public async Task<IResult> UpdateAsync(CustomerModel model)
    {
        try
        {
            var validation = new UpdateCstomerModelValidator().Validation(model);

            if (validation.Failed) return validation;

            var customer = await _CustomerRepository.GetAsync(model.Id);

            if (customer is null) return Result.Success();

            customer.Update(model.FirstName, model.LastName, model.DateOfBirth, model.PhoneNumber, model.Email, model.BankAccountNumber);

            await _CustomerRepository.UpdateAsync(customer);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Fail(ex.InnerException.Message);
            else
                throw;
        }
    }
}
