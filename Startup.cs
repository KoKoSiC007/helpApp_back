using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SupService.Controllers.socket;
using SupService.Controllers.socket.Handler;
using SupService.Managers.Client;
using SupService.Managers.Message;
using SupService.Managers.Organization;
using SupService.Managers.Project;
using SupService.Managers.ProjectStaffMan;
using SupService.Managers.Stuff;
using SupService.Managers.Ticket;

namespace SupService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebSocketManager();
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
 
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
 
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddDbContext<SupServiceContext>();
            services.AddControllers();
            services.AddTransient<IOrganizationManager, OrganizationManager>();
            services.AddTransient<IClientManager, ClientManager>();
            services.AddTransient<IProjectManager, ProjectManager>();
            services.AddTransient<IStuffManager, StuffManager>();
            services.AddTransient<IProjectStaffManager, ProjectStaffManager>();
            services.AddTransient<ITicketManager, TicketManager>();
            services.AddTransient<IMessageManager, MessageManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseWebSockets();

            app.MapSockets("/ws", provider.GetService<WebSocketMessageHandler>());

            app.UseStaticFiles();
            
            app.UseRouter(routes => 
                routes.Build()
            );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}