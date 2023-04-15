using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using mvc.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Usuarios/Login";
		options.LogoutPath = "/Usuarios/Logout";
		options.AccessDeniedPath = "/Home/Restringido";
	});
    
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador"));
});
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddTransient<IRepositorioPropietario, RepositorioPropietario>();
builder.Services.AddTransient<IRepositorioInmueble, RepositorioInmueble>();
builder.Services.AddTransient<IRepositorioContrato, RepositorioContrato>();
builder.Services.AddTransient<IRepositorioPago, RepositorioPago>();
builder.Services.AddTransient<IRepositorioInquilino, RepositorioInquilino>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

	app.Run();


