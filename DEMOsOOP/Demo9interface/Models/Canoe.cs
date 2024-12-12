using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9interface.Models
{
    internal class Canoe : IBateau
    {
        public bool EstCoule { get; set; }


        public void Couler()
        {
            if (!EstCoule)
            {
                Console.WriteLine("Zut un trou dans mon canoe!");
                EstCoule = true;
            }
        }

        public void Naviguer()
        {
            Console.WriteLine("Je navigue dans mon canoe");
        }



    }
}
