using MediatR;
using System;
using ViewModels.View;

namespace CommandService.CommandModels
{
    public class RemoveUserFromSessionCommand : IRequest<Unit>
    {
        public UserViewModel UserViewModel { get; set; }
        public SessionViewModel SessionViewModel { get; set; }
    }
}
