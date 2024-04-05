using PIZZERIA.API.Models.Domain.Entities;

namespace PIZZERIA.APP.Models
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        public Pizza oPizza { get; set; }
        public Proceso oProceso { get; set; } = new Proceso();
    }
}
