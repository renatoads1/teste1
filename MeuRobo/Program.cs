using MeuRoboAutomacao;
using MeuRoboDados.Contexto;
using MeuRoboDados.Repository;
using MeuRoboDominio.Interfaces;
using MeuRoboNegocios.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//maper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IExecutorRepository,Executor>();
builder.Services.AddScoped<ICursosRepository, CursosRepository>();
//db conetxt
builder.Services.AddDbContext<CursosDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

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
