using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WarlockSoft
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargar la tabla de conocimientos
            tablaConocimientos();
            //Carga la informacion del usuario
            llenarCampos();
        }

        protected void btn_proyecto_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoProyecto.aspx");
        }

        protected void btn_tarea_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaTarea.aspx");
        }

        public void tablaConocimientos()
        {
            JConocimiento.Conocimiento c = new JConocimiento.Conocimiento();
            int id_usuario = Convert.ToInt32((String) Session["id_usuario"]);
            String[] conocimientos = c.obtenerConocimientosUsuario(id_usuario);
            if (conocimientos != null)
            {

                String tabla = "<table><tr><th>Habilidaes</th><th>Conocimientos</th></tr>";
                for (int i = 0; i < conocimientos.Length; i++)
                {
                    String[] con = conocimientos[i].Split(';');
                    tabla += "<tr><td>" + con[0] + "</td><td>" + con[1] + "</td></tr>";

                    for (int j = 2; j < con.Length; j++)
                    {
                        tabla += "<tr><td></td><td>" + con[j] + "</td></tr>";
                    }
                }
                tabla += "</table>";
                lbl_habilidades.Text = tabla;
            }
        }

        public void llenarCampos()
        {
            lbl_nombre.Text = (String) Session["nombre"];
            lbl_correo.Text = (String) Session["correo"];
            lbl_fecha.Text = (String)Session["fecha"];
            lbl_nick.Text = (String) Session["nickname"];
        }
        
    }
}