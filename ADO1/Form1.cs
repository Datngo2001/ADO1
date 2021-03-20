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

namespace ADO1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void GetTable(string strSQL)
        {
            string strCon = "Data Source=LAPTOP-CGKU0T3D;Initial Catalog=SinhVien;Integrated Security=True";
            listView1.Clear();
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = strCon;
            SqlCommand Com = new SqlCommand(strSQL, Con);
            listView1.Columns.Add("First Name", 70, 0);
            listView1.Columns.Add("Last Name", 150, 0);
            listView1.Columns.Add("Position", 200, 0);
            listView1.View = View.Details;
            ListViewItem item1;
            try
            {
                Con.Open();
                SqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    item1 = new ListViewItem(dr[1].ToString());
                    item1.SubItems.Add(dr[2].ToString());
                    item1.SubItems.Add(dr[3].ToString());
                    item1.SubItems.Add(dr[4].ToString());
                    listView1.Items.Add(item1);
                }
                dr.Close();
                dr.Dispose();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); 
                if (Con.State != ConnectionState.Closed)
                {
                    Con.Close();
                }
                throw;
            }
            finally
            {
                Con.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SQL = "SELECT * FROM Students_info";
            GetTable(SQL);
        }
    }
}
