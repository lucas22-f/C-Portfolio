using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortFolio.Models;
namespace PortFolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    //ACCIONES CUANDO HACEMOS UNA PETICION HTTP A UNA RUTA ESPECIFICA
    public IActionResult Index() // Este metodo es el que me devuelve la vista!
    //de modo que pudedo nombrar los controladores de lo que quiero ejecutar
    {
        //dinamico sirve para pasar info a la view desde el controller
        //trabaja solo en este scope;
        /* ViewBag.Nombre = "Lucas Figueroa";
        ViewBag.Edad = 22;

       
        //Otra Forma Fuertemente tipado...

        var p = new Persona(){
            Nombre = "Lucas Figueroa",
            Edad = 22,
        }; */


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
