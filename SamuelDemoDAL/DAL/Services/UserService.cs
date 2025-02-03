using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserService : BaseService, IUserRepository<User>
    {
        public UserService(IConfiguration config) : base(config, "Main-DB") { }
        //Here the child class fills in the obligations of the parent

 
        //below code to recuperate the DB and get the list of all users that are active
        public IEnumerable<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_GetAllActive";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToUser();
                        }
                    }
                }
            }
        }


        //to do the same but get a single user by their ID
        public User Get(Guid user_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_GetById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(user_id), user_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUser();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }
        }


        public Guid Insert(User user)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(User.First_Name), user.First_Name);
                    command.Parameters.AddWithValue(nameof(User.Last_Name), user.Last_Name);
                    command.Parameters.AddWithValue(nameof(User.Email), user.Email);
                    command.Parameters.AddWithValue(nameof(User.Password), user.Password);
                    connection.Open();
                    return(Guid)command.ExecuteScalar();
                }
            }
        }


        public void Update(Guid user_id, User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(user_id), user_id);
                    command.Parameters.AddWithValue(nameof(User.First_Name), user.First_Name);
                    command.Parameters.AddWithValue(nameof(User.Last_Name), user.Last_Name);
                    command.Parameters.AddWithValue(nameof(User.Email), user.Email);
                    connection.Open() ;
                    command.ExecuteNonQuery();
                }
            }
        }


        public void Delete(Guid user_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Delete";
                    command.CommandType= CommandType.StoredProcedure;   
                    command.Parameters.AddWithValue(nameof(user_id), user_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public Guid CheckPassword(string email, string password)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_CheckPassword";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(email), email);
                    command.Parameters.AddWithValue(nameof(password), password);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }





    }
}
