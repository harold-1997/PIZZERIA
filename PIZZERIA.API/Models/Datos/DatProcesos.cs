using PIZZERIA.API.Models.Domain.Entities;

//Clase para simular la persistencia de datos de los procesos
namespace PIZZERIA.API.Models.Datos
{
    public class DatProcesos
    {
        public List<Proceso> Procesos =>
            new List<Proceso>{new Proceso { ProcesoId = 1, Denominacion = "En Pedido" },
                              new Proceso { ProcesoId = 2, Denominacion = "En Armado" },
                              new Proceso { ProcesoId = 3, Denominacion = "En Horno" },
                              new Proceso { ProcesoId = 4, Denominacion = "En Empacado" },
                              new Proceso { ProcesoId = 5, Denominacion = "Entregada al cliente" },
            };
    }
}
