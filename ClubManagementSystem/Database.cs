using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ClubManagementSystem
{
    class Database
    {
        public PinfoDataContext con;
        public ProfileInfo p = new ProfileInfo();
        public ClubTable c = new ClubTable();
 
        public Database()
        {

            con = new PinfoDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Desktop\Project\ClubManagementSystem\ClubDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            
        }

        public void PersonInsert(string name, string password, string Rank, string phone, string Email,string club)
        {

            int intIdt = con.ProfileInfos.Max(u => u.Id) + 1;

            p.Id = intIdt;
          
                p.Name = name;
            
                p.Club = club;
                p.Rank = Rank;
                p.Email = Email;
                p.Phone = phone;
                p.Password = password;

               con.ProfileInfos.InsertOnSubmit(p);
                con.SubmitChanges();
                MessageBox.Show("Your Id is " + intIdt + " Remember it for further Login.");
            
            

         }

        public void clubInsert(string club)
        {
            int intIdt = con.ClubTables.Max(u => u.Id) + 1;

            c.Id = intIdt;
            c.club = club;
            con.ClubTables.InsertOnSubmit(c);
            con.SubmitChanges();
            MessageBox.Show("Added Confirm");
        }

        public void ProfileDelete(string value)
        {
            try
            {
                var str = from a in con.ProfileInfos
                          where a.Id == Int32.Parse(value)
                          select a;


                ProfileInfo pp = str.First();
                con.ProfileInfos.DeleteOnSubmit(pp);
                con.SubmitChanges();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Select a row for delete");
            }
     
        }

        public void ProfileSearch(string id)
        {
            
          
        }

    }
}