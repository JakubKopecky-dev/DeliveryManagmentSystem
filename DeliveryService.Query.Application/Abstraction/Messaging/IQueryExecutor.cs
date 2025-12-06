using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Abstraction.Messaging
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query, CancellationToken ct = default) where TQuery : IQuery<TResult>;
    }
}
