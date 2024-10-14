namespace Demo8___doWhile_for_password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string PASSWORD = "Test1234=";
            int countdown = 3;
            string password;

            do
            {
                Console.WriteLine($"Please enter your password : ({countdown} attempts remaining)");
                password = Console.ReadLine();
                countdown--;
            } while (password != PASSWORD && countdown > 0);

            if (password is PASSWORD)
            //Here we use the "is" because it's more secure, but is can be used for type comparisons OR
            //for strict comparisons between the VALUES of variables and constants.  This also works for
            //strict comparisons between the values of two constants, but not for between two variables.
            {
                Console.WriteLine("Welcome");
            }
            else {
                Console.WriteLine("This account is now blocked");
            }
        }
    }
}
