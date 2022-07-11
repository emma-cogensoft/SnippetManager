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
using Presentation.Services.Snippets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SnippetManager");
        
builder.Services.AddDbContext<DatabaseService>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDateService, DateService>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IWebClientWrapper, WebClientWrapper>();
builder.Services.AddScoped<ICreateSnippetViewModelFactory, CreateSnippetViewModelFactory>();

builder.Services.AddScoped<ISnippetFactory, SnippetFactory>();
builder.Services.AddScoped<IGetSnippetDetailQuery, GetSnippetDetailQuery>();
builder.Services.AddScoped<IGetSnippetsListQuery, GetSnippetsListQuery>();
builder.Services.AddScoped<ICreateSnippetCommand, CreateSnippetCommand>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
