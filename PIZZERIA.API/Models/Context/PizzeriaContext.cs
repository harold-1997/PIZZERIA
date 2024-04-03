using PIZZERIA.API.Models.Datos;

//Clase para el contexto de datos
namespace PIZZERIA.API.Models.Context
{
    public class PizzeriaContext
    {
        public DatIngredientes Ingrediente { get; set; } = new DatIngredientes();

        public DatPizzas Pizza { get; set; } = new DatPizzas();

        public DatProcesos Proceso { get; set; } = new DatProcesos();

        public DatPedidos Pedido { get; set; } = new DatPedidos();
    }
}
