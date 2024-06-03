using Spaceflight_News_Server.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spaceflight_News_Server.Models;
using Spaceflight_News_Server.Data;

using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



//Context for MySQL database (ubuntu server)
builder.Services.AddDbContextFactory<Spaceflight_News_MySQLContext>(options =>
options.UseMySql(
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Spaceflight_News_MySQLContext") ?? throw new InvalidOperationException("Connection string 'Spaceflight_News_MySQLContext' not found."))
    ));

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(@"https://localhost:7007/") });
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri(@"https://localhost:7007/");

});


var app = builder.Build();

//Add seed data if the database is empty
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();

app.Run();
