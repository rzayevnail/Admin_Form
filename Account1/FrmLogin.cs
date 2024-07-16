using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ubiety.Dns.Core.Records;
namespace Account1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=NAILRZAYEV\\MSSQLSERVER01;Initial Catalog=Aycicegi;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into Login values(@Name,@Password)", sql);
            cmd.Parameters.AddWithValue("@Name", TxtUser.Text);
            cmd.Parameters.AddWithValue("@Password", TxtPassword.Text);
            cmd.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Passed Away");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TxtUser.Clear();
            TxtPassword.Clear();
            TxtUser.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
