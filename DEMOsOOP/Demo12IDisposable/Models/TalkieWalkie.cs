using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo12IDisposable.Models
{
    internal class TalkieWalkie : IDisposable
    {
        public string UserName { get; set; }

        public TalkieWalkie(string userName) {
            UserName = userName;
        }

        public void EmmetreMessage(string message)
        {
            Console.WriteLine($"{UserName} {DateTime.Now.ToShortTimeString()} : {message}");
            Console.WriteLine("à vous!");
        }

        public void Dispose()
        {
            Console.WriteLine($"C'était {UserName} : terminé!  {DateTime.Now.ToShortTimeString()}");
        }


    }
}
