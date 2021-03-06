using MediatR;
using System;

namespace CommandService.CommandModels
{
    public sealed class RemoveLocationByIdCommand : IRequest<Unit>
    {
        public readonly Guid Id;

        public RemoveLocationByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
