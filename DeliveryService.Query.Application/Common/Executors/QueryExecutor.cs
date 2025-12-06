using DeliveryService.Query.Application.Abstraction.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Common.Executors
{
    public class QueryExecutor(IServiceScopeFactory scopeFactory) : IQueryExecutor
    {
        private readonly  IServiceScopeFactory _scopeFactory = scopeFactory;



        public async Task<TResult> Execute<TQuery, TResult>(TQuery query, CancellationToken ct = default) where TQuery : IQuery<TResult>
        {
            using var scope = _scopeFactory.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

            return await handler.Handle(query, ct);
        }
    }
}
