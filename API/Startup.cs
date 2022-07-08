using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet.Factory;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;
using Cogensoft.SnippetManager.Common.Dates;
using Cogensoft.SnippetManager.Infrastructure.Network;
using Cogensoft.SnippetManager.Infrastructure.Notifications;
using Cogensoft.SnippetManager.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("SnippetManager");
        
        services.AddDbContext<DatabaseService>(
                options => options.UseSqlServer(connectionString));

        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<IDateService, DateService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IWebClientWrapper, WebClientWrapper>();

        services.AddScoped<ISnippetFactory, SnippetFactory>();
        services.AddScoped<IGetSnippetDetailQuery, GetSnippetDetailQuery>();
        services.AddScoped<IGetSnippetsListQuery, GetSnippetsListQuery>();
        services.AddScoped<ICreateSnippetCommand, CreateSnippetCommand>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}