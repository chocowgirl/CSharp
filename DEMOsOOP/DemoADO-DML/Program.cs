using Microsoft.Data.SqlClient;

namespace DemoADO_DML
{
    internal class Program
    {

        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Encrypt=False";
        static void Main(string[] args)
        {
            //SUPRESSION with ExecuteScalar (OUTPUT)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM section OUTPUT deleted.section_name WHERE section_id = 2425";
                    connection.Open();
                    string section_name = (string)command.ExecuteScalar();
                    connection.Close();
                    Console.WriteLine($"la section supprimée est {section_name}.");
                }


                //INSERTION WITH ExecuteNonQuery
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    using (SqlCommand command = connection.CreateCommand()) 
                //    {
                //        command.CommandText = "INSERT INTO section (section_id, section_name, delegate_id) VALUES (2425, 'WAD24', 13)";
                //        connection.Open();
                //        int nb_row = 0;
                //        try
                //        {
                //            nb_row = command.ExecuteNonQuery();
                //        }
                //        catch (Exception ex)
                //        {
                //            Console.WriteLine("Erreur en base de données");
                //        }
                //        connection.Close();
                //        if (nb_row > 0) // if the one line we want to insert has been inserted there will be 1
                //        {
                //            Console.WriteLine("La donnée a bien été enregistrée!");
                //        }
                //        else
                //        {
                //            Console.WriteLine("impossible de sauvegarder la donnée.");
                //        }
                //        //command.ExecuteNonQuery(); -> this if we don't want to make the above verification

            }
        }
    }
}

