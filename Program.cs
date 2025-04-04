using Brianzo_Inmobiliaria.Models;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5000","https://localhost:5001", "http://*:5000", "https://*:5001");
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddSignalR();//añade signalR
//IUserIdProvider permite cambiar el ClaimType usado para obtener el UserIdentifier en Hub
//builder.Services.AddSingleton<IUserIdProvider, UserIdProvider>();
// SOLO PARA INYECCIÓN DE DEPENDECIAS:
/*
Transient objects are always different; a new instance is provided to every controller and every service.
Scoped objects are the same within a request, but different across different requests.
Singleton objects are the same for every object and every request.
*/
//Add IHttpContextAccessor
builder.Services.AddHttpContextAccessor();//Para recuoerar el user entre otros datos
//builder.Services.AddScoped<IRepositorio<Propietario>, RepositorioPropietario>();
//builder.Services.AddScoped<IRepositorioPropietario, RepositorioPropietario>();
builder.Services.AddScoped<IRepositorioPropietario, RepositorioPropietarioMySql>();
builder.Services.AddScoped<IRepositorioInquilino, RepositorioInquilinoMySql>();
//builder.Services.AddScoped<IRepositorio<Inquilino>, RepositorioInquilino>();
//builder.Services.AddScoped<IRepositorioInmueble, RepositorioInmueble>();
//builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

var app = builder.Build();
app.UseHttpsRedirection();//comentar para trabajar con http solo
// Habilitar CORS
app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());
// Uso de archivos estáticos (*.html, *.css, *.js, etc.)
app.UseStaticFiles();
app.UseRouting();
// Permitir cookies
app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.None,
});

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

    app.MapControllerRoute("login", "entrar/{**accion}", new { controller = "Usuarios", action = "Login" });
app.MapControllerRoute("rutaFija", "ruteo/{valor}", new { controller = "Home", action = "Ruta", valor = "defecto" });
app.MapControllerRoute("fechas", "{controller=Home}/{action=Fecha}/{anio}/{mes}/{dia}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
