<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rSugerencias.aspx.cs" Inherits="Sugerencias.Registros.rSugerencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid align-items-center">
        <div class="card">
            <div class="card-header badge-dark text-white text-center"><strong><%:Page.Title %></strong></div>
            <div class="card-body text-center">
                <%--SugerenciasID--%>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">SugerenciasId </span>
                    </div>
                    <asp:TextBox ID="SugerenciasIdTextBox" TextMode="Number" MaxLength="9" runat="server" Text="0" CssClass="form-control input-sm col-md-3"></asp:TextBox>
                    <asp:Button Text="Buscar" CssClass="btn btn-info col-md-3" runat="server" ID="BuscarButton" OnClick="BuscarButton_Click" />
                    <%--Fecha--%>
                    <div class="input-group-prepend">
                        <span class="input-group-text " id="Fecha">Fecha </span>
                    </div>
                    <asp:TextBox ID="FechaTextBox" TextMode="Date" runat="server" CssClass="form-control input-sm " Visible="true"></asp:TextBox>
                </div>
                <%--Descripción--%>
                <div class="input-group ">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Descripción </span>
                    </div>
                    <asp:TextBox ID="DescripcionTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer">
                    <div class="text-center">
                        <div class="form-group" display: inline-block>
                            <asp:Button Text="Nuevo" class="btn btn-warning btn-lg" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                            <asp:Button Text="Guardar" class="btn btn-success btn-lg" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                            <asp:Button Text="Eliminar" class="btn btn-danger btn-lg" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click"  />
                        </div>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>
