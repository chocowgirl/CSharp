using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9interface.Models
{
    internal interface ICouler
    {
        public bool EstCoule { get; }
        public void Couler();
    }
}
