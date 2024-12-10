using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo08Abstract.Models
{
    public class Souris : Animal
    {
        public override void Crier()
        {
            Console.WriteLine("kuin kuin!"); ;
        }
    }
}
