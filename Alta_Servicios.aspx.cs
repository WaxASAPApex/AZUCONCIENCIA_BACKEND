using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Alta_Servicios : System.Web.UI.Page
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

                string nombre, descrip,precio;

                nombre = tbnombre.Text;
                descrip = tbdescrip.Text;
                precio = tbprecio.Text;

                SQLInsert = String.Format("INSERT INTO Consultorio (Nombre,Ubicacion,Telefono)" +
                    "Values ('{0}','{1}','{2}')", nombre, descrip, precio);

                SQLCmd.CommandText = SQLInsert;
                SQLCmd.ExecuteNonQuery();

                string script = "alert('Consultorio Registrado Correctamente');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                SQLCon.Close();

                tbnombre.Text = "";
                tbdescrip.Text = "";
                tbprecio.Text = "";

            }
        }
    }
}