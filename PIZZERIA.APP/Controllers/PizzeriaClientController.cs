using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;
using PIZZERIA.APP.Models;
using PIZZERIA.API.Models.Domain.Entities;
using System.Text;

namespace PIZZERIA.APP.Controllers
{
    public class PizzeriaClientController : Controller
    {
        private readonly HttpClient _httpClient;

        public PizzeriaClientController(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _httpClient.BaseAddress = new Uri("https://localhost:7188/api");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ingredientes()
        {
            return View();
        }

        public IActionResult Pedidos()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> listarPizzas()
        {
            var response = await _httpClient.GetAsync("api/Pizzeria/Pizzas");
            var content = await response.Content.ReadAsStringAsync();
            var pizzas = JsonConvert.DeserializeObject<IEnumerable<PizzaViewModel>>(content);

            return StatusCode(StatusCodes.Status200OK, pizzas);
        }

        [HttpGet]
        public async Task<IActionResult> listarIngredientes()
        {
            var response = await _httpClient.GetAsync("api/Pizzeria/Ingredientes");
            var content = await response.Content.ReadAsStringAsync();
            var pizzas = JsonConvert.DeserializeObject<IEnumerable<IngredienteViewModel>>(content);

            return StatusCode(StatusCodes.Status200OK, pizzas);
        }

        [HttpGet]
        public async Task<IActionResult> listarIngredientesByPizza(int pizzaId)
        {
            var response = await _httpClient.GetAsync($"api/Pizzeria/IngredientesByPizza?pizzaId={pizzaId}");
            var content = await response.Content.ReadAsStringAsync();
            var ingredientes = JsonConvert.DeserializeObject<IEnumerable<IngredienteViewModel>>(content);

            return StatusCode(StatusCodes.Status200OK, ingredientes);
        }

        [HttpGet]
        public async Task<IActionResult> listarPedidos()
        {
            var response = await _httpClient.GetAsync("api/Pizzeria/Pedidos");
            var content = await response.Content.ReadAsStringAsync();
            var pizzas = JsonConvert.DeserializeObject<IEnumerable<PedidoViewModel>>(content);

            return StatusCode(StatusCodes.Status200OK, pizzas);
        }

        [HttpPost]
        public async Task<IActionResult> AddPedido([FromBody] Pizza pizza)
        {
           
                var json = JsonConvert.SerializeObject(pizza);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/Pizzeria/AddPedido", content);
                return StatusCode(StatusCodes.Status200OK);

        }

        [HttpPut]
        public async Task<IActionResult> EditPedido([FromBody] Pizza objpizza, int idpedido)
        {

            var json = JsonConvert.SerializeObject(objpizza);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Pizzeria/EditPedido?pedidoId={idpedido}", content);
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpDelete]
        public async Task<IActionResult> CancelPedido(int idpedido)
        {
            var response = await _httpClient.DeleteAsync($"api/Pizzeria/CancelPedido?pedidoId={idpedido}");
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPedido(int idpedido)
        {
            var response = await _httpClient.GetAsync($"api/Pizzeria/ConsultarPedido?pedidoId={idpedido}");
            var content = await response.Content.ReadAsStringAsync();
            
            var pedido = JsonConvert.DeserializeObject<PedidoViewModel>(content);


            return StatusCode(StatusCodes.Status200OK,pedido);

        }
    }
}
