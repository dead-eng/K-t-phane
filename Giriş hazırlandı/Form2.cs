using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kutuphane_v2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kutuphane.mdb");

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "SELECT * FROM users";
            OleDbCommand cmd = new OleDbCommand(sql, conn); 
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();

            if (rd["user_name"].ToString() == textBox1.Text && rd["pass"].ToString()==textBox2.Text)
            {
                MessageBox.Show("başarılı");
                Form1 fr = new Form1();
                this.Hide();
                fr.ShowDialog();
            }

            else
            {
                MessageBox.Show("hatalı");
            }

            conn.Close();

        }
    }
}
