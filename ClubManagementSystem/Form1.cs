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

namespace ClubManagementSystem
{
    public partial class Form1 : Form
    {
        Database d = new Database();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Desktop\Project\ClubManagementSystem\ClubDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            int intIdt = d.con.ProfileInfos.Max(u => u.Id);
            SqlCommand sql = new SqlCommand("select * from ProfileInfo", con);
            SqlDataReader t = sql.ExecuteReader();
           
            for (int i = 0; i < intIdt; i++)
            {
               
              
                t.Read();

                try
                {
                    if ((Int32.Parse(t[0].ToString())) == Int32.Parse(textBox1.Text) && t[2].ToString() == textBox2.Text && t[3].ToString() == "President")
                    {
                        Precident p = new Precident();
                        p.Show();
                        this.Hide();
                        break;

                    }
                    else if ((Int32.Parse(t[0].ToString())) == Int32.Parse(textBox1.Text) && t[2].ToString() == textBox2.Text && t[3].ToString() == "Admin")
                    {
                        AdminProfile a = new AdminProfile();
                        a.Show();
                        this.Hide();
                        break;
                    }
                    else if ((Int32.Parse(t[0].ToString())) == Int32.Parse(textBox1.Text) && t[2].ToString() == textBox2.Text && t[3].ToString() == "Student")
                    {
                        Student a = new Student(textBox1.Text);
                        a.Show();
                        this.Hide();
                        break;
                    }
                }
                catch(Exception ee)
                {
                    MessageBox.Show("Wrong UserId or Password!! try again");
                }

            
              
              
    
                   
               
           
           }
           
              
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
