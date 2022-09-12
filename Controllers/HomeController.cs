using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Servicios;
using PortFolio.Models;
using PortFolio.Servicios;
namespace PortFolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorios repositorios;//principio de inversion de dependencias
    private readonly IConfiguration configuration;

    public HomeController
    (
    
    ILogger<HomeController> logger,
    IRepositorios repositorios,
    IConfiguration configuration
    
    )
    {
        _logger = logger;
        this.repositorios = repositorios;//inyeccion de dependencias.
        this.configuration = configuration;
    }
     public IActionResult Index() 
     {

        var apellido = configuration.GetValue<String>("Apellido");
        _logger.LogWarning("Apellido: "+apellido);
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
