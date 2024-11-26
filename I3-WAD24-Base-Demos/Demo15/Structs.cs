using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo15
{
    public struct ToolBox
    {
        public void WriteVertically(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;//La meilleur solution serait d'utiliser des exceptions (try-catch) qu'on verra en OOP
            }
            char[] chars = message.ToCharArray();
            //foreach (char c in chars)
            //{
            //    Console.WriteLine(c);
            //}
            WriteVertically(chars);
        }

        public void WriteVertically(char[] message)
        {
            if (message is null || message.Length == 0 || CharArrayContainsOnlyWhiteSpace(message))
            {
                return; // again here preferable to use try catch but we will see this in OOP
            }
            foreach (char c in message)
            {
                Console.WriteLine(c);
            }
        }

        public bool CharArrayContainsOnlyWhiteSpace(char[] array)
        {
            foreach (char c in array)
            {
                if (!char.IsWhiteSpace(c) && c != '\0')
                {
                    return false;
                }
            }
            return true;

        }





    }
}
