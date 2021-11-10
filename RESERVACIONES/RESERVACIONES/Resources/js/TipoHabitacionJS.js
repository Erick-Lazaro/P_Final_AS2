function limpiarMensajesError() {
    $('span.error').hide();
}

$(document).ready(function () {
    consultarTipoHabitacion();



    function mostrarModal(titulo = "", texto = "", textobtn = "Guardar") {
        return Swal.fire({
            title: titulo,
            text: texto,
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: textobtn
        })
    }

    //Eliminar
    function EliminarTipoHabitacion(id) {
        mostrarModal("¿Desea eliminar este registro?", "Los datos se eliminaran de forma permanente", "Borrar").then(result => {
            if (result.value) {
                $.ajax({
                    type: "POST",
                    url: "TipoHabitacion.aspx/Eliminar",
                    data: "{ id: " + id + " }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.d) {
                            consultarTipoHabitacion();
                            Swal.fire(
                                '¡Eliminado!',
                                'El registro ha sido eliminado.',
                                'success'
                            )
                        }

                    }
                })
            }
        });
    }

    function consultarTipoHabitacion() {
        $.ajax({
            type: "POST",
            url: "TipoHabitacion.aspx/ConsultarTipoHabitacion",
            data: "{}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                var html = ""
                response.d.forEach(function (elemento) {
                    //console.log(elemento.NOMBRE, indice);
                    html += `<tr>
                                    <th scope="row">${elemento.IdTipo}</th>
                                    <td>${elemento.Descripcion}</td>
                                    <td>${elemento.TarifaNormal}</td>
                                    <td>${elemento.TarifaFin}</td>
                                    <td>${elemento.CantidadPersonas}</td>
                                    <td><button type="button" class="btn btn-primary mx-2 editar" data-bs-toggle="modal" data-bs-target="#modalForm">Edit</button><button type="button" class="btn btn-danger borrar">Delete</button></td>
                                </tr>`
                })
                $("#cuerpo").html(html)

            }
        })

    }

    //Update
    function ActualizarTipohabitacion(codigo) {
        $.ajax({
            type: "POST",
            url: "TipoHabitacion.aspx/GetTipoHabitacion",
            data: "{'id':'" + codigo + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                $("#codigo").val(response.d.IdTipo);
                $("#desc").val(response.d.Descripcion);
                $("#tarifan").val(response.d.TarifaNormal);
                $("#tarifafin").val(response.d.TarifaFin);
                $("#personas").val(response.d.CantidadPersonas);
                console.log($("#codigo").val());
            }
        })
    }


    //Crear
    $(document).on("click", "#btnCrear", function () {
        document.getElementById("frmRegistro").reset();
    })

    $(document).on("click", ".editar", function () {
        var parent = $(this).parent().parent()[0].children[0].innerText;
        ActualizarTipohabitacion(parent);

    })

    $(document).on("click", ".borrar", function () {
        var parent = $(this).parent().parent()[0].children[0].innerText;
        EliminarTipoHabitacion(parent);

    })


    //Validate
    $("#frmRegistro").validate({
        rules: {
            desc: {
                required: true,
                minlength: 3
            },
            tarifan: {
                required: true,

            },
            tarifafin: {
                required: true,

            },
            personas: {
                required: true,
                number: true,
                min: 1
            }
        },
        messages: {
            desc: {
                minlength: "La descripción debería de tener al menos 3 caracteres",
                required: "Por favor ingresa la descripción"
            },
            tarifan: {

                required: "Por favor ingresa la tarifa normal"
            },
            tarifafin: {

                required: "Por favor ingresa la tarifa de fin de semana"
            },
            personas: {
                required: "Por favor ingresa la cantidad de personas",
                number: "Este valor debe ser numérico"
            }
        },
        errorElement: 'span',
        submitHandler: function (form) {
            //var boton = document.getElementById("guardarEmpleado");
            //boton.removeAttribute("data-bs-dismiss");
            let tipohabitacion = {
                tipo: {
                    IdTipo: $("#codigo").val() == "" ? 0 : $("#codigo").val(),
                    Descripcion: $("#desc").val(),
                    TarifaNormal: $("#tarifan").val(),
                    TarifaFin: $("#tarifafin").val(),
                    CantidadPersonas: $("#personas").val(),
                    Estado: 1
                }

            }
            //console.log(empleado.emp.IDEMPLEADO == 0 ? "Empleado.aspx/Registrar" : "Empleado.aspx/Actualizar")

            $.ajax({
                type: "POST",
                url: tipohabitacion.tipo.Id == 0 ? "TipoHabitacion.aspx/Registrar" : "TipoHabitacion.aspx/Actualizar",
                data: JSON.stringify(tipohabitacion),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        $('#modalForm .btn-close').click();
                        alert("¡Registro Correcto!");
                        consultarTipoHabitacion();
                        document.getElementById("frmRegistro").reset();
                    }
                    else {
                        console(response.d);
                    }
                }
            })
        },
        invalidHandler: function (event, validator) {
            console.log("Error...");
        }
    });

})