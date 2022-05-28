using MediatR;
using System.Transactions;

namespace Mc2.CrudTest.Bootstrapper.Behaviors;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TransactionManager.MaximumTimeout
        };

        using var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions,TransactionScopeAsyncFlowOption.Enabled);
   
        TResponse response = await next();

        transaction.Complete();

        return response;
    }
}
