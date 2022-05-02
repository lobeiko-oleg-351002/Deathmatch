using MediatR;
using System;
using System.Collections.Generic;
using ViewModels.View;

namespace QueryService.QueryModels
{
    public class GetUsersInParticularSessionQuery : IRequest<IList<UserInSessionViewModel>>
    {
        public readonly Guid SessionId;

        public GetUsersInParticularSessionQuery(Guid id)
        {
            SessionId = id;
        }

    }
}
