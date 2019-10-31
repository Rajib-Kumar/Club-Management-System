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
   
    public partial class ExcilentStudent : Form
    {
        Database d = new Database();
        public ExcilentStudent()
        {
            InitializeComponent();
            GetData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void GetData()
        {
            try
            {
                var str2 = from a in d.con.Activities

                           where a.Grade == "Excellent" 
                           select a;

                Activity p = str2.First();

                dataGridView1.DataSource = str2.Where(obj => obj.Grade == "Excellent");
            }
            catch(Exception ee)
            {
                MessageBox.Show("No Excellent Students Yet!!");
            }
           
        }

        private void back_Click(object sender, EventArgs e)
        {
            AdminProfile a = new AdminProfile();
            a.Show();
            this.Hide();
        }
    }
}
