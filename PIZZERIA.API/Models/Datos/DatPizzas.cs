using PIZZERIA.API.Models.Domain.Entities;

//Clase para simular la persistencia de datos de las pizzas
namespace PIZZERIA.API.Models.Datos
{
    public class DatPizzas
    {
        public List<Pizza> Pizzas =>
            new List<Pizza>{new Pizza { PizzaId = 1, Denominacion = "Pizza Hawaiina",
                                       Ingredientes = new List<Ingrediente>{new Ingrediente{ IngredienteId = 1, Denominacion = "Queso" },
                                                      new Ingrediente{ IngredienteId = 2, Denominacion = "Salsa de Tomate"},
                                                      new Ingrediente{ IngredienteId = 3, Denominacion = "Harina"},
                                                      new Ingrediente{ IngredienteId = 5, Denominacion = "Piña"} } },
                            new Pizza { PizzaId = 2, Denominacion = "Pizza Italiana",
                                       Ingredientes = new List<Ingrediente> {new Ingrediente{ IngredienteId = 1, Denominacion = "Queso" },
                                                      new Ingrediente{ IngredienteId = 2, Denominacion = "Salsa de Tomate"},
                                                      new Ingrediente{ IngredienteId = 3, Denominacion = "Harina"}}},
                            new Pizza { PizzaId = 3, Denominacion = "Pizza Americana",
                                       Ingredientes = new List<Ingrediente> {new Ingrediente{ IngredienteId = 1, Denominacion = "Queso" },
                                                      new Ingrediente{ IngredienteId = 2, Denominacion = "Salsa de Tomate"},
                                                      new Ingrediente{ IngredienteId = 3, Denominacion = "Harina"}}},
                            new Pizza { PizzaId = 4, Denominacion = "Pizza Vegana",
                                       Ingredientes = new List<Ingrediente> {new Ingrediente{ IngredienteId = 1, Denominacion = "Queso" },
                                                      new Ingrediente{ IngredienteId = 2, Denominacion = "Salsa de Tomate"},
                                                      new Ingrediente{ IngredienteId = 3, Denominacion = "Harina"}}},
                            new Pizza { PizzaId = 5, Denominacion = "Pizza Mexicana",
                                       Ingredientes = new List<Ingrediente> {new Ingrediente{ IngredienteId = 1, Denominacion = "Queso" },
                                                      new Ingrediente{ IngredienteId = 2, Denominacion = "Salsa de Tomate"},
                                                      new Ingrediente{ IngredienteId = 3, Denominacion = "Harina"}}},
            };
    }
}
