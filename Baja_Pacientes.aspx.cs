using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Baja_Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnborrar_Click(object sender, EventArgs e)
        {
            int Id_Paciente;
            Id_Paciente = int.Parse(tbPaciente.Text);
            azuconcienciaTableAdapters.PacientesTableAdapter taId = new azuconcienciaTableAdapters.PacientesTableAdapter();
            taId.Delete(Id_Paciente);
            Response.Redirect("Consulta_Pacientes.aspx");
        }
    }
}