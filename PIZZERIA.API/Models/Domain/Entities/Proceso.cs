// Clase entidad para el objeto de proceso del pedido
namespace PIZZERIA.API.Models.Domain.Entities
{
    public class Proceso
    {
        public int ProcesoId { get; set; }
        public string Denominacion { get; set; } = String.Empty;
    }
}
