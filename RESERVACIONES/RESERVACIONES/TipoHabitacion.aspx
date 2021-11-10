<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoHabitacion.aspx.cs" Inherits="RESERVACIONES.TipoHabitacion" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="listado">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Código</th>
                            <th scope="col">Descripcion</th>
                            <th scope="col">Tarifa Normal</th>
                            <th scope="col">Tarifa Fin de Semana</th>
                            <th scope="col">Cant. Personas</th>
                            <th scope="col">Acciones</th>
                        </tr>
                    </thead>
                    <tbody id="cuerpo">
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <button type="button" id="btnCrear" class="btn btn-warning mx-auto d-block mt-4" data-bs-toggle="modal" data-bs-target="#modalForm">
        Crear Nuevo
    </button>

    <!-- Modal -->
    <form id="frmRegistro" method="post">
        <div class="modal fade" id="modalForm" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Registrando Nuevo Tipo de Habitación</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick="limpiarMensajesError();"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3" hidden>
                            <label class="form-label">Código</label>
                            <input type="text" class="form-control controles" id="codigo" name="codigo" placeholder="Código" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Descripción</label>
                            <input type="text" class="form-control controles" minlength="3" id="desc" name="desc" placeholder="Descripción" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Tarifa Normal</label>
                            <input type="number" class="form-control controles" id="tarifan" name="tarifan" required />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Tarifa Fin de Semana</label>
                            <input type="number" class="form-control controles" id="tarifafin" name="tarifafin" placeholder="" required />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Cantidad de Personas</label>
                            <input type="number" class="form-control" id="personas" name="personas" placeholder="" required />
                        </div>

                        <div class="modal-footer">

                            <button type="submit" id="guardarEmpleado" class="btn btn-primary col-12">Guardar</button>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <script src="Resources/js/TipoHabitacionJS.js"></script>
</asp:Content>
