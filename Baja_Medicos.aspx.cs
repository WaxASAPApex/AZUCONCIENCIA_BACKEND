using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Baja_Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnborrar_Click(object sender, EventArgs e)
        {
           int contrasena_Medico;
            contrasena_Medico = int.Parse(tbCitas.Text);
            azuconcienciaTableAdapters.MedicosTableAdapter taId = new azuconcienciaTableAdapters.MedicosTableAdapter();
            taId.Delete(contrasena_Medico);
            Response.Redirect("Consulta_Medicos.aspx");

        }
    }
}