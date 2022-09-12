
using PortFolio.Models;


namespace PortFolio.Servicios
{
    public interface IRepositorios
    {
        List<Proyecto> ObtenerProyectos();
    }
    public class Repositorios : IRepositorios
    {

        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>(){
            new Proyecto{Titulo="Grill-House",Descripcion="TODO GOOGLE VIEJO",Link="https://google.com",ImagenURL="/img/p1.png"},
            new Proyecto{Titulo="Buen VIaje",Descripcion="TODO GOOGLE VIEJO",Link="https://google.com",ImagenURL="/img/p2.png"},
            new Proyecto{Titulo="Google",Descripcion="TODO GOOGLE VIEJO",Link="https://google.com",ImagenURL="/img/p3.png"},
        };



        }


    }

}