using MediatR;
using System;
using ViewModels.View;

namespace QueryService.QueryModels
{
    public class GetSessionQuery : IRequest<SessionViewModel>
    {
        public readonly Guid Id;

        public GetSessionQuery(Guid id)
        {
            Id = id;
        }

    }
}
