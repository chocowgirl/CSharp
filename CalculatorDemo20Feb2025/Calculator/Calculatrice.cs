namespace Calculator
{
    public class Calculatrice
    {

        private List<Operation> _operations;

        public Calculatrice()
        {
            _operations = new List<Operation>();
        }

        public Operation[] Operations
        {
            get
            {
                return _operations.ToArray();
            }
        }


        public void AddOperation(double left, OperatorEnum @operator, double right)
        {
            Operation op = new Operation(left, right, @operator); //bc in our constructor they appear in this order (look at 
            _operations.Add(op);
        }


        public static int Addition(int left, int right)
        {
            int sum = checked(left + right);  //Vérifie les dépassement arithmétiques en lançant une exception
            return sum;
        }


        public static double Multiply(double left, double right)
        {
            return left * right;
        }
    }
}
