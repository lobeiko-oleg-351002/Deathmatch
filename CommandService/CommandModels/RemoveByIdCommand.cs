using MediatR;
using System;

namespace CommandService.CommandModels
{
    public sealed class RemoveByIdCommand : IRequest<Unit>
    {
        public readonly Guid Id;

        public RemoveByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
