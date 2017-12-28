using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WarlockSoft
{
    public partial class ModificarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Llenar el DropDownList
            if (ddl_conocimientos.Items.Count == 0)
            {
                JConocimiento.Conocimiento conocimiento = new JConocimiento.Conocimiento();
                String[] conocimientos = conocimiento.obtenerConocimientos();
                for (int i = 0; i < conocimientos.Length; i++)
                {
                    ddl_conocimientos.Items.Add(conocimientos[i]);
                }
                ddl_conocimientos.DataBind();
            }
            //Cargar las tareas
            cargarTareas();

            //Validar el estado de la tarea
            if (txt_estado.Text.Equals("Activa"))
            {
                btn_publicar.Visible = false;
                btn_terminar.Visible = true;
            } else if(txt_estado.Text.Equals("Borrador")) 
            {
                btn_publicar.Visible = true;
                btn_terminar.Visible = false;
            }
            else if (txt_estado.Text.Equals("Terminada"))
            {
                btn_publicar.Visible = false;
                btn_terminar.Visible = false;
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            //Llenar la tabla
            if (Session["tablaConocimientos-nt"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CONOCIMIENTO REQUERIDO");
                Session["tablaConocimientos-nt"] = dt;
            }
            DataTable temp = (DataTable)Session["tablaConocimientos-nt"];
            DataRow dr = temp.NewRow();
            dr["CONOCIMIENTO REQUERIDO"] = ddl_conocimientos.SelectedItem.ToString();
            temp.Rows.Add(dr);
            Session["tablaConocimientos-nt"] = temp;
            tabla_conocimientos.DataSource = temp;
            tabla_conocimientos.DataBind();

            //Eliminar item del DropDownList
            int index = ddl_conocimientos.SelectedIndex;
            ddl_conocimientos.Items.RemoveAt(index);
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            Session["tablaConocimientos-nt"] = null;
            ddl_conocimientos.Items.Clear();
            ddl_conocimientos.DataBind();
            tabla_conocimientos.DataSource = null;
            tabla_conocimientos.DataBind();
            JConocimiento.Conocimiento c = new JConocimiento.Conocimiento();
            String[] conocimientos = c.obtenerConocimientos();
            for (int i = 0; i < conocimientos.Length; i++)
            {
                ddl_conocimientos.Items.Add(conocimientos[i]);
            }
            ddl_conocimientos.DataBind();
        }

        protected void btn_publicar_Click(object sender, EventArgs e)
        {
            JTarea.Tarea t = new JTarea.Tarea();
            t.cambiarEstado((int)Session["id_tarea-mt"], "Activa");
            Session["id_tarea-mt"] = null;
            Response.Redirect("TimeLine.aspx");
        }

        protected void cargarTareas()
        {
            JTarea.Tarea tarea = new JTarea.Tarea();
            String[] t = tarea.obtenerDatosTarea((int)Session["id_tarea-mt"]);
            txt_nombre.Text = t[1];
            txt_descripcion.Text = t[2];
            txt_precio.Text = t[4];
            txt_tiempoNecesario.Text = t[5];
            txt_cantidadMax.Text = t[6];
            txt_estado.Text = t[7]; 
        }

        protected void btn_terminar_Click(object sender, EventArgs e)
        {
            JTarea.Tarea t = new JTarea.Tarea();
            t.cambiarEstado((int)Session["id_tarea-mt"], "Terminada");
            Session["id_tarea-mt"] = null;
            Response.Redirect("TimeLine.aspx");
        }
    }
}