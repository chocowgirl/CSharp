//using BLL.Entities;
//using BLL.Services;
using DAL.Entities;
using DAL.Services;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CocktailService service = new CocktailService();
            //foreach (Cocktail c in service.Get())
            //{
            //    Console.WriteLine($"{c.Cocktail_Id} : {c.Name}\nCréé le : {c.CreatedAt.ToShortDateString()}\n{c.Description}\n{c.Instructions}");
            //}



            //TO TEST THE DAL SERVICES IN THE CONSOLE:

            //UserService service = new UserService();
            ////*********service.Delete(Guid.Parse("Guid paste here"));
            //foreach (User u in service.Get())
            //{
            //    if (u.IsDisabled)
            //    {
            //        Console.BackgroundColor = ConsoleColor.DarkRed;
            //    }
            //    Console.WriteLine($"{u.User_Id} : {u.First_Name} {u.Last_Name} - {u.Email} : {u.Password}");
            //    Console.ResetColor();
            //}


            //CocktailService service = new CocktailService();
            ////*********service.Delete(Guid.Parse("Guid paste here"));
            //foreach (Cocktail c in service.Get())
            //{
            //    Console.WriteLine($"{c.Cocktail_Id} : {c.Name} \n {c.Description} \n {c.Instructions} \n Created: {c.CreatedAt}, By: {c.CreatedBy}");
            //    Console.ResetColor();
            //}

            //CommentService comserv = new CommentService();
            //Comment c1 = new Comment()
            //{
            //    Title = "tres bon",
            //    Content = "I thought this was super delicious!",
            //    Concern = Guid.Parse("42dd80fb-d8e2-442e-807f-195a5e8b4ab4"),
            //    CreatedBy = Guid.Parse("df820a4a-7403-48e6-aa42-ded97493ede3"),
            //    Note = 5
            //};
            //c1.Comment_Id = comserv.Insert(c1);

            //CommentService comserv = new CommentService();
            //Comment c2 = new Comment()
            //{
            //    Title = "Okay",
            //    Content = "I think it would be better with Rosemary and not mint",
            //    Concern = Guid.Parse("42dd80fb-d8e2-442e-807f-195a5e8b4ab4"),
            //    CreatedBy = Guid.Parse("9cf483c1-d477-450e-b118-f6d4def135a1"),
            //    Note = 3
            //};
            //c2.Comment_Id = comserv.Insert(c2);



            CommentService comserv = new CommentService();
            foreach (Comment com in comserv.GetFromCocktail(Guid.Parse("42dd80fb-d8e2-442e-807f-195a5e8b4ab4")))
            {
                Console.WriteLine($"{com.Comment_Id} : {com.Title} \n {com.Content} \n {com.Concern} \n Created: {com.CreatedAt}, By: {com.CreatedBy}, Note: {com.Note}");
                Console.ResetColor();
            }

            //CommentService comserv = new CommentService();
            //foreach

            //****FAUT TESTER TOUT FONCTION DU DAL chaque service!





        }
        }
}
