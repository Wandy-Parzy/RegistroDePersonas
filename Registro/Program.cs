using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Registro.Data;
using Microsoft.EntityFrameworkCore;
using Registro.BLL;
using Registro.DAL;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Contexto>(con =>
  con.UseSqlite(ConStr)  
);

builder.Services.AddTransient<OcupacionesBLL>();
builder.Services.AddScoped<OcupacionesBLL>();
builder.Services.AddScoped<PersonaBLL>();

// agregando notificacion
builder.Services.AddScoped<NotificationService>();

var app = builder.Build();

  // Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
