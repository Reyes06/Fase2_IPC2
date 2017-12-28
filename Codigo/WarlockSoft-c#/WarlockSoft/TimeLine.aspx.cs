using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WarlockSoft
{
    public partial class TimeLine : System.Web.UI.Page
    {
        //static int numPaginaTareas;
        //static int numPaginaProyectos;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargar el TimeLine en el gv_tareas
            mostrarTimeLineTareas();
            //Cargar el TimeLine en el gv_proyectos
            mostrarTimeLineProyectos();
        }

        protected void mostrarTimeLineTareas()
        {
            JTarea.Tarea t = new JTarea.Tarea();
            String[] tareas = t.obtenerTareasIndividuales();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Tiempo Estimado");

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
                    dt.Rows.Add(fila);
                }
            }
            gv_tareas.DataSource = dt;
            gv_tareas.DataBind();
        }

        protected void mostrarTimeLineProyectos()
        {
            JProyecto.Proyecto t = new JProyecto.Proyecto();
            String[] proyectos = t.obtenerProyectos();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Fecha de Inicio");
            dt.Columns.Add("Salario");
            dt.Columns.Add("Modo de pago");

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
                    dt.Rows.Add(fila);
                }
            }
            gv_proyectos.DataSource = dt;
            gv_proyectos.DataBind();
        }

    }
}