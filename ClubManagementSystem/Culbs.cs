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
    public partial class Culbs : Form
    {
        Student s= new Student() ;
        public Culbs()
        {
            InitializeComponent();
          
        }
        public Culbs(int Id,string club)
        {
            InitializeComponent();
        }

        private void Culbs_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
