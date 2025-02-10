using BLL.Entities;
using WebAPI.Models.User;

namespace WebAPI.Mapper
{
    public static class Mapper
    {
        public static UserDTO ToDTO(this User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserDTO() { 
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                IsDisabled = user.IsDisabled
            };
        }
    }
}
