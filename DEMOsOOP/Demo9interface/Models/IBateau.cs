using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9interface.Models
{
    internal interface IBateau : ICouler //Here IBateau becomes the child of ICouler
    {
        public void Naviguer();
    }
}
