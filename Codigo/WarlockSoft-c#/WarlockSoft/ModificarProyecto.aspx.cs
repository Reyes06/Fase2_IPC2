using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace WarlockSoft
{
    public partial class NuevoProyect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddl_pago.Items.Count == 0)
            {
                //Llenar DropDownList pago
                ddl_pago.Items.Add("Anual");
                ddl_pago.Items.Add("Mensual");
                ddl_pago.Items.Add("Quincenal");
                ddl_pago.DataBind();
            }
            
            //Llenar DropDownList conocimientos
            if (ddl_conocimientos.Items.Count == 0) 
            {
                llenarDropDownList();
            }

            //Cargar el panel de tareas
            if (gv_tablaTareas.DataSource == null)
            {
                cargarTareas();
            }
            
            //Cargar los campos de la pagina
            cargarCampos();
            
        }

        protected void llenarDropDownList()
        {
            //Llenar DropDownList conocimientos
            ddl_conocimientos.Items.Clear();
            JConocimiento.Conocimiento c = new JConocimiento.Conocimiento();
            String[] conocimientos = c.obtenerConocimientos();
            for (int i = 0; i < conocimientos.Length; i++)
            {
                ddl_conocimientos.Items.Add(conocimientos[i]);
            }
            ddl_conocimientos.DataBind();
        }

        protected void btn_tarea_Click(object sender, EventArgs e)
        {
            JProyecto.Proyecto pj = new JProyecto.Proyecto();
            ArrayList array = new ArrayList();
            DataTable tabla = (DataTable) Session["tablaConocimientos-mp"];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataRow fila = tabla.Rows[i];
                array.Add(fila["CONOCIMIENTOS NECESARIOS"].ToString());
            }
            String[] conocimientos = (String[])array.ToArray(typeof(String));
            pj.agregarTareaAlProyecto(txt_tareaNombre.Text, txt_tareaDescripcion.Text, calendar_tareaFechaIni.SelectedDate.Day, calendar_tareaFechaIni.SelectedDate.Month, calendar_tareaFechaIni.SelectedDate.Year, Convert.ToDouble(txt_tareaPrecio.Text), Convert.ToInt32(txt_tiempoEstimado.Text), Convert.ToInt32(txt_cantParticipantes.Text),"activa", (int)Session["id_usuario"], conocimientos, (int) Session["id_proyecto-mp"]);
            
            //Rellenar el dropDownList
            llenarDropDownList();

            //Resetear campos
            txt_cantParticipantes.Text = "";
            txt_nombre.Text = "";
            txt_salario.Text = "";
            txt_tareaCantidadMax.Text = "";
            txt_tareaDescripcion.Text = "";
            txt_tareaNombre.Text = "";
            txt_tareaPrecio.Text = "";
            txt_tiempoEstimado.Text = "";

            //Vaciar la tabla de conocimientos necesarios
            tb_tareaConocimientos.DataSource = null;
            tb_tareaConocimientos.DataBind();
            Session["tablaConocimientos-mp"] = null;
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            //Llenar la tabla
            if (Session["tablaConocimientos-mp"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CONOCIMIENTOS NECESARIOS");
                Session["tablaConocimientos-mp"] = dt;
            }
            DataTable temp = (DataTable)Session["tablaConocimientos-mp"];
            DataRow dr = temp.NewRow();
            dr["CONOCIMIENTOS NECESARIOS"] = ddl_conocimientos.SelectedItem.ToString();
            temp.Rows.Add(dr);
            Session["tablaConocimientos-mp"] = temp;
            tb_tareaConocimientos.DataSource = temp;
            tb_tareaConocimientos.DataBind();

            //Eliminar item del DropDownList
            int index = ddl_conocimientos.SelectedIndex;
            ddl_conocimientos.Items.RemoveAt(index);
            ddl_conocimientos.DataBind();
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            Session["tablaConocimientos-mp"] = null;
            ddl_conocimientos.Items.Clear();
            ddl_conocimientos.DataBind();
            tb_tareaConocimientos.DataSource = null;
            tb_tareaConocimientos.DataBind();
            JConocimiento.Conocimiento c = new JConocimiento.Conocimiento();
            String[] conocimientos = c.obtenerConocimientos();
            for (int i = 0; i < conocimientos.Length; i++)
            {
                ddl_conocimientos.Items.Add(conocimientos[i]);
            }
            ddl_conocimientos.DataBind();
        }

        protected void btn_selecTarea_Click(object sender, EventArgs e)
        {
            
        }

        protected void cargarCampos()
        {
            JProyecto.Proyecto p = new JProyecto.Proyecto();
            String[] proyecto = p.obtenerDatosProyecto((int)Session["id_proyecto-mp"]);
            lbl_id_proyecto.Text = proyecto[0];
            txt_nombre.Text = proyecto[1];
            //String[] fechaIni = proyecto[2].Split('-');
            //int ano = Convert.ToInt32(fechaIni[0]);
            //int mes = Convert.ToInt32(fechaIni[1]);
            //int dia = Convert.ToInt32(fechaIni[2]);
            //DateTime horaFecha = new DateTime(ano, mes, dia);
            //calendar_inicio.SelectedDate = horaFecha;
            //calendar_inicio.DataBind();
            //String[] fechaFin = proyecto[3].Split('-');
            //ano = Convert.ToInt32(fechaIni[0]);
            //mes = Convert.ToInt32(fechaIni[1]);
            //dia = Convert.ToInt32(fechaIni[2]);
            //horaFecha = new DateTime(ano, mes, dia);
            //calendar_fin.SelectedDate = horaFecha;
            //calendar_fin.DataBind();
            txt_estado.Text = proyecto[4];
            txt_salario.Text = proyecto[5];
            ddl_pago.SelectedValue = proyecto[6];
        }

        public void cargarTareas() 
        {
            //Cargar las tareas
            JProyecto.Proyecto pj = new JProyecto.Proyecto();
            int id_proyecto = (int)Session["id_proyecto-mp"];
            String[] tareas = pj.obtenerTareas(id_proyecto);
            Session["tareas-mp"] = tareas;

            //Armar la tabla
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id");
            tabla.Columns.Add("Nombre");
            for (int i = 0; i < tareas.Length; i++)
            {
                DataRow fila = tabla.NewRow();
                fila["Id"] = tareas[i].Split(';')[0];
                fila["Nombre"] = tareas[i].Split(';')[1];
                tabla.Rows.Add(fila);
            }
            gv_tablaTareas.DataSource = tabla;
            gv_tablaTareas.DataBind();
        }

        protected void gv_tablaTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gv_tablaTareas.SelectedIndex;
            DataTable dt = (DataTable) gv_tablaTareas.DataSource;
            DataRow fila = dt.Rows[index];
            int id_tarea = Convert.ToInt32(fila["Id"]);
            Session["id_tarea-mt"] = id_tarea;
            Response.Redirect("ModificarTarea");
        }

        protected void btn_publicar_Click(object sender, EventArgs e)
        {
            JProyecto.Proyecto p = new JProyecto.Proyecto();
            p.cambiarEstado((int)Session["id_proyecto-mp"], "Activo");
            Session["id_proyecto-mp"] = null;
            Response.Redirect("TimeLine.aspx");
        }

    }
}