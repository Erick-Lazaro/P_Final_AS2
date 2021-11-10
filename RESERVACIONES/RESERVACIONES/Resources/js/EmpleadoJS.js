
function limpiarMensajesError() {
    $('span.error').hide();
}

$(document).ready(function () {
    consultarEmpleado();



    function mostrarModal(titulo = "¿Deseas guardar esta especialidad?", texto = "Los datos se guardarán de forma permanente en la BD", textobtn = "Guardar") {
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
    function EliminarEmpleado(codigo) {
        mostrarModal("¿Desea eliminar este registro?", "Los datos se eliminaran de forma permanente", "Borrar").then(result => {
            if (result.value) {
                $.ajax({
                    type: "POST",
                    url: "Empleado.aspx/Eliminar",
                    data: "{ IDEMPLEADO: " + codigo + " }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.d) {
                            consultarEmpleado();
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

    function consultarEmpleado() {
        $.ajax({
            type: "POST",
            url: "Empleado.aspx/ConsultarEmpleado",
            data: "{}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                var html = ""
                response.d.forEach(function (elemento) {
                    //console.log(elemento.NOMBRE, indice);
                    html += `<tr>
                                    <th scope="row">${elemento.IDEMPLEADO}</th>
                                    <td>${elemento.NOMBRE}</td>
                                    <td>${elemento.TELEFONO}</td>
                                    <td>${elemento.DIRECCION}</td>
                                    <td>${elemento.SALARIO}</td>
                                    <td><button type="button" class="btn btn-primary mx-2 editar" data-bs-toggle="modal" data-bs-target="#modalForm">Edit</button><button type="button" class="btn btn-danger borrar">Delete</button></td>
                                </tr>`
                })
                $("#cuerpo").html(html)

            }
        })

    }

    //Update
    function ActualizarEmpleado(codigo) {
        $.ajax({
            type: "POST",
            url: "Empleado.aspx/GetEmpleado",
            data: "{'IDEMPLEADO':'" + codigo + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                //console.log(response.d);
                $("#codigo").val(response.d.IDEMPLEADO);
                $("#name").val(response.d.NOMBRE);
                $("#tel").val(response.d.TELEFONO);
                $("#dir").val(response.d.DIRECCION);
                $("#salario").val(response.d.SALARIO);
            }
        })
    }


    //Crear
    $(document).on("click", "#btnCrear", function () {
        document.getElementById("frmRegistro").reset();
    })

    $(document).on("click", ".editar", function () {
        var parent = $(this).parent().parent()[0].children[0].innerText;
        ActualizarEmpleado(parent);

    })

    $(document).on("click", ".borrar", function () {
        var parent = $(this).parent().parent()[0].children[0].innerText;
        EliminarEmpleado(parent);

    })


    //Validate
    $("#frmRegistro").validate({
        rules: {
            name: {
                required: true,
                minlength: 3
            },
            tel: {
                required: true,
                minlength: 8,
                maxlength: 8
            },
            dir: {
                required: true,
                minlength: 3
            },
            salario: {
                required: true,
                number: true,
                min: 0
            }
        },
        messages: {
            name: {
                minlength: "El nombre debería de tener al menos 3 caracteres",
                required: "Por favor ingresa tu nombre"
            },
            tel: {
                minlength: "Deberías ingresar al menos 8 digitos",
                maxlength: "Deberías ingresar un máximo de 8 digitos",
                required: "Por favor ingresa tu teléfono"
            },
            dir: {
                minlength: "La dirección debería de tener al menos 3 caracteres",
                required: "Por favor ingresa tu dirección"
            },
            salario: {
                required: "Por favor ingresa tu salario",
                number: "Por favor ingrese su salario de forma numérica"
            }
        },
        errorElement: 'span',
        submitHandler: function (form) {
            //var boton = document.getElementById("guardarEmpleado");
            //boton.removeAttribute("data-bs-dismiss");
            let empleado = {
                emp: {
                    IDEMPLEADO: $("#codigo").val() == "" ? 0 : $("#codigo").val(),
                    NOMBRE: $("#name").val(),
                    TELEFONO: $("#tel").val(),
                    DIRECCION: $("#dir").val(),
                    SALARIO: $("#salario").val(),
                    ESTADO: 1
                }

            }
            //console.log(empleado.emp.IDEMPLEADO == 0 ? "Empleado.aspx/Registrar" : "Empleado.aspx/Actualizar")

            $.ajax({
                type: "POST",
                url: empleado.emp.IDEMPLEADO == 0 ? "Empleado.aspx/Registrar" : "Empleado.aspx/Actualizar",
                data: JSON.stringify(empleado),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        $('#modalForm .btn-close').click();
                        alert("¡Registro Correcto!");
                        consultarEmpleado();
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