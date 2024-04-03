using PIZZERIA.API.Models.Domain.Entities;

//Clase para simular la persistencia de datos de los pedidos
namespace PIZZERIA.API.Models.Datos
{
    public class DatPedidos
    {
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
