using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo08Abstract.Models
{
    public sealed class Chat : Animal  //we seal this so that nobody can create an infant from the class (which causes problems with tiger)
    {
        public override void Crier()
        {
            Console.WriteLine("meow!");
        }

    }
}
