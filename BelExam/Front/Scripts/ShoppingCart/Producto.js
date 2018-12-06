Producto = {}
Producto.tags = {
    tagCart: '#tagCart'
}
Producto.form = {
    btnbuscar: '#btnBuscar',
    txtSearch: '#txtSearch'
}

Producto.setEvents = function () {
    $(Producto.form.btnbuscar).on('click', function () {
        Producto.search($(Producto.form.txtSearch).val());
    });

    $(Producto.form.txtSearch).keypress(function (event) {
        if (event.keyCode == 13)
            if ($(Producto.form.txtSearch).val() != "")
                $(Producto.form.btnbuscar).click();

    });
}
Producto.search = function (search) {
    var overlay = $("#divProcesando");
    $.ajaxSetup({
        global: false,
        type: "POST",
        cache: true,
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        url: "/Home/Search",
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
        data: "{ search: '" + search + "'}",
        success: function (response) {
            var data = response.result;
            var divCart = $(Producto.tags.tagCart);
            divCart.empty();
            if (data == null || data == "undefinied") {
                return false;
            }
            $.each(data, function (index, item) {
                var row = $('<div class="col-sm-4 col-md-4"></div>');
                var thumbnail = $('<div class="thumbnail"></div>');
                var img = $('<img class="img-thumbnail img-responsive" src="/Content/images/card.png" alt="..."/>');
                img.appendTo(thumbnail);
                var caption = $(' <div class="caption"> <h3>' + item.MarcaDescripcion
                    + '</h3><p class= "description"> ' + item.Descripcion + '</p><span>' + item.Cuv + '</span><div class="precio"> S/' + item.Precio
                    + '</div><div class="clearfix"><input type="number" max="10" min="1" value="1" style="width:80px !important;" class=" pull-left form-control" />' +
                    '<a href="#" id="' + item.Cuv + '" class="btn btn-warning pull-right" role="button">Comprar</a></div></div>');
                caption.appendTo(thumbnail);
                thumbnail.appendTo(row);
                row.appendTo(divCart);
            });
        },
        error: function (result) {
            alert('error');
        }
    });
}