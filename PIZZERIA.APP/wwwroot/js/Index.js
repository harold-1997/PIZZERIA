
var idpedidoSel;

function MostrarPizzas() {

    fetch("/PizzeriaClient/listarPizzas")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        })
        .then(responseJson => {
            if (responseJson.length > 0) {

                $("#tablaPizzas tbody").html("");


                responseJson.forEach((pizza) => {
                    $("#tablaPizzas tbody").append(
                        $("<tr>").append(
                            $("<td>").text(pizza.denominacion),
                            $("<td>").append(
                                $("<button>").addClass("btn btn-primary btn-sm boton-ver-ingredientes").text("Ver Ingredientes").data("dataPizza",pizza),
                                $("<button>").addClass("btn btn-success btn-sm ms-2 boton-add-pedido").text("Realizar Pedido").data("dataPizza",pizza),
                            )
                        )
                    )
                })

            }


        })


}


function MostrarIngredientes() {

    fetch("/PizzeriaClient/listarIngredientes")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        })
        .then(responseJson => {
            if (responseJson.length > 0) {

                $("#tablaIngredientes tbody").html("");


                responseJson.forEach((ingrediente) => {
                    $("#tablaIngredientes tbody").append(
                        $("<tr>").append(
                            $("<td>").text(ingrediente.denominacion)
                        )
                    )
                })

            }


        })


}

function MostrarPedidos() {

    fetch("/PizzeriaClient/listarPedidos")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        })
        .then(responseJson => {

                $("#tablaPedidos tbody").html("");


                responseJson.forEach((pedido) => {
                    $("#tablaPedidos tbody").append(
                        $("<tr>").append(
                            $("<td>").text(pedido.pedidoId),
                            $("<td>").text(pedido.oPizza.denominacion),
                            $("<td>").text(pedido.oProceso.denominacion),
                            $("<td>").append(
                                $("<button>").addClass("btn btn-primary btn-sm boton-editar-pedido").text("Editar").data("dataPedido", pedido),
                                $("<button>").addClass("btn btn-primary btn-sm ms-2 boton-ver-pedido").text("Consultar Proceso").data("dataPedido", pedido),
                                $("<button>").addClass("btn btn-danger btn-sm ms-2 boton-eliminar-pedido").text("Eliminar").data("dataPedido", pedido),
                            )
                        )
                    )
                })

            


        })


}


document.addEventListener("DOMContentLoaded", function () {

    MostrarPizzas();
    MostrarIngredientes()
    MostrarPedidos()
    


}, false)

$(document).on("click", ".boton-add-pedido", function () {

    const pizza = $(this).data("dataPizza");
    console.log(pizza)
    fetch("/PizzeriaClient/AddPedido", {
        method: "POST",
        headers: { "Content-Type": "application/json; charset=utf-8" },
        body: JSON.stringify(pizza)
    }).then(response => {
        Swal.fire("Listo!", "Pedido añadido", "success");
        return response.ok ? response.json() : Promise.reject(response)
    })
    MostrarPedidos()

})

$(document).on("click", ".boton-ver-ingredientes", function () {
    const pizzaId = $(this).data("dataPizza").pizzaId;
    IngredientesPorPizza(pizzaId);
    $("#formModalIngredientes").modal("show");


})

function IngredientesPorPizza(pizzaid) {
    fetch(`/PizzeriaClient/listarIngredientesByPizza?pizzaId=${pizzaid}`, {
        method: "GET",
        headers: { "Content-Type": "application/json; charset=utf-8" }
    }).then(response => {
        return response.ok ? response.json() : Promise.reject(response)
    }).then(responseJson => {

        $("#lista-ing").html("");


        responseJson.forEach((ingrediente) => {
            $("<div>").addClass("row card-ing").append(
                $("<div>").addClass("col-md-9 align-self-center py-3 px-4").append(
                    $("<span>").text(ingrediente.denominacion)
                )
            ).appendTo("#lista-ing")
        })
    })
}

$(document).on("click", ".boton-editar-pedido", function () {
    idpedidoSel = $(this).data("dataPedido").pedidoId;
    
    
    ListarPizzas()
    $("#formModalPizzas").modal("show");
  

})

$(document).on("click", ".boton-ver-pedido", function () {


    const pedido = $(this).data("dataPedido");
    fetch(`/PizzeriaClient/ConsultarPedido?idpedido=${pedido.pedidoId}`, {
        method: "GET"
    }).then(response => {
        MostrarPedidos();
        return response.ok ? response.json() : Promise.reject(response)
    })


})

$(document).on("click", ".boton-eliminar-pedido", function () {


    const pedido = $(this).data("dataPedido");
    fetch(`/PizzeriaClient/CancelPedido?idpedido=${pedido.pedidoId}`, {
        method: "DELETE"
    }).then(response => {
        Swal.fire("Listo!", "Pedido cancelado", "success");
        MostrarPedidos();
        return response.ok ? response.json() : Promise.reject(response)
    })


})


function ListarPizzas() {

    fetch("/PizzeriaClient/listarPizzas")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        })
        .then(responseJson => {

            $("#lista-pizzas").html("");


            responseJson.forEach((pizza) => {
                $("<div>").addClass("row card-pizzas").append(
                    $("<div>").addClass("col-md-9 align-self-center py-3 px-4").append(
                        $("<span>").text(pizza.denominacion)
                    ),
                    $("<div>").addClass("col-md-3 align-self-center").append(
                        $("<button>").addClass("btn btn-outline-success seleccionarpizza").data("opizza", pizza).append(
                            $("<i>").addClass("fas fa-check-circle"), " Seleccionar"
                        )
                    )
                ).appendTo("#lista-pizzas")
            })
        })
}


 $(document).on("click", "button.seleccionarpizza", function () {

     console.log(idpedidoSel)
     objpizza = $(this).data("opizza");
     console.log(objpizza)
     fetch(`/PizzeriaClient/EditPedido?idpedido=${idpedidoSel}`, {
         method: "PUT",
         headers: { "Content-Type": "application/json; charset=utf-8" },
         body: JSON.stringify(objpizza)
     }).then(response => {
         MostrarPedidos()
         $("#formModalPizzas").modal("hide");
         Swal.fire("Listo!", "Pedido editado", "success");
         return response.ok ? response.json() : Promise.reject(response)
     })
     

})

