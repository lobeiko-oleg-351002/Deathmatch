using MediatR;
using System.Collections.Generic;
using ViewModels.View;

namespace QueryService.QueryModels
{
    public class GetAllUsersQuery : IRequest<IList<UserViewModel>>
    {
    }
}
