using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csaa_jo
{
    internal class Dolgozok
    {
        public int userid;
        public string firstname;
        public string lastname;

        public Dolgozok(int userid, string firstname, string lastname)
        {
            this.userid = userid;
            this.firstname = firstname;
            this.lastname = lastname;
        }
    }
}
