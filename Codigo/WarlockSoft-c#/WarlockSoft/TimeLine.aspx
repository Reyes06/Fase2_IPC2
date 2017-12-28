<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeLine.aspx.cs" Inherits="WarlockSoft.TimeLine" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blanco">
        <div class="col-xs-6" id="izquierda">
            <h2 class="Pager">TimeLineProyectos</h2>
            <asp:GridView class="col-xs-12" ID="gv_proyectos" runat="server" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    
        <div class="col-xs-6" id="derecha">
            <h2 class="Pager">TimeLineTareas</h2>
              <asp:GridView class="col-xs-12" ID="gv_tareas" runat="server" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
              </asp:GridView>
        </div>
    </div>
</asp:Content>