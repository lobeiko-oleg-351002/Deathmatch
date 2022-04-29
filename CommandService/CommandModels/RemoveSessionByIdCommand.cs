using MediatR;
using System;

namespace CommandService.CommandModels
{
    public sealed class RemoveSessionByIdCommand : IRequest<Unit>
    {
        public readonly Guid Id;

        public RemoveSessionByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
