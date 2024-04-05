using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIZZERIA.API.Models.Domain.Entities;
using PIZZERIA.API.Models.Interfaces;


// Controladora que va a gestionar los request y los endpoints de la Pizzeria
namespace PIZZERIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzeriaController : ControllerBase
    {
        //Inyeccion de Dependecia a la interface IPizzeriaRepository
        private IPizzeriaRepository repo;

        public PizzeriaController(IPizzeriaRepository repo)
        {
            this.repo = repo;
        }

        //Endpoint para obtener el listado de los ingredientes
        [HttpGet("Ingredientes")]
        public IActionResult ListIngredientes()
        {
            var ingredientes = repo.Ingredientes.ToList();
            return Ok(ingredientes);
        }

        //Endpoint para obtener el listado de las pizzas
        [HttpGet("Pizzas")]
        public IActionResult ListPizzas()
        {
            var pizzas = repo.Pizzas.ToList();
            return Ok(pizzas);
        }

        //Endpoint para obtener el listado de los pedidos
        [HttpGet("Pedidos")]
        public IActionResult ListPedidos()
        {
            var pedidos = repo.Pedidos.ToList();
            return Ok(pedidos);
        }

        //Endpoint para adicionar un pedido
        [HttpPost("AddPedido")]
        public IActionResult AddPedido([FromBody] Pizza pizza)
        {
            
            return Ok(repo.AddPedido(pizza));
        }

        //Endpoint para editar un pedido
        [HttpPut("EditPedido")]
        public IActionResult EditPedido(int pedidoId, Pizza pizza)
        {
            
            return Ok(repo.EditPedido(pizza, pedidoId));
        }

        //Endpoint para cancelar un pedido
        [HttpDelete("CancelPedido")]
        public IActionResult CancelPedido(int pedidoId)
        {
            return Ok(repo.CancelPedido(pedidoId));
        }

        //Endpoint para consultar un pedido
        [HttpGet("ConsultarPedido")]
        public IActionResult ConsultarPedido(int pedidoId)
        {
            var response = repo.ConsultarPedido(pedidoId).Result;
            return Ok(response.Data);
        }

        [HttpGet("IngredientesByPizza")]
        public IActionResult IngredientesByPizza(int pizzaId)
        {
            var response = repo.IngredientesByPizza(pizzaId);
            return Ok(response);
        }
    }
}
