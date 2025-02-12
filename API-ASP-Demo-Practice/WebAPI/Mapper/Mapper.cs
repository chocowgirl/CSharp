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

        public static User ToBLL(this UserPostDTO model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            return new User(model.First_Name, model.Last_Name, model.Email, model.Password);
        }

        public static User ToBLL(this UserPutDTO model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            return new User(model.First_Name, model.Last_Name, model.Email);
        }

    }
}
