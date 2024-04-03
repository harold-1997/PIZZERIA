
//Clase entidad para el objeto de Pizza la cual contiene un listado de ingredientes
namespace PIZZERIA.API.Models.Domain.Entities
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Denominacion { get; set; } = String.Empty;

        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
