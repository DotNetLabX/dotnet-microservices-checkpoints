using Blocks.Domain;
using MediatR;

namespace Blocks.MediatR.Behaviours;

public class SetUserIdBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IAuditableAction
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        request.CreatedById = 1;

        return await next();
    }
}