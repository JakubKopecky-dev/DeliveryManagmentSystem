using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Abstraction.Messaging
{
    public interface IQueryHandler<TQuery,TResult> where TQuery :IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query, CancellationToken ct = default);
    }
}
