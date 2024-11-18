using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Baja_Citas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnborrar_Click(object sender, EventArgs e)
        {
            int id_Cita;
            id_Cita = int.Parse(tbCitas.Text);
            azuconcienciaTableAdapters.MedicosTableAdapter taId = new azuconcienciaTableAdapters.MedicosTableAdapter();
            taId.Delete(id_Cita);
            Response.Redirect("Consulta_Citas.aspx");
        }
    }
}