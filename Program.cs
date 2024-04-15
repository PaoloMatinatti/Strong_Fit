using Projeto_BackEnd.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateScopes = false;
});


// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration["Data:Strong_Fit:ConnectionString"],
  sqlServerOptionsAction: sqlOptions =>

  {

      sqlOptions.EnableRetryOnFailure(

      maxRetryCount: 10,

      maxRetryDelay: TimeSpan.FromSeconds(30),

      errorNumbersToAdd: null);

  }));


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Personal}/{action=Index}/{id?}");
app.Run();
