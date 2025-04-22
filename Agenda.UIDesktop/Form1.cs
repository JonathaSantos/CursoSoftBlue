
using Microsoft.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
         

            //string slqConsulta = $"select Nome from Contato where Id = '{idContato}'";

            //cmd = new SqlCommand(slqConsulta, con);

            //txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            //con.Close();

        }
    }
}
