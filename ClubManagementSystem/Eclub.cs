using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementSystem
{
    class Eclub
    {
        Database d = new Database();

        public string club;
        public Eclub(string club)
        {

            this.club = club;
        }

        public void Insert()
        {
            d.clubInsert(club);
        }
     
    }
}
