using Microsoft.EntityFrameworkCore;
using todo_web_app2.Models;

//autheticate the user cookie
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options=>
    {
        options.LoginPath = "/Access/Login";

        options.ExpireTimeSpan = TimeSpan.FromSeconds(200);
    });

//Add services to container
builder.Services.AddDbContext<PersonContext>(options => options.UseNpgsql
(builder.Configuration.GetConnectionString("todoCon")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
