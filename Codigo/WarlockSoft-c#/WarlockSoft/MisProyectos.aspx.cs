using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WarlockSoft
{
    public partial class MisProyectos : System.Web.UI.Page
    {

        static int numPagTareas = 0;
        static int numPagProyectos = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_usuario"] = 1;

            mostrarTimeLineProyectos();
            mostrarTimeLineTareas();
        }

        protected void mostrarTimeLineTareas()
        {
            JTarea.Tarea t = new JTarea.Tarea();
            int id_usuario = (int)Session["id_usuario"];
            String[] tareas = t.obtenerMisTareasIndividuales(id_usuario);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Tiempo Estimado");
            dt.Columns.Add("Estado");

            //Cargar las 10 tareas de la pagina
            if (tareas != null)
            {
                for (int i = 0; (i < tareas.Length); i++)
                {
                    String[] tarea = tareas[i].Split(';');
                    DataRow fila = dt.NewRow();
                    fila["Id"] = tarea[0];
                    fila["Nombre"] = tarea[1];
                    fila["Descripcion"] = tarea[2];
                    fila["Precio"] = tarea[4];
                    fila["Tiempo Estimado"] = tarea[5];
                    fila["Estado"] = tarea[7];
                    dt.Rows.Add(fila);
                }
            }
            gv_tareas.DataSource = dt;
            gv_tareas.DataBind();
        }

        protected void mostrarTimeLineProyectos()
        {
            JProyecto.Proyecto t = new JProyecto.Proyecto();
            int id_usuario = (int)Session["id_usuario"];
            String[] proyectos = t.obtenerMisProyectos(id_usuario);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Fecha de Inicio");
            dt.Columns.Add("Salario");
            dt.Columns.Add("Modo de pago");
            dt.Columns.Add("Estado");

            //Cargar las 10 tareas de la pagina
            if (proyectos != null)
            {
                for (int i = 0; (i < proyectos.Length); i++)
                {
                    String[] proyecto = proyectos[i].Split(';');
                    DataRow fila = dt.NewRow();
                    fila["Id"] = proyecto[0];
                    fila["Nombre"] = proyecto[1];
                    fila["Fecha de Inicio"] = proyecto[2];
                    fila["Salario"] = proyecto[5];
                    fila["Modo de pago"] = proyecto[6];
                    fila["Estado"] = proyecto[4];
                    dt.Rows.Add(fila);
                }
            }
            gv_proyectos.DataSource = dt;
            gv_proyectos.DataBind();
        }

        protected void gv_proyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable) gv_proyectos.DataSource;
            DataRow fila = dt.Rows[gv_proyectos.SelectedIndex];
            int id_proyecto = Convert.ToInt32(fila["Id"]);
            Session["id_proyecto-mp"] = id_proyecto;
            Response.Redirect("ModificarProyecto.aspx");
        }

        protected void gv_tareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gv_tareas.DataSource;
            DataRow fila = dt.Rows[gv_tareas.SelectedIndex];
            int id_tarea = Convert.ToInt32(fila["Id"]);
            Session["id_tarea-mt"] = id_tarea;
            Response.Redirect("ModificarTarea.aspx");
        }
    }
}