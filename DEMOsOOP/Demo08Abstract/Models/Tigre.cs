using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo08Abstract.Models
{
    public class Tigre : Animal
    {
        public override void Crier()
        {
            //base.Crier(); // can't use this anymore since chat is sealed so we have to do the below to use Crier() from the abstract method in Animal
            Console.WriteLine("Grrr ");
            Console.WriteLine("je suis une tigre");
        }


    }
}
