using MediatR;
using System;
using ViewModels.View;

namespace CommandService.CommandModels
{
    public class RemoveUserFromSessionCommand : IRequest<Unit>
    { 
        public Guid Id { get; set; }
    }
}
