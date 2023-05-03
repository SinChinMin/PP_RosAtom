using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Construction_company_programm
{
    public partial class Client
    {
        public override string ToString()
        {
            return C_Name;
        }
    }
    public partial class Сontractors
    {
        public override string ToString()
        {
            return Co_Name;
        }
    }
    public partial class Type_Reactor
    {
        public override string ToString()
        {
            return Tr_Name;
        }
    }
}
