using Microsoft.EntityFrameworkCore;
using todo_web_app2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Person}/{action=PersonList}/{id?}");

app.Run();
