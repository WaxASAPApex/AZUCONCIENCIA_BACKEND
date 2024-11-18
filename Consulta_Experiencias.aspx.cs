using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AZUCONCIENCIA_02
{
    public partial class Consulta_Experiencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreaExp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Alta_Experiencia.aspx");
        }
    }
}