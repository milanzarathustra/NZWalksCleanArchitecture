using MediatR;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using System.Transactions;

namespace NZWalksCleanArch.API.Behaviors
{
    public sealed class UnitOfWorkBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if (IsNotCommand())
            {
                return await next();
            }

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = await next();

                await unitOfWork.CompleteAsync(cancellationToken);

                transactionScope.Complete();

                return response;
            }          
        }

        private static bool IsNotCommand()
        {
            return !typeof(TRequest).Name.EndsWith("Request");
        }
    }
}
