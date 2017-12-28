<%@ Page Title="Nueva tarea" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaTarea.aspx.cs" Inherits="WarlockSoft.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class ="pager">
        <h2>Crear nueva tarea</h2>
        <asp:Button ID="btn_crearTarea" runat="server" Text="Crear Tarea" OnClick="btn_crearTarea_Click" /> 
    </div>
     <div class="col-xs-6">
            <h4>Nombre de la tarea</h4>
            <asp:TextBox ID="txt_nombre" runat="server" Width="250px"></asp:TextBox>
            <h4>Descripcion de la tarea</h4>
            <asp:TextBox ID="txt_descripcion" runat="server" Width="250px"></asp:TextBox>
            <h4>Fecha de inicio</h4>
         <asp:Calendar ID="calendar_inicio" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
             <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
             <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
             <OtherMonthDayStyle ForeColor="#999999" />
             <SelectedDayStyle BackColor="#333399" ForeColor="White" />
             <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
             <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
            <h4>Pago propuesto por la tarea</h4>
            <asp:TextBox ID="txt_precio" runat="server" Width="250px"></asp:TextBox>
            <h4>Cantidad maxima de participantes</h4>
            <asp:TextBox ID="txt_cantidadMax" runat="server" Width="250px"></asp:TextBox>
     </div>
     <div class="col-xs-6">
         <h4>Tiempo estimado necesario para realizarla</h4>
         <asp:TextBox ID="txt_tiempoNecesario" runat="server"></asp:TextBox>
         <h4>Lista de conocimientos necesarios</h4>
         <asp:GridView ID="tabla_conocimientos" runat="server"></asp:GridView>
         <div>
            <asp:DropDownList ID="ddl_conocimientos" runat="server"></asp:DropDownList>
            <asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClick="btn_agregar_Click" />
            <asp:Button ID="btn_limpiar" runat="server" Text="Limpiar Tabla" OnClick="btn_limpiar_Click"/>
        </div>
     </div>



    
</asp:Content>
