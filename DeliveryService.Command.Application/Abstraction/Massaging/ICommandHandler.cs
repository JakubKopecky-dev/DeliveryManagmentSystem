using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.Abstraction.Massaging
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command, CancellationToken ct = default);
    }
}
