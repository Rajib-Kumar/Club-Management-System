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
    public partial class Student : Form
    {
        public int ID;
        public Student()
        { }
        public Student(string Id)
        {
            Database d = new Database();
            InitializeComponent();
     
            int id = Int32.Parse(Id);
            this.ID = id;
            try
            {
                var str = from a in d.con.ProfileInfos
                          where a.Id == id
                          select a;

                ProfileInfo p = str.First();
                label7.Text = p.Name;
                label8.Text = Id;
                label9.Text = p.Rank;
                label10.Text = p.Club;
                label11.Text = p.Email;
                label12.Text = p.Phone;

                var str1 = from a in d.con.Activities
                           where a.Id == id
                           select a;

                Activity ac = str1.First();

                label15.Text = ac.Grade;
            }
            catch (Exception ee)
            {
                MessageBox.Show("This student is not assign yet");
            }

         
          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

       
    }
}
