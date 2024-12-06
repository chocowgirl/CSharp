namespace Demo3Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login user1 = new Login()
            {
                Email = "samuel.legrain@bstorm.be",
            };

            user1.Password = "test1234=";

            Console.WriteLine($"Votre email est {user1.Email}");
            //Console.WriteLine($"Votre mot de pass est {user1.Password}");

            string inputEmail, inputPassword;
            do
            {
                Console.WriteLine($"Veuillez indiquer votre email :");
                inputEmail = Console.ReadLine();
                Console.WriteLine($"Veuillez indiquer votre mot de passe :");
                inputPassword = Console.ReadLine();
            }while (!user1.CheckIdentity(inputEmail, inputPassword));

        }
    }
}
