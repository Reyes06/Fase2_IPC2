using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WarlockSoft
{
    public partial class NuevoProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Llenar el dropdownlist pago
            if (ddl_pago.Items.Count == 0)
            {
                llenarDDL_pago();
            }
        }
        protected void btn_crearProyecto_Click(object sender, EventArgs e)
        {
            JProyecto.Proyecto pj = new JProyecto.Proyecto();
            DateTime fIni = calendar_inicio.SelectedDate;
            DateTime fFin = calendar_fin.SelectedDate;
            pj.agregarProyecto(txt_nombre.Text, fIni.Day, fIni.Month, fIni.Year, fFin.Day, fFin.Month, fFin.Year, "Borrador", Convert.ToDouble(txt_salario.Text), ddl_pago.SelectedItem.ToString(), Convert.ToInt32((String)Session["id_usuario"]));
            Response.Redirect("TimeLine.aspx");
        }

        protected void llenarDDL_pago(){
            ddl_pago.Items.Add("Anual");
            ddl_pago.Items.Add("Mensual");
            ddl_pago.Items.Add("Quincenal");
        }
    }
}