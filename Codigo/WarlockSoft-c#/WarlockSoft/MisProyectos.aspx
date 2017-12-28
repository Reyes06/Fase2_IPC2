<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisProyectos.aspx.cs" Inherits="WarlockSoft.MisProyectos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blanco">
        <div class="col-xs-6" id="izquierda">
            <h2 class="Pager">Mis Proyectos</h2>
            <asp:GridView class="col-xs-12" ID="gv_proyectos" runat="server" OnSelectedIndexChanged="gv_proyectos_SelectedIndexChanged" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    
        <div class="col-xs-6" id="derecha">
            <h2 class="Pager">Mis Tareas</h2>
              <asp:GridView class="col-xs-12" ID="gv_tareas" runat="server" OnSelectedIndexChanged="gv_tareas_SelectedIndexChanged" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
              </asp:GridView>
        </div>
    </div>
</asp:Content>