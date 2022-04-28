using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CommandService
{
    public static class CommandDependency
    {
        public static IServiceCollection RegisterCommandHandlers(
            this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(CommandDependency).Assembly);
        }
    }
}
