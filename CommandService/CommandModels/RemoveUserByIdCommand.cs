using MediatR;
using System;

namespace CommandService.CommandModels
{
    public sealed class RemoveUserByIdCommand : IRequest<Unit>
    {
        public readonly Guid Id;

        public RemoveUserByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
