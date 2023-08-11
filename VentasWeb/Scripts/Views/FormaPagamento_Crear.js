
var tabladata;
$(document).ready(function () {
    activarMenu("Mantenedor");


    ////validamos el formulario
    $("#form").validate({
        rules: {
            Descricao: "required"
        },
        messages: {
            Descricao: "(*)"

        },
        errorElement: 'span'
    });


    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObterFormaPagamento,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Descricao" },
            { "data": "QtParcelas" },
            {
                "data": "Ativo", "render": function (data) {
                    if (data) {
                        return '<span class="badge badge-success">Ativo</span>'
                    } else {
                        return '<span class="badge badge-danger">Inativo</span>'
                    }
                }
            },
            {
                "data": "IdFormaPagto", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='abrirPopUpForm(" + JSON.stringify(row) + ")'><i class='fas fa-pen'></i></button>" +
                        "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });


})


function abrirPopUpForm(json) {

    $("#txtid").val(0);

    if (json != null) {

        $("#txtid").val(json.IdFormaPagto);
        
        $("#txtDescricao").val(json.Descricao);
        $("#cboquantasparcelas").val(json.QtParcelas);
        $("#cboEstado").val(json.Ativo == true ? 1 : 0);

    } else {
        $("#txtDescricao").val("");
        $("#cboquantasparcelas").val("");
        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}


function Guardar() {

    if ($("#form").valid()) {

        var request = {
            objeto: {
                IdFormaPagto: parseInt($("#txtid").val()),
                Descricao: $("#txtDescricao").val(),
                QtParcelas: $("#cboquantasparcelas").val(),
                Ativo: ($("#cboEstado").val() == "1" ? true : false)
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url._GuardarFormaPagamento,
            type: "POST",
            data: JSON.stringify(request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                    $('#FormModal').modal('hide');
                } else {

                    swal("Mensaje", "No se pudo guardar los cambios", "warning")
                }
            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {

            },
        });

    }

}


function eliminar($id) {


    swal({
        title: "Mensaje",
        text: "¿Desea eliminar la categoria seleccionada?",
        type: "warning",
        showCancelButton: true,

        confirmButtonText: "Si",
        confirmButtonColor: "#DD6B55",

        cancelButtonText: "No",

        closeOnConfirm: true
    },

        function () {
            jQuery.ajax({
                url: $.MisUrls.url._EliminarFormaPagamento + "?id=" + $id,
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.resultado) {
                        tabladata.ajax.reload();
                    } else {
                        swal("Mensaje", "No se pudo eliminar la categoria", "warning")
                    }
                },
                error: function (error) {
                    console.log(error)
                },
                beforeSend: function () {

                },
            });
        });

}