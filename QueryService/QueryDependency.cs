using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace QueryService
{
    public static class QueryDependency
    {
        public static IServiceCollection RegisterQueryHandlers(
            this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(QueryDependency).Assembly);
        }
    }
}
