using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Modificar_Paciente : System.Web.UI.Page
    {
        public static int Pacientes;
        protected void Page_Load(object sender, EventArgs e)
        {
            tbDatos.Visible = false;
            tbbotones.Visible = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (tbPaciente.Text != "")
            {
                 Pacientes= int.Parse(tbPaciente.Text);
                azuconcienciaTableAdapters.PacientesTableAdapter tapacientes = new azuconcienciaTableAdapters.PacientesTableAdapter();
                azuconciencia.PacientesDataTable dtPaciente = tapacientes.GetData(Pacientes);
                int total_registros = dtPaciente.Count;

                if (total_registros > 0)
                {
                    azuconciencia.PacientesRow RowRegistro = dtPaciente[0];

                    tbNombre.Text = RowRegistro.Nombre;
                    tbApelldios.Text = RowRegistro.Apellidos;
                    tbFecha.Text = RowRegistro.FechaNacimiento;
                    tbCorreo.Text = RowRegistro.Correo;
                    tbTel.Text = RowRegistro.Telefono;
                    rblSexo.Text = RowRegistro.Genero;


                    tbDatos.Visible = true;
                    tbbotones.Visible = true;
                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "javascript:alert('No se encontro el ID del Paciente  a modificar');", true);
                }

            }

            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "javascript:alert('Campo Vacío');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre,Fecha,apellido, correo, tel,Genero;
            
            nombre = tbNombre.Text;
            apellido = tbApelldios.Text;
            Fecha = tbFecha.Text;
            correo = tbCorreo.Text;
            tel = tbTel.Text;
            Genero = rblSexo.Text.ToString();

            azuconcienciaTableAdapters.PacientesTableAdapter taPaci = new azuconcienciaTableAdapters.PacientesTableAdapter();

            taPaci.Update(nombre, apellido,Fecha,Genero,correo, tel, Pacientes);

            string script = "alert('Paciente modificado correctamente'); window.location='" + Request.ApplicationPath + "Modificar_Paciente.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", script, true);

        }
    }
}