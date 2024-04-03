using PIZZERIA.API.Models.Domain.Entities;

//Clase para simular la persistencia de datos de los ingredientes
namespace PIZZERIA.API.Models.Datos
{
    public class DatIngredientes
    {

        public List<Ingrediente> Ingredientes => 
            new List<Ingrediente>{new Ingrediente { IngredienteId = 1, Denominacion = "Queso" },
                                  new Ingrediente { IngredienteId = 2, Denominacion = "Salsa de Tomate" },
                                  new Ingrediente { IngredienteId = 3, Denominacion = "Harina" },
                                  new Ingrediente { IngredienteId = 4, Denominacion = "Chorizo" },
                                  new Ingrediente { IngredienteId = 5, Denominacion = "Piña" },
            };
    }
}
