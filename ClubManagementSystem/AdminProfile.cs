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
    public partial class AdminProfile : Form
    {
        public string myvalue;
        Activity ac = new Activity();
        Database d = new Database();
        EProfile p;
        public AdminProfile()
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
            //GetData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            this.Hide();
        }

        private void AdminProfile_Load(object sender, EventArgs e)
        {

            GetData();
        }
        public void GetData()
        {
            dataGridView1.DataSource = d.con.ProfileInfos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {

                //dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                //Works even when whole row is selected.
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                //You can also then easily get column names / values on that selected row
                string product_id = dataGridView1.Rows[rowIndex].Cells["Id"].Value.ToString();

                //Do additional logic

                //Remove from datagridview.
                dataGridView1.Rows.RemoveAt(rowIndex);
                myvalue = product_id;



            }

            d.ProfileDelete(myvalue);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PinfoDataContext con = new PinfoDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Desktop\Project\ClubManagementSystem\ClubDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            var str = from a in con.ProfileInfos
                      select a;
            ProfileInfo s = str.Where(obj => obj.Id == Int32.Parse(textBox1.Text)).First();

            dataGridView1.DataSource = str.Where(obj => obj.Id == Int32.Parse(textBox1.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
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
                ac.Activities = richTextBox1.Text;
                ac.Name = pp.Name;
                ac.Grade = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                ac.Club = pp.Club;

                if (pp.Rank == "President")
                {
                    d.con.Activities.InsertOnSubmit(ac);
                    d.con.SubmitChanges();
                    MessageBox.Show("Confirmed");
                    GetData();
                }
                else
                {
                    d.con.SubmitChanges();
                    MessageBox.Show("Update Confirmed");
                    GetData();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("You can just update this account");
            }




        }

        private void button7_Click(object sender, EventArgs e)
        {
            Eclub c = new Eclub(textBox2.Text);

            c.Insert();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ExcilentStudent es = new ExcilentStudent();
            es.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
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

                if (p.Rank == "Admin")
                {
                    MessageBox.Show("you do not able to update this profile");
                }
                else
                {
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
                MessageBox.Show("You have to give a grade or activities first!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
