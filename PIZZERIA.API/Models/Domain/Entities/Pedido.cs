using System.ComponentModel.DataAnnotations;

//Clase entidad para el objeto de Pedido con la pizza relacionada al pedido y el proceso que se encuentra
namespace PIZZERIA.API.Models.Domain.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public Pizza oPizza { get; set; }
        public Proceso oProceso { get; set; } = new Proceso();
    }
}
