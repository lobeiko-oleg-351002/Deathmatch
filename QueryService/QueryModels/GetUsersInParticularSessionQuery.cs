using MediatR;
using System.Collections.Generic;
using ViewModels.View;

namespace QueryService.QueryModels
{
    public class GetUsersInParticularSessionQuery : IRequest<IList<UserInSessionViewModel>>
    {
        public readonly SessionViewModel Session;

        public GetUsersInParticularSessionQuery(SessionViewModel session)
        {
            Session = session;
        }
    }
}
