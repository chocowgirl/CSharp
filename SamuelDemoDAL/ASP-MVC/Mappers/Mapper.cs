using ASP_MVC.Models.User;
using BLL.Entities;

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
    }
}
