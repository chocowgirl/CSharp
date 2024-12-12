using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9Interfaces.Models
{
    internal class Canoe : IBateau
    {
        public void Naviguer()
        {
            Console.WriteLine("Je navigue a bord de mon canoe");
        }
    }
}
