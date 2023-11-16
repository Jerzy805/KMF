using KMF;
using KMF.Entities;
using KMF.Interfaces;
using KMF.Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using KMF.ConcertoCQRS.Queries.GetConcertos;
using Microsoft.AspNetCore.Identity;
using KMF.ApplicationUser;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApiDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Concertos")));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApiDb>();

builder.Services.AddScoped(provider => new MapperConfiguration(config =>
{
    var scope = provider.CreateScope();
    var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
    config.AddProfile(new ConcertoMappingProfile(userContext));
}).CreateMapper()
);

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddScoped<ConcertoSeeder>();
builder.Services.AddMediatR(typeof(GetConcertosQuery));

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<ConcertoSeeder>();

var repo = scope.ServiceProvider.GetRequiredService<IRepository>();

await repo.Delete(5);

await seeder.Seed();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
