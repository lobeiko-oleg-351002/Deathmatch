using MediatR;
using ViewModels.View;

namespace CommandService.CommandModels
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual RoleViewModel Role { get; set; }
    }
}
