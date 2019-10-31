using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementSystem
{
    class EProfile
    {

        Database d = new Database();
        public string name;
        public string id;
        public string rank;
        public string phone;
        public string email;
        public string Club;
        public string password;

        public EProfile(string name,string password,string rank,string phone,string email,string club)
        {
            this.name = name;
 
            this.rank = rank;
            this.email = email;
            this.phone = phone;
            this.Club = club;
            this.password = password;
        }


        public void Insert()
        {
            d.PersonInsert(name, password, rank, phone,email,Club);
        }

    }
}
