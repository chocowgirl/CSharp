using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo20Genericite02.Models
{
    public class Barraque : Usine<Soldat> // a Barraque is defined as a Usine QUE à soldats
    {
        public Soldat CreerSoldat()
        {
            return Produire<Soldat>();
        }

        public Officier CreerOfficier()
        {
            return Produire<Officier>();
        }

    }
}
