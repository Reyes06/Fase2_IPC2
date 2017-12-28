<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProyecto.aspx.cs" Inherits="WarlockSoft.NuevoProyect" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       
    <div class="pager">
        <h2>Modificar Proyecto</h2>
        <asp:Button ID="btn_publicar" runat="server" Text="Publicar Proyecto" OnClick="btn_publicar_Click" />
    </div>
        <div class="col-xs-6">
                <h3>Informacion acerca del proyecto</h3>
                <h4>Id del proyecto</h4>
                <asp:Label ID="lbl_id_proyecto" runat="server" Text=""></asp:Label>
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
                <h4>Salario a pagar</h4>
                <asp:TextBox ID="txt_salario" runat="server" Width="338px"></asp:TextBox>
                <h4>Fecha de finalizacion</h4>
                <asp:Calendar ID="calendar_fin" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                <h4>Estado del proyecto</h4>
                    <asp:TextBox ID="txt_estado" runat="server" Width="338px"></asp:TextBox>
        </div>
        <div class="col-xs-6">
            <div class="col-xs-12">
                <h3>Tareas Del Proyecto</h3>
                <asp:GridView ID="gv_tablaTareas" runat="server" OnSelectedIndexChanged="gv_tablaTareas_SelectedIndexChanged" Width="320px">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
           </div>
           <div class="col-xs-12">
            <h3>Agregar Tareas</h3>
            <asp:Button ID="btn_tarea" runat="server" Text="Agregar Tarea" OnClick="btn_tarea_Click" />
                <h4>Nombre de la tarea</h4>
                <asp:TextBox ID="txt_tareaNombre" runat="server" Width="330px"></asp:TextBox>
                <h4>Descripcion de la tarea</h4>
                <asp:TextBox ID="txt_tareaDescripcion" runat="server" Width="330px"></asp:TextBox>
                <h4>Fecha de inicio</h4>
                <asp:Calendar ID="calendar_tareaFechaIni" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
               </asp:Calendar>
                <h4>Pago propuesto por la tarea</h4>
                <asp:TextBox ID="txt_tareaPrecio" runat="server" Width="330px"></asp:TextBox>
                <h4>Cantidad de participantes</h4>
                <asp:TextBox ID="txt_cantParticipantes" runat="server" Width="330px"></asp:TextBox>
                <h4>Cantidad maxima de participantes</h4>
                <asp:TextBox ID="txt_tareaCantidadMax" runat="server" Width="330px"></asp:TextBox>
                <h4>Tiempo estimado para realizar la tarea</h4>
                <asp:TextBox ID="txt_tiempoEstimado" runat="server" Width="330px"></asp:TextBox>
                <h4>Lista de conocimientos necesarios</h4>
                <asp:GridView ID="tb_tareaConocimientos" runat="server" Width="337px"></asp:GridView>
                <div>
                    <asp:DropDownList ID="ddl_conocimientos" runat="server" Height="16px" Width="260px"></asp:DropDownList>
                    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClick="btn_agregar_Click" />
                    
                </div>
            </div>
          </div>
    

</asp:Content>