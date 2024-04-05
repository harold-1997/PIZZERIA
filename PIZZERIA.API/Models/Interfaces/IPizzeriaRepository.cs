using PIZZERIA.API.Common;
using PIZZERIA.API.Models.Domain.Entities;

namespace PIZZERIA.API.Models.Interfaces
{
    //Interface para realizar la gestion de la pizzeria
    public interface IPizzeriaRepository
    {
        List<Ingrediente> Ingredientes { get; }

        List<Pizza> Pizzas { get; }

        List<Pedido> Pedidos { get; }

        Response<bool> AddPedido(Pizza pizza);
        Response<bool> EditPedido(Pizza pizza, int pedidoId);
        Response<bool> CancelPedido(int pedidoId);

        List<Ingrediente> IngredientesByPizza(int pizza);

        Task<Response<Pedido>> ConsultarPedido(int pedidoId);

    }
}
