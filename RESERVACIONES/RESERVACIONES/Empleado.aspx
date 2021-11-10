<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="RESERVACIONES.Empleado" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="listado">
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">Código</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Teléfono</th>
                        <th scope="col">Dirección</th>
                        <th scope="col">Salario</th>
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
                        <h5 class="modal-title" id="exampleModalLabel">Registrando Nuevo Empleado</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick="limpiarMensajesError();"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3" hidden>
                            <label class="form-label">Código</label>
                            <input type="text" class="form-control controles" id="codigo" name="codigo" placeholder="Código" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Nombre</label>
                            <input type="text" class="form-control controles" minlength="3" id="name" name="name" placeholder="Nombre" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Teléfono</label>
                            <input type="text" class="form-control controles" id="tel" minlength="8" maxlength="8" name="tel" placeholder="xxxx-xxxx" required />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Dirección</label>
                            <input type="text" class="form-control controles" id="dir" minlength="3" name="dir" placeholder="Dirección" required />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Salario</label>
                            <input type="number" class="form-control" id="salario" name="salario" placeholder="" required />
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
<asp:Content runat="server" ContentPlaceHolderID="scripts">
    <script src="Resources/js/EmpleadoJS.js"></script>
</asp:Content>

