using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Modificacion_Medico : System.Web.UI.Page
    {
        public static int Medico;
        protected void Page_Load(object sender, EventArgs e)
        {
            tbdatos.Visible= false;
            tbbotones.Visible= false;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            if (tbMedico.Text != "")
            {
                Medico= int.Parse(tbMedico.Text);
                azuconcienciaTableAdapters.MedicosTableAdapter taMedico = new azuconcienciaTableAdapters.MedicosTableAdapter();
                azuconciencia.MedicosDataTable dtMedico = taMedico.GetData(Medico);
                int total_registros = dtMedico.Count;

                if(total_registros > 0) 
                {
                    azuconciencia.MedicosRow RowRegistro = dtMedico[0];

                    tbNombre.Text = RowRegistro.Nombre;
                    tbApellidos.Text = RowRegistro.Apellido;
                    tbCorreo.Text = RowRegistro.Correo;
                   tbespecialidad.Text=RowRegistro.Especialidad;
                    tbTel.Text= RowRegistro.Telefono;
                    

                    tbdatos.Visible= true;
                    tbbotones.Visible= true;
                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "javascript:alert('No se encontro el ID del Medico  a modificar');", true);
                }

            }

            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "javascript:alert('Campo Vacío');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

                string nombre, apellido, correo, tel, especialidad;
            
                
                nombre = tbNombre.Text;
                apellido = tbApellidos.Text;
                correo = tbCorreo.Text;
                tel = tbTel.Text;
                especialidad = tbespecialidad.Text;

                azuconcienciaTableAdapters.MedicosTableAdapter taMedic = new azuconcienciaTableAdapters.MedicosTableAdapter();

            taMedic.Update (nombre,apellido,correo,tel,especialidad,Medico);

            string script = "alert('Medico modificado correctamente'); window.location='" + Request.ApplicationPath + "Modificacion_Medico.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", script, true);


        }

    }
}