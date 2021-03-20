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

namespace ADO1._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strCon = "Data Source=LAPTOP-CGKU0T3D;Initial Catalog=SinhVien;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strCon);
            try
            {
                // mở kết nối
                conn.Open();
                //richTextBox1.Text = "Connection opened" + 
                //    "\n Connection Properties:"+
                //    "\n \t " + conn.ConnectionString +
                //    "\n \t" + conn.Database +
                //    "\n \t" + conn.DataSource +
                //    "\n \t" + conn. State +
                //    "\n \t" + conn.WorkstationId;

                //SqlCommand command = new SqlCommand();
                //command.Connection = conn;
                //command.CommandText = @"SELECT COUNT(*) FROM Students_info";
                //richTextBox1.Text = "Connection opened" +
                //    "\nKết quả sớ lượng sinh viên:" 
                //    "\n \t " + command.ExecuteScalar();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM Students_info";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    richTextBox1.Text += "\n Kết quả: " + '\t' + reader[0].ToString() + '\t' + reader[1].ToString();
                }
                reader.Close();
                
            }
            catch (SqlException ex)
            {
                // bảo lỗi
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                label1.Text = "Connection closed";
            }
            // đông kết non 
            conn.Close();
        }
    }
}
