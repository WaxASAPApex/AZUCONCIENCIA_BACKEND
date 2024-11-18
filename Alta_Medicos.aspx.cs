using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace AZUCONCIENCIA_02
{
    public partial class Alta_Medicos : System.Web.UI.Page
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

                string nombre,Apellido, correo, tel, especialidad;


                nombre = tbNombre.Text;
             
                Apellido = tbApellidos.Text;
          
                correo = tbCorreo.Text;
                tel = tbTel.Text;

                especialidad = tbespecialidad.Text;

                SQLInsert = String.Format("INSERT INTO Medicos (Nombre,Apellido,Especialidad,Correo,Telefono)" +
                    "Values ('{0}','{1}','{2}','{3}','{4}')", nombre,Apellido, especialidad,correo, tel);

                SQLCmd.CommandText = SQLInsert;
                SQLCmd.ExecuteNonQuery();

                string script = "alert('Medico Registrado Correctamente');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                SQLCon.Close();

                tbNombre.Text = "";
               
                tbApellidos.Text = "";
                tbespecialidad.Text = "";
               
                tbCorreo.Text = "";
                tbTel.Text = "";
            }
        }

        protected void btndubir_Click(object sender, EventArgs e)
        {
            if (flarchivo.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(flarchivo.FileName);
                    flarchivo.SaveAs("D:\\TITULO PROFECIONAL\\" + flarchivo.FileName);
                    Response.Redirect("index.html");
                }
                catch (Exception ex)
                {
                    lbEstatus.Text = "Error el archivo: " + ex.Message;
                }
            }
        }
    }
}