<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WarlockSoft.Profile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>   
    <div class="col-xs-6">
       <h2 class="Pager">Informacion del perfil</h2>
       <div class="col-xs-6">
            <p>Nombre: </p><asp:Label ID="lbl_nombre" runat="server" Text=""></asp:Label>
            <p>Correo: </p><asp:Label ID="lbl_correo" runat="server" Text=""></asp:Label>
       </div>
       <div class="col-xs-6">
            <p>FechaNacimiento: </p>
            <asp:Label ID="lbl_fecha" runat="server" Text=""></asp:Label>
            <p>Nickname: </p>
            <asp:Label ID="lbl_nick" runat="server" Text=""></asp:Label>
       </div>
   </div>
   <div class="col-xs-6">          
      <h2 class="Pager">Acciones</h2>    
      <div class="col-xs-6">
         <p>Publicar</p>
          <asp:Button ID="btn_tarea" runat="server" Text="Pub Tarea" Width="120" OnClick="btn_tarea_Click"/>
          <asp:Button ID="btn_proyecto" runat="server" Text="Pub Proyecto" Width="120" OnClick="btn_proyecto_Click"/>
          <asp:Button ID="btn_estado" runat="server" Text="Pub Estado" Width="120"/>
      </div>
      <div class="col-xs-6">
         <p>Extras</p>
          <asp:TextBox ID="txt_buscar" runat="server" Width="250px" Text="Nickname..."></asp:TextBox>
          <asp:Button ID="btn_buscar" runat="server" Text="Buscar" Width="120"/>
          <asp:Button ID="btn_contacto" runat="server" Text="Ag Contacto" Width="120"/>
      </div>
   </div>
</div>
<div>
    <div style="align-content:center" class="col-xs-6">
        <h2 class="Pager">Conocimientos y Habilidades</h2>
        <asp:Label ID="lbl_habilidades" runat="server" Text=""></asp:Label>
    </div>
</div>
</asp:Content>