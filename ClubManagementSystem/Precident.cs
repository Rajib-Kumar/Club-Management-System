using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubManagementSystem
{
    
    public partial class Precident : Form
    {
        Activity ac = new Activity();
        Database d = new Database();
        public Precident()
        {
            InitializeComponent();
              comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            var items = new[] { 
                  new{ Text = "Good", Value = "Good" },
                    new { Text = "Very Good", Value = "Very Good" },
                     new{ Text = "Excellent", Value = "Excellent" }
                };
            comboBox1.DataSource = items;
            GetData();
           
                 
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void GetData()
        {
            dataGridView1.DataSource = d.con.Activities;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Precident_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var str = from a in d.con.ProfileInfos
                          where a.Id == Int32.Parse(textBox1.Text)
                          select a;

                ProfileInfo pp = str.First();
                ac.Id = Int32.Parse(textBox1.Text);


                ac.Name = pp.Name;
                ac.Grade = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                ac.Club = pp.Club;

                d.con.Activities.InsertOnSubmit(ac);
                d.con.SubmitChanges();
                MessageBox.Show("Confirmed");
                GetData();
            }
            catch(Exception ee)
            {
                MessageBox.Show("You can only update this profile and you must have to select an id");
            }
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var str = from a in d.con.Activities
                          where a.Id == Int32.Parse(textBox1.Text)
                          select a;
                var str2 = from a in d.con.ProfileInfos
                           from b in d.con.Activities
                          where a.Id == Int32.Parse(textBox1.Text) && a.Id == b.Id
                          
                          select a;
                ProfileInfo p = str2.First();
             
                if(p.Rank == "Admin" || p.Rank == "President")
                {
                    MessageBox.Show("you do not able to update this profile");
                }
                else{
                    Activity s = str.First();

                    s.Grade = comboBox1.GetItemText(this.comboBox1.SelectedItem);

                    if (s.Activities != null)
                    {
                        s.Activities = s.Activities + " , " + richTextBox1.Text;
                    }
                    else
                    {
                        s.Activities = richTextBox1.Text;
                    }


                    d.con.SubmitChanges();
                    MessageBox.Show("profile updated!!");
                    GetData();
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("please select an id");
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PinfoDataContext con = new PinfoDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Desktop\Project\ClubManagementSystem\ClubDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            var str = from a in con.ProfileInfos
                      select a;
            ProfileInfo s = str.Where(obj => obj.Id == Int32.Parse(textBox1.Text)).First();

            dataGridView1.DataSource = str.Where(obj => obj.Id == Int32.Parse(textBox1.Text));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
