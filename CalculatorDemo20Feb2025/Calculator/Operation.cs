using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Operation
    {
        public double LeftValue {  get; set; }
        public double RightValue { get; set; }

        public OperatorEnum Operator { get; set; }

        public Operation(double leftValue, double rightValue, OperatorEnum @operator)
        {
            LeftValue = leftValue;
            RightValue = rightValue;
            Operator = @operator;
        }
    }
}
