using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using objWord = Microsoft.Office.Interop.Word;
namespace AZUCONCIENCIA_02
{
    public partial class Alta_Citas : System.Web.UI.Page
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

                string fecha, paciente, medico, asunto,Consultorio;
                 

                fecha = tbFecha.Text;
                paciente = ddlpaciente.Text;
                medico = ddlmedico.Text;
                asunto=tbAsunto.Text;
                Consultorio= ddlConsultorio.Text;

                SQLInsert = String.Format("INSERT INTO Citas (PacienteID,MedicoID,ConsultorioID,FechaHora,Motivo)" +
                    "Values ('{0}','{1}','{2}','{3}','{4}')", paciente,medico, Consultorio,fecha,asunto);

                SQLCmd.CommandText = SQLInsert;
                SQLCmd.ExecuteNonQuery();

                string script = "alert('Cita Registrada Correctamente');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                SQLCon.Close();

                
             
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string fecha, paciente, medico, asunto, Consultorio;


            fecha = tbFecha.Text;
            paciente = ddlpaciente.Text;
            medico = ddlmedico.Text;
            asunto = tbAsunto.Text;
            Consultorio = ddlConsultorio.Text;

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            objWord.Application objAplication = new objWord.Application();
            objWord.Document objDocumento = objAplication.Documents.Add();

            objWord.Paragraph objParrafo1 = objDocumento.Content.Paragraphs.Add(Type.Missing);
            objParrafo1.Range.Font.Size = 14;
            objParrafo1.Range.Font.Color = objWord.WdColor.wdColorBlack;
            objParrafo1.Range.Text = "Fecha: " + fecha;
            objParrafo1.Range.InsertParagraphAfter();

            objWord.Paragraph objParrafo2 = objDocumento.Content.Paragraphs.Add(Type.Missing);
            objParrafo2.Range.Font.Size = 14;
            objParrafo2.Range.Font.Color = objWord.WdColor.wdColorBlack;
            objParrafo2.Range.Text = "Paciente: " + paciente + "      Medico:  " + medico;
            objParrafo2.Range.InsertParagraphAfter();

            objWord.Paragraph objParrafo3 = objDocumento.Content.Paragraphs.Add(Type.Missing);
            objParrafo3.Range.Font.Size = 14;
            objParrafo3.Range.Font.Color = objWord.WdColor.wdColorBlack;
            objParrafo3.Range.Text = "Asunto: " + asunto;
            objParrafo3.Range.InsertParagraphAfter();

            objWord.Paragraph objParrafo4 = objDocumento.Content.Paragraphs.Add(Type.Missing);
            objParrafo4.Range.Font.Size = 14;
            objParrafo4.Range.Font.Color = objWord.WdColor.wdColorBlack;
            objParrafo4.Range.Text = "Consultorio: " + Consultorio;
            objParrafo4.Range.InsertParagraphAfter();

            objDocumento.SaveAs2(ruta + "\\Cita_Medica.docx");
            objDocumento.Close();
            objAplication.Quit();
            string script = "alert('Cita generada para imprecion Correctamente');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
                tbFecha.Text = "";
                tbAsunto.Text = "";
        }
    }
}