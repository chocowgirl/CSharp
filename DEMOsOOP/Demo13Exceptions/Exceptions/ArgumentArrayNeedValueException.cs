using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo13Exceptions.Exceptions
{
    internal class ArgumentArrayNeedValueException : ArgumentOutOfRangeException
    {
        //if we go no further this is an exception and will use the constructor of it's parent.

        public int MinValueRequired { get; private set; }

        public int CurrentQuantityValues {  get; private set; }

        //constructor here below
        public ArgumentArrayNeedValueException(int minValue, int currentQtyValue) : this (minValue, currentQtyValue, "unknown argument")
        {
            //MinValueRequired = minValue;
            //CurrentQuantityValues = currentQtyValue;
        }

        //overloading the constructor
        public ArgumentArrayNeedValueException(int minValue, int currentQtyValue, string parameterName) : this(minValue, currentQtyValue, parameterName, "La qty de valeur du tableau n'est pas suffisante pour le traiter")  // here we pass the job to (another constructor, the one with the number of parameters that appear after the 'this')
        {
            //MinValueRequired = minValue;
            //CurrentQuantityValues = currentQtyValue;
        }

        //overloading for 4 parameters
        public ArgumentArrayNeedValueException(int minValue, int currentQtyValue, string parameterName, string message) : base(parameterName, message)
        {
            MinValueRequired = minValue;
            CurrentQuantityValues = currentQtyValue;
        }
    }
}
