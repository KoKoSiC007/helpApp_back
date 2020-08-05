using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SupService.Controllers.socket.Handler;
using SupService.Managers.Connection;

namespace SupService.Controllers.socket
{
    public static class WebSocketExtension
    {
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddTransient<IConnectionManager, ConnectionManager>();
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(WebSocketHandler))
                {
                    services.AddSingleton(type);
                }
            }

            return services;
        }

        public static IApplicationBuilder MapSockets(this IApplicationBuilder app, PathString path,
            WebSocketHandler handler)
        {
            return app.Map(path, (builder) => builder.UseMiddleware<SocketMiddleware>(handler));
        }
    }
}