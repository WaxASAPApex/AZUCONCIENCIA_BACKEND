using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Autenticacion_Medicos : System.Web.UI.Page
    {
        protected void btnInisiar_Click(object sender, EventArgs e)
        {

            if (tbUsuario.Text != "")
            {
                //declaro dos variables para tomar la información ingresada por el uusario
                string Usuario;
                Usuario =tbUsuario.Text;
                //Instanciar Objeto para el acceso al Dataset (BD)
                azuconcienciaTableAdapters.Medicos1TableAdapter medicos = new azuconcienciaTableAdapters.Medicos1TableAdapter();
                //Instanciar Objeto para el acceso a la tabla de usuarios (método get data = consulta que creamos)
                azuconciencia.Medicos1DataTable dtloguin = medicos.GetData(Usuario);
                // si encontro el ada y la contraseña, se toma como resultado un registro y se evalúa si al menos
                //un registro se encontro, entonces me das el acceso, sino me lo niegas
                int canRegistros = dtloguin.Count;
                if (canRegistros <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "javascript:alert('ID Incorrecto');",
                    true);
                }
                else
                {
                    // si si, encontro el ada y contraseña me va a redireccionar el formulario que lo le indique
                    //generalmente a un menu principal, como no tengo ahorita, lo mande a mi formulario Alta_Alumnos.aspx
                    Response.Redirect("Alta_Servicios.aspx");
                }
            }//FIN IF PRINCIPAL
            

            Response.Redirect("Opciones.aspx");
        }

    
    }
}
