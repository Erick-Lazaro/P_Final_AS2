//Limpia alertas de JQuery Validation
function limpiarMensajesError() {
    $('span.error').hide();
}

//Llena el combo de tipos de habitación
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
                html += `<option value="${elemento.IdTipo}">
                            ${elemento.Descripcion}
                        </option>`
            })
            $("#tipo").html(html)

        }
    })

}

//Trae la información de las habitaciones
function consultarHabitacion() {
    $.ajax({
        type: "POST",
        url: "AgregarHabitacion.aspx/ConsultarHabitacion",
        data: "{}",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            var html = ""
            response.d.forEach(function (elemento) {
                //console.log(elemento.NOMBRE, indice);
                html += `<tr>
                                    <th scope="row">${elemento.Id}</th>
                                    <td>${elemento.CodigoHabitacion}</td>
                                    <td>${elemento.EstadoHabitacion}</td>
                                    <td>${elemento.TipoHabitacion}</td>
                                    <td><button type="button" class="btn btn-primary mx-2 editar" data-bs-toggle="modal" data-bs-target="#modalForm">Edit</button><button type="button" class="btn btn-danger borrar">Delete</button></td>
                                </tr>`
            })
            $("#cuerpo").html(html)

        }
    })

}

//Mostrar Modal
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

$(document).ready(function () {
    consultarTipoHabitacion();
    consultarHabitacion();

    //Imagenes
    $(".imgAdd").click(function () {
        $(this).closest(".row").find('.imgAdd').before('<div class="col-sm-2 imgUp"><div class="imagePreview"></div><label class="btn btn-primary">Upload<input type="file" class="uploadFile img" value="Upload Photo" style="width:0px;height:0px;overflow:hidden;"></label><i class="fa fa-times del"></i></div>');
    });
    $(document).on("click", "i.del", function () {
        $(this).parent().remove();
    });

    $(function () {
        $(document).on("change", ".uploadFile", function () {
            var uploadFile = $(this);
            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

            if (/^image/.test(files[0].type)) { // only image file
                var reader = new FileReader(); // instance of the FileReader
                reader.readAsDataURL(files[0]); // read the local file

                reader.onloadend = function () { // set image data as background of div
                    //alert(uploadFile.closest(".upimage").find('.imagePreview').length);
                    uploadFile.closest(".imgUp").find('.imagePreview').css("background-image", "url(" + this.result + ")");
                }
            }

        });
    });
    //FinImagenes



})