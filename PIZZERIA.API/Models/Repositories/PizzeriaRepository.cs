using PIZZERIA.API.Common;
using PIZZERIA.API.Models.Context;
using PIZZERIA.API.Models.Datos;
using PIZZERIA.API.Models.Domain.Entities;
using PIZZERIA.API.Models.Interfaces;

//Clase Repositorio para implementar los metodos de la interface IPizzeriaRepository
namespace PIZZERIA.API.Models.Repositories
{
    public class PizzeriaRepository : IPizzeriaRepository
    {
        //Inyeccion de dependencia para el contexto de datos
        private PizzeriaContext context;

        public PizzeriaRepository(PizzeriaContext context)
        {
            this.context = context;
        }

        //Metodo para devolver el listado de ingredientes
        public List<Ingrediente> Ingredientes => context.Ingrediente.Ingredientes;

        //Metodo para devolver el listado de pizzas
        public List<Pizza> Pizzas => context.Pizza.Pizzas;

        //Metodo para devolver el lsitado de pedidos
        public List<Pedido> Pedidos => context.Pedido.Pedidos;

        //Metodo para adicionar un pedido
        public Response<bool> AddPedido(Pizza obPizza)
        {
            var response = new Response<bool>();
            try
            {
                var pizza = context.Pizza.Pizzas.Find(p => p.Denominacion == obPizza.Denominacion && p.PizzaId == obPizza.PizzaId); 
                if (pizza is not null)
                {
                    int cont = context.Pedido.Pedidos.Count;
                    Pedido pedido = new Pedido() { PedidoId = cont + 1, oPizza = pizza, oProceso = { ProcesoId = 1, Denominacion = "En Pedido" } };
                    context.Pedido.Pedidos.Add(pedido);
                    response.Data = true;
                    response.Message = "El pedido se ha adicionado correctamente";
                    response.IsSucces = true;
                }
                else
                {
                    response.Data = false;
                    response.Message = "Debe agregar una pizza del menu al pedido";
                    response.IsSucces = false;
                }

            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            
            
            return response;
        }

        //Metodo para cancelar un pedido
        public Response<bool> CancelPedido(int pedidoId)
        {
            var response = new Response<bool>();
            try
            {
                var index = context.Pedido.Pedidos.FindIndex(p => p.PedidoId == pedidoId);
                if (index != -1)
                {
                    context.Pedido.Pedidos.RemoveAll(p => p.PedidoId == pedidoId);
                    response.Data = true;
                    response.Message = "El pedido ha sido cancelado correctamente";
                    response.IsSucces = true;
                }
                else
                {
                    response.Data = false;
                    response.Message = "No se encontraron pedidos";
                    response.IsSucces = false;
                }
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            
            return response;
        }

        //Metodo para editar un pedido
        public Response<bool> EditPedido(Pizza obPizza, int pedidoId)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                var pizza = context.Pizza.Pizzas.Find(p => p.Denominacion == obPizza.Denominacion && p.PizzaId == obPizza.PizzaId);
                if (pizza is not null)
                {
                    var index = context.Pedido.Pedidos.FindIndex(p => p.PedidoId == pedidoId);
                    if (index != -1)
                    {
                        context.Pedido.Pedidos[index].oPizza = pizza;
                        context.Pedido.Pedidos[index].oProceso = new Proceso { ProcesoId = 1, Denominacion = "En Pedido" };
                        response.Data = true;
                        response.IsSucces = true;
                        response.Message = "El pedido ha sido modificado correctamente";
                    }
                    else
                    {
                        response.Data = false;
                        response.Message = "No se encontraron pedidos";
                        response.IsSucces = false;
                    }
                }
                    
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            
            return response;
        }

        //Metodo para consultar un pedido
        public async Task<Response<Pedido>> ConsultarPedido(int pedidoId)
        {
            
            return await GetProceso(pedidoId);
        }

        //Metodo asincrono para Devolver y Actualizar el proceso que se encuentra el pedido
        private async Task<Response<Pedido>> GetProceso(int pedidoId)
        {
            Response<Pedido> response = new Response<Pedido>();
            try
            {
                int index = context.Pedido.Pedidos.FindIndex(p => p.PedidoId == pedidoId);
                if (index != -1)
                {
                    var currentprocess = context.Pedido.Pedidos[index].oProceso;
                    int indexp = context.Proceso.Procesos.FindIndex(p => p.ProcesoId == currentprocess.ProcesoId);
                    if (indexp < context.Proceso.Procesos.Count)
                    {
                        Proceso nextproc = context.Proceso.Procesos[indexp + 1];
                        context.Pedido.Pedidos[index].oProceso = nextproc;
                    }
                    response.Data = context.Pedido.Pedidos[index];
                    response.IsSucces = true;
                    response.Message = $"El pedido se encuentra en {context.Pedido.Pedidos[index].oProceso.Denominacion}";

                }
                else
                {
                    response.IsSucces = false;
                    response.Message = "El pedido no fue encontrado";
                }
                Random rnd = new Random();
                await Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 2)));
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            
            return response;
        }

        public List<Ingrediente> IngredientesByPizza(int pizza)
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            var ing = context.Pizza.Pizzas.Find(p => p.PizzaId == pizza)!.Ingredientes;
            if(ing is not null)
            {
                ingredientes = ing;
            }
            return ingredientes;
        }
    }
}
