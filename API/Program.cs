using Cogensoft.SnippetManager.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<DatabaseService>();
            context.Database.Migrate();
        }

        host.Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => 
                webBuilder.UseStartup<Startup>());
}