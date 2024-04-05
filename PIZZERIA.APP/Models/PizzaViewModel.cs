namespace PIZZERIA.APP.Models
{
    public class PizzaViewModel
    {
        public int PizzaId { get; set; }
        public string Denominacion { get; set; } = String.Empty;

        public List<IngredienteViewModel> Ingredientes { get; set; } = new List<IngredienteViewModel>();
    }
}
