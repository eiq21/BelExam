Pedido = {}
Pedido.GetPedidoByClient = function (client, anioCampania) {
    var overlay = $("#divProcesando");
    $.ajaxSetup({
        global: false,
        type: "POST",
        cache: true,
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        url: "/Pedido/GetPedidoByClient",
        beforeSend: function () {
            overlay.removeClass('hide');
            overlay.addClass('show');
        },
        complete: function () {
            overlay.removeClass('show');
            overlay.addClass('hide');
        }
    });
    $.ajax({
        data: "{ client: '" + client + "', anioCampania :"+ anioCampania +"}",
        success: function (response) {
            var data = response.result;
            var items = $('#items');
            var monto = 0;
            items.empty();
            if (data == null || data == "undefinied") {
                return false;
            }
            $.each(data, function (i, d) {
                var item = $('<li class="list-group-item">< span class= "badge" >' + d.Cantidad * d.Producto.Precio + '</span > ' + d.NombreProducto +'  | '+ d.Cantidad +' | '+ d.Producto.Precio +' </li >');
                monto += d.Cantidad * d.Producto.Precio;

            });

            $('#Total').text(monto);
        },
        error: function (result) {
            alert('error');
        }
    });
}