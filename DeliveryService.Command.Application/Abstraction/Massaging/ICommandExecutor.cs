using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.Abstraction.Massaging
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TCommand, TResult>(TCommand command, CancellationToken ct = default) where TCommand : ICommand<TResult>;
    }
}
