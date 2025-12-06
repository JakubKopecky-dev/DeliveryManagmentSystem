using DeliveryService.Command.Application.Abstraction.Massaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.Common.Executors
{
    public class CommandExecutor(IServiceScopeFactory scopeFactory) : ICommandExecutor
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;



        public async Task<TResult> Execute<TCommand, TResult>(TCommand command, CancellationToken ct = default) where TCommand : ICommand<TResult>
        {
            using var scope = _scopeFactory.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();

            return await handler.Handle(command, ct);
        }



    }
}
