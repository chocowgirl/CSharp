using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//I brought these in (below):
using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;



namespace DAL.Services
{

    public class CocktailService : BaseService, ICocktailRepository<Cocktail>
    {
        public CocktailService(IConfiguration config) : base(config, "Main-DB") { }
        //Here the child class fills in the obligations of the parent

        //private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WAD24-DemoASP-DB;Integrated Security=True;";

        //below code to recuperate the DB and get the list of all drinks
        public IEnumerable<Cocktail> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCocktail(); //!!!!Mapper work to do here
                        }
                    }
                }
            }
        }

        //code to get Cocktail by ID
        public Cocktail Get(Guid cocktail_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_GetById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(cocktail_id), cocktail_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToCocktail();//!!!!!mapper function to create
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }
        }

        //Code to insert (create) a Cocktail
        public Guid Insert(Cocktail cocktail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Cocktail.Name), cocktail.Name);
                    command.Parameters.AddWithValue(nameof(Cocktail.Description), (object?)cocktail.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Cocktail.Instructions), cocktail.Instructions);
                    command.Parameters.AddWithValue("user_id", (object?)cocktail.CreatedBy ?? DBNull.Value);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        //code to update a cocktail
        public void Update(Guid cocktail_id, Cocktail cocktail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(cocktail_id), cocktail_id);
                    command.Parameters.AddWithValue(nameof(Cocktail.Name), cocktail.Name);
                    command.Parameters.AddWithValue(nameof(Cocktail.Description), (object?)cocktail.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Cocktail.Instructions), cocktail.Instructions);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Code to delete a cocktail
        public void Delete(Guid cocktail_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(cocktail_id), cocktail_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
