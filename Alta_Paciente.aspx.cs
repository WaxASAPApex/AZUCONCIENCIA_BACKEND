using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Alta_Paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string SQLInsert;
            SqlConnection SQLCon = new SqlConnection("Data Source=LAPTOP-2UD2SPOU\\SQLEXPRESS; Initial Catalog=azuconciencia; Integrated Security=True");
            SqlCommand SQLCmd = new SqlCommand();

            using (SQLCon)
            {
                SQLCon.Open();//Abre la base de datos ut
                SQLCmd.Connection = SQLCon;

                string nombre, apellidos, correo, tel,FechaNac,Sexo;
                
                nombre = tbNombre.Text;
                apellidos = tbApelldios.Text;
                FechaNac = tbFecha.Text; 
                Sexo = rblSexo.Text;
                correo = tbCorreo.Text;
                tel = tbTel.Text;

                SQLInsert = String.Format("INSERT INTO Pacientes (Nombre,Apellidos,FechaNacimiento,Genero,Correo,Telefono)" +
                    "Values ('{0}','{1}','{2}','{3}','{4}','{5}')", nombre,apellidos,FechaNac ,Sexo, correo, tel);

                SQLCmd.CommandText = SQLInsert;
                SQLCmd.ExecuteNonQuery();

                string script = "alert('Paciente Registrado Correctamente');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                SQLCon.Close();

                tbNombre.Text = "";
                tbApelldios.Text = "";
                tbFecha.Text = "";
                tbCorreo.Text = "";
                tbTel.Text = "";
            }
        }
    }
}