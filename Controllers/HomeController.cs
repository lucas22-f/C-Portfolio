using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortFolio.Models;
using PortFolio.Servicios;
namespace PortFolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorios repositorios;//principio de inversion de dependencias
    private readonly IConfiguration configuration;
    private readonly IservicioEmail servicioEmail;

    public HomeController
    (
    
    ILogger<HomeController> logger,
    IRepositorios repositorios,
    IConfiguration configuration,
    IservicioEmail servicioEmail
    
    )
    {
        _logger = logger;
        this.repositorios = repositorios;//inyeccion de dependencias.
        this.configuration = configuration;
        this.servicioEmail = servicioEmail;
    }
     public IActionResult Index() 
     {

        var apellido = configuration.GetValue<String>("Apellido");
        var repo = new Repositorios();
        var proyectos = repo.ObtenerProyectos().Take(3).ToList(); 
        

        var modelo = new HomeindexViewModel()
        { Proyectos=proyectos, }; // PASADOR DE INFO homeindexVM

        return View(modelo);
    }
 

    public IActionResult Proyectos(){
        var proyectos = repositorios.ObtenerProyectos();
        return View(proyectos);
    }

    public IActionResult Contacto(){
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel){
        await servicioEmail.Enviar(contactoViewModel);
        return RedirectToAction("Gracias");
    }




    public IActionResult Gracias(){
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
