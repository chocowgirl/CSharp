using ASP_MVC.Models.Cocktail;
using ASP_MVC.Models.User;
using BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace ASP_MVC.Mappers
{
    internal static class Mapper
    {
        public static UserListItem ToListItem(this User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserListItem()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
            };
        }

        public static CocktailListItem ToListItem(this Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailListItem()
            {
                Cocktail_Id = cocktail.Cocktail_Id,
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions = cocktail.Instructions,
                CreatedAt = cocktail.CreatedAt,
                CreatedBy = cocktail.CreatedBy
            };
        }


        //MVC mapper goes and grabs BLL information and converts them into an acceptable object for the MVCs needs
        public static UserDetails ToDetails(this User user)
        {
            if (user is null) throw new ArgumentNullException( nameof(user));
            return new UserDetails()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                CreatedAt = DateOnly.FromDateTime(user.CreatedAt),
            };
        }

        public static CocktailDetails ToDetails(this Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailDetails()
            {
                Cocktail_Id = cocktail.Cocktail_Id,
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions = cocktail.Instructions,
                CreatedAt = cocktail.CreatedAt,
                CreatedBy = cocktail.CreatedBy
            };
        }


        public static User ToBLL(this UserCreateForm user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password,
                DateTime.Now,
                null
            );
            //the above commented stuff is another way to work around.  Check BLL user.cs to see how we overloaded the constructor
            //return new User(user.First_Name, user.Last_Name, user.Email, user.Password);

        }


        public static Cocktail ToBLL(this CocktailCreateForm cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new Cocktail(
                Guid.Empty,
                cocktail.Name,
                cocktail.Description,
                cocktail.Instructions,
                DateOnly.FromDateTime(DateTime.Now),
                cocktail.CreatedBy
            );
            //the above commented stuff is another way to work around.  Check BLL cocktail.cs to see how we overloaded the constructor
            //return new Cocktail(cocktail.Name, cocktail.Description, cocktail.Instructions, cocktail.CreatedBy);

        }

        //We convert BLL user information to pass the needed information to the UserEditForm
        public static UserEditForm ToEditForm (this BLL.Entities.User user)
        {
            if(user is null) throw new ArgumentNullException(nameof(user));
            return new UserEditForm()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email
            };
        }

        //We convert BLL cocktail information to pass the needed information to the CocktailEditForm
        public static CocktailEditForm ToEditForm(this BLL.Entities.Cocktail cocktail)
        {
            if (cocktail is null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailEditForm()
            {
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions = cocktail.Instructions,
                CreatedBy = (Guid)cocktail.CreatedBy
            };
        }


        public static User ToBLL(this UserEditForm user)
        {
            if(user is null) throw new ArgumentNullException(nameof(user));
            //return new User(
            //    Guid.Empty,
            //    user.First_Name,
            //    user.Last_Name,
            //    user.Email,
            //    "********",
            //    DateTime.Now,
            //    null  //this way is the work-around without having to make a 3-parameter constructor in the BLL entity called User.
            //);
            return new User(
                user.First_Name,
                user.Last_Name,
                user.Email
            );
        }


        //We convert BLL user information to pass the needed information to the UserEditForm
        public static UserDelete ToDelete(this BLL.Entities.User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserDelete()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email
            };
        }


    }
}
