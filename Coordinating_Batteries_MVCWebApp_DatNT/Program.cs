using Coordinating_Batteries_Repositories_DatNT.Models;
using Coordinating_Batteries_Services_DatNT;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<PRN212_SE1906_SE190283Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}); // connect with sql server

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBatteryTransferDatNtService, BatteryTransferDatNtService>();

builder.Services.AddScoped<IStationDatNtService, StationDatNtService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
