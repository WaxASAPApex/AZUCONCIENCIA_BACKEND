using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Alta_Experiencia : System.Web.UI.Page
    {

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string SQLInsert;
            SqlConnection SQLCon = new SqlConnection("Data Source=LAPTOP-2UD2SPOU\\SQLEXPRESS; Initial Catalog=azuconciencia; Integrated Security=True");
            SqlCommand SQLCmd = new SqlCommand();

            using (SQLCon)
            {
                SQLCon.Open();//Abre la base de datos ut
                SQLCmd.Connection = SQLCon;
                string fecha, titulo, comentario, paciente;


                fecha = tbFecha.Text;
                titulo = tbtitulo.Text;
                comentario = tbcom.Text;
                paciente = ddlpaciente.Text;


                SQLInsert = String.Format("INSERT INTO Experiencias (PacienteID,Descripcion,Fecha)" +
                    "Values ('{0}','{1}','{2}')", paciente,comentario,fecha);

                SQLCmd.CommandText = SQLInsert;
                SQLCmd.ExecuteNonQuery();

                string script = "alert('Experiencia Registrada Correctamente');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                SQLCon.Close();

                tbFecha.Text = "";
                tbtitulo.Text = "";
                tbcom.Text = "";

            }
        }
    }
}