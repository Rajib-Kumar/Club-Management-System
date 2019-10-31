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
    public partial class Registration : Form
    {
      
        public ClubTable c = new ClubTable();
       
        public Registration()
        {
            InitializeComponent();
            //comboBox1.DisplayMember = "Text";
            //comboBox1.ValueMember = "Value";
            string Sql = "select club from ClubTable";
            string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Desktop\Project\ClubManagementSystem\ClubDatabase.mdf;Integrated Security=True;Connect Timeout=30";
             SqlConnection conn = new SqlConnection(connString);
        
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
            //comboBox1.DataSource = items;
            comboBox2.ValueMember = "Value";
            var items2 = new[] { 
                     new{ Text = "Admin", Value = "Admin" },
                    new { Text = "President", Value = "President" },
                    new {Text = "Student", Value = "Student"}
                };
            comboBox2.DataSource = items2;
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rank = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            string club = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            try
            {
                EProfile p = new EProfile(textBox1.Text, textBox6.Text, rank, textBox3.Text,textBox4.Text,club);

                p.Insert();
                MessageBox.Show("Registration Complete");

               
            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR!!!");
            }
           

           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminProfile a = new AdminProfile();
            a.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
