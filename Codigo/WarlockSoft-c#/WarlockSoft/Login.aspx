<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WarlockSoft.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-6">
        <h2>Logearse a travez de una cuenta</h2>
        <h3>Ingresa tu nickname: </h3>
        <asp:TextBox ID="nickname" runat="server" Width="200px"></asp:TextBox>
        <h3>Ingresa tu password: </h3>
        <asp:TextBox ID="password" runat="server" Width="200px"></asp:TextBox>
        <div>
            <asp:Button ID="Aceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click" style="height: 26px" />
            <asp:Label ID="mensaje" runat="server" Text=""></asp:Label>
        </div>
   </div>
   <div class="col-xs-6">
       <h2>No tienes cuenta?... Registrate</h2>
       <h3>Nombre completo</h3>
       <asp:TextBox ID="txt_nombre1" runat="server" Width="200px"></asp:TextBox>
       <h3>Nickname</h3>
       <asp:TextBox ID="txt_nickname1" runat="server" Width="200px"></asp:TextBox>
       <h3>Correo</h3>
       <asp:TextBox ID="txt_correo1" runat="server" Width="200px"></asp:TextBox>
       <h3>Fecha de nacimiento</h3>
       <asp:Calendar ID="cal_fecha" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
           <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
           <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
           <OtherMonthDayStyle ForeColor="#999999" />
           <SelectedDayStyle BackColor="#333399" ForeColor="White" />
           <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
           <TodayDayStyle BackColor="#CCCCCC" />
       </asp:Calendar>
       <h3>Password</h3>
       <asp:TextBox ID="txt_password1" runat="server" Width="200px"></asp:TextBox>
       <asp:Button ID="btn_registrar" runat="server" Text="Registrarse" OnClick="btn_registrar_Click" />
   </div> 
    
</asp:Content>
