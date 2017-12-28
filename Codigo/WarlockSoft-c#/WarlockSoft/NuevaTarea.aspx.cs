using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WarlockSoft
{
    public partial class Contact : Page
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

        protected void btn_crearTarea_Click(object sender, EventArgs e)
        {
            JTarea.Tarea tarea = new JTarea.Tarea();
            ArrayList temp = new ArrayList();
            DataTable tabla = (DataTable) Session["tablaConocimientos-nt"];
           
            for (int i = 0; i < tabla.Rows.Count; i++)
			{
                DataRow fila = tabla.Rows[i];
                String conocimiento = fila["CONOCIMIENTO REQUERIDO"].ToString();
                temp.Add(conocimiento);
			}
            String[] conocimientos = (String[])temp.ToArray(typeof(String));
            DateTime f = calendar_inicio.SelectedDate;
            tarea.agregarTarea(txt_nombre.Text, txt_descripcion.Text, f.Day, f.Month, f.Year, Convert.ToDouble(txt_precio.Text), Convert.ToInt32(txt_tiempoNecesario.Text), Convert.ToInt32(txt_cantidadMax.Text), "Borrador", Convert.ToInt32((String)Session["id_usuario"]), conocimientos);
            Response.Redirect("TimeLine.aspx");
        }
    }
}