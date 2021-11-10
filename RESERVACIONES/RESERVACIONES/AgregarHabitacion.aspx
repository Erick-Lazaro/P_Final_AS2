<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarHabitacion.aspx.cs" Inherits="RESERVACIONES.AgregarHabitacion" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="listado">
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Código</th>
                        <th scope="col">Estado</th>
                        <th scope="col">Tipo de Habitación</th>
                        <th scope="col">Acciones</th>
                    </tr>
                </thead>
                <tbody id="cuerpo">
                </tbody>
            </table>
        </div>

    </div>

    <!-- Click on Modal Button -->
    <button type="button" id="btnCrear" class="btn btn-warning mx-auto d-block mt-4" data-bs-toggle="modal" data-bs-target="#modalForm">
        Crear Nuevo
    </button>

    <!-- Modal -->
    <form id="frmRegistro" method="post">
        <div class="modal fade" id="modalForm" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Registrando Nueva Habitación</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick="limpiarMensajesError();"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col mb-3" hidden>
                                <label class="form-label">Id</label>
                                <input type="text" class="form-control" id="idhabitacion" name="idhabitacion" readonly />
                            </div>
                            <div class="col mb-3">
                                <label class="form-label">Código habitación</label>
                                <input type="text" class="form-control" minlength="3" id="codigo" name="codigo" required />
                            </div>
                        </div>

                        <div class="row">
                            <div class="mb-3">
                                <label class="form-label">Estado</label>
                                <input type="text" class="form-control" id="estado" name="estado" required />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Tipo Habitación</label>
                                <select class="form-select" id="tipo" name="tipo" required>
                                </select>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-4 imgUp">
                                <div class="imagePreview"></div>
                                <label class="btn btn-primary col-12">
                                    Upload<input type="file" class="uploadFile img" value="Upload Photo" style="width: 0px; height: 0px; overflow: hidden;">
                                </label>
                            </div>
                            <div class="col-sm-4 imgUp">
                                <div class="imagePreview"></div>
                                <label class="btn btn-primary col-12">
                                    Upload<input type="file" class="uploadFile img" value="Upload Photo" style="width: 0px; height: 0px; overflow: hidden;">
                                </label>
                            </div>
                            <div class="col-sm-4 imgUp">
                                <div class="imagePreview"></div>
                                <label class="btn btn-primary col-12">
                                    Upload<input type="file" class="uploadFile img" value="Upload Photo" style="width: 0px; height: 0px; overflow: hidden;">
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button type="submit" id="guardarHabitacion" class="btn btn-primary col-12">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>


</asp:Content>
<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <script src="Resources/js/HabitacionJS.js"></script>
</asp:Content>

