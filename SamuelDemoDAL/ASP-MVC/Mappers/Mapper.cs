using ASP_MVC.Models.User;
using BLL.Entities;
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


        public static User ToBLL(this UserCreateForm user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new User(
                //Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password
                //DateTime.Now,
                //null
            );
            //the above commented stuff is another way to work around.  Check BLL user.cs to see how we overloaded the constructor
            return new User(user.First_Name, user.Last_Name, user.Email, user.Password);

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
