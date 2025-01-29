//using DAL.Entities;
//using DAL.Services;
using BLL.Entities;
using BLL.Services;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService service = new UserService();
            //*********service.Delete(Guid.Parse("Guid paste here"));
            foreach (User u in service.Get())
            {
                if (u.IsDisabled){
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                Console.WriteLine($"{u.User_Id} : {u.First_Name} {u.Last_Name} - {u.Email} : {u.Password}");
                Console.ResetColor();
            }
        }




    }
}
