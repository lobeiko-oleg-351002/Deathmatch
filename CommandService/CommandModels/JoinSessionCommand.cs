using MediatR;
using ViewModels.View;

namespace CommandService.CommandModels
{
    public class JoinSessionCommand : IRequest<Unit>
    {
        public virtual SessionViewModel Session { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}
