using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoCelFarStructs25Nov2024
{
    public struct Celsius
    {
        public double temperature;
        public Fahrenheit Convert()
        {
            Fahrenheit f = new Fahrenheit();
            f.temperature = temperature * 9 / 5 + 32;
            Console.WriteLine($"{temperature} degrees Celsius equals {f.temperature} degrees Fahrenheit.");
            return f;
        }
    }
    
    
    public struct Fahrenheit
    {
        public double temperature;
        public Celsius Convert()
        {
            return new Celsius() { temperature = (temperature - 32) * ((double)5 / 9) };
        }

    }
}
