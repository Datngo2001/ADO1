using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ADO1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conStr = "Data Source=LAPTOP-CGKU0T3D;Initial Catalog=SinhVien;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conStr);
            //tạo command
            SqlCommand cmd = new SqlCommand();
            label3.Text = "Command created";
            try
            {
                // mỏ kết nos
                conn.Open(); label1.Text = "Connection opened";
                cmd.Connection = conn;
                label4.Text = "Ket Noi lenh voi Connection hiện tại";
            }
            catch (SqlException ex)
            {
                // báo lỗi
                MessageBox.Show("ERROR!" + ex.Message);
            }
            finally
            {
                //dông kết nối
                conn.Close();
                label2.Text = "Connection closed";
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
