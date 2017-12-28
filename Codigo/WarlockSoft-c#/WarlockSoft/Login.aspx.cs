using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarlockSoft
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_usuario"] =null;
            Session["nombre"] = null;
            Session["correo"] = null;
            Session["fecha"] = null;
            Session["password"] = null;
            Session["nickname"] = null;
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            JUsuario.Usuario usuario = new JUsuario.Usuario();
            bool validacion = usuario.validarUsuario(nickname.Text, password.Text);
            if (validacion)
            {
                String[] datos = usuario.obtenerDatosUsuario(nickname.Text, password.Text);
                Session["id_usuario"] = datos[0];
                Session["nombre"] = datos[1];
                Session["correo"] = datos[2];
                Session["fecha"] = datos[3];
                Session["password"] = datos[4];
                Session["nickname"] = datos[5];
                Response.Redirect("Profile.aspx");
            }
            else
            {
                mensaje.Text = "Vete de aqui intruso!";
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            JUsuario.Usuario usu = new JUsuario.Usuario();
            if (usu.agregarUsuario(txt_nombre1.Text, txt_correo1.Text, cal_fecha.SelectedDate.Day, cal_fecha.SelectedDate.Month, cal_fecha.SelectedDate.Year, txt_password1.Text, txt_nickname1.Text))
            {
                mensaje.Text = "Bienvenido :D";
                String[] datos = usu.obtenerDatosUsuario(txt_nickname1.Text, txt_password1.Text);
                Session["id_usuario"] = datos[0];
                Session["nombre"] = datos[1];
                Session["correo"] = datos[2];
                Session["fecha"] = datos[3];
                Session["password"] = datos[4];
                Session["nickname"] = datos[5];
                Response.Redirect("Profile.aspx");
            }
            else
            {
                mensaje.Text = "Lo siento, aglo ha fallado";
            }
        }
    }
}