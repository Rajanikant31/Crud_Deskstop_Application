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

namespace Crud_Deskstop_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LKTB3BK;Initial Catalog=Student_desk;User ID=sa;Password=admin123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into student values('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + Convert.ToInt64(textBox4.Text) + "', '" + textBox5.Text + "','" + textBox6.Text + "', '" + maskedTextBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Insertion Success..");
            reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LKTB3BK;Initial Catalog=Student_desk;User ID=sa;Password=admin123");
            con.Open();
            SqlDataAdapter dat = new SqlDataAdapter("select * from student", con);
            DataSet ds = new DataSet();
            dat.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LKTB3BK;Initial Catalog=Student_desk;User ID=sa;Password=admin123");
            con.Open();
            SqlCommand cmd = new SqlCommand("update student set Student_name=@Student_name,Address=@Address, Contact_no=@Contact_no,Email_id=@Email_id,Course=@Course, DOB=@DOB where Student_id='"+textBox1.Text+"'",con);
            cmd.Parameters.AddWithValue("@Student_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact_no", textBox4.Text);
            cmd.Parameters.AddWithValue("@Email_id", textBox5.Text);
            cmd.Parameters.AddWithValue("@Course", textBox6.Text);
            cmd.Parameters.AddWithValue("@DOB", maskedTextBox1.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Records updated");
            reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LKTB3BK;Initial Catalog=Student_desk;User ID=sa;Password=admin123");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from student where Student_id= '" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record delted Successfully..");
            reset();
        }
        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            reset();

        }
    }
}
