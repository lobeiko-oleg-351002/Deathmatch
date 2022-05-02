using MediatR;
using ViewModels.View;

namespace CommandService.CommandModels
{
    public class CreateSessionCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public int MaxPlayerCount { get; set; }

        public virtual LocationViewModel Level { get; set; }

        public virtual UserViewModel Host { get; set; }
    }
}
