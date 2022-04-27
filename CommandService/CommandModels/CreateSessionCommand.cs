using MediatR;

namespace CommandService.CommandModels
{
    public class CreateSessionCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public int MaxPlayerCount { get; set; }

        public virtual CreateLocationCommand Level { get; set; }

        public virtual CreateUserCommand Host { get; set; }
    }
}
