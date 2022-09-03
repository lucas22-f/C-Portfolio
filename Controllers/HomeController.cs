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
        var proyectos = ObtenerProyectos().Take(3).ToList();
        var modelo = new HomeindexViewModel(){Proyectos=proyectos}; // PASADOR DE INFO homeindexVM

        return View(modelo);
    }
    private List<Proyecto> ObtenerProyectos(){


        return new List<Proyecto>(){
            new Proyecto{Titulo="Grill-House",Descripcion="TODO GOOGLE VIEJO",Link="https://google.com",ImagenURL="/img/p1.png"},
            new Proyecto{Titulo="Buen VIaje",Descripcion="TODO GOOGLE VIEJO",Link="https://google.com",ImagenURL="/img/p2.png"},
            new Proyecto{Titulo="Google",Descripcion="TODO GOOGLE VIEJO",Link="https://google.com",ImagenURL="/img/p3.png"},
        };



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
