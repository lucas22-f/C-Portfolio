using Portfolio.Servicios;
using PortFolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRepositorios,Repositorios>(); // automaticamente va a ser instanciada cada vez que la pida !! 
//en este caso nuestro IRepositorio no necesita compartir datos entre distintas instancias.
//si necesitaramos compartir datos entre instancias Usariamos Singleton o Scoped

//Hay 3 tipos de servicios que podemos inyectar 

/* 
   Transient - tiempo de vida transitorio viven por menos tiempo
   Scope - tiempo de vida delimitado por una peticion http
   SingleTon - Servicio que vive para siempre. siempre se nos sirve la mimsa instancia.

    */

builder.Services.AddTransient<IservicioEmail,ServicioEmail>();

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

app.MapControllerRoute(//ruteo convencional;
    name: "default", //por defecto
    pattern: "{controller=Home}/{action=Index}/{id?}"); // patron que lo define

app.Run();
