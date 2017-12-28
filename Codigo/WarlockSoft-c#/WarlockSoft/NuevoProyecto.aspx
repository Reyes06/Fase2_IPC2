<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoProyecto.aspx.cs" Inherits="WarlockSoft.NuevoProyecto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="col-xs-9">
    <div class="pager">
        <h2>Crear nuevo proyecto</h2>
        <asp:Button ID="btn_crearProyecto" runat="server" Text="Crear Proyecto" OnClick="btn_crearProyecto_Click" />
    </div>
            <h3>Informacion hacerca del proyecto</h3>
            <div class="col-xs-7">
                <h4>Nombre</h4>
                <asp:TextBox ID="txt_nombre" runat="server" Width="338px"></asp:TextBox>
                <h4>Fecha Inicio</h4>
                <asp:Calendar ID="calendar_inicio" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                <h4>Modo de pago</h4>
                <asp:DropDownList ID="ddl_pago" runat="server" Height="22px" Width="332px"></asp:DropDownList>
            </div>
            <div class="col-xs-5">
                <h4>Salario a pagar</h4>
                <asp:TextBox ID="txt_salario" runat="server" Width="330px"></asp:TextBox>
                <h4>Fecha de finalizacion</h4>
                <asp:Calendar ID="calendar_fin" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </div>
        </div>
    </asp:Content>