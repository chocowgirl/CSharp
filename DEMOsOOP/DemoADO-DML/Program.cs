using DemoADO_DML.Models;
using Microsoft.Data.SqlClient;

namespace DemoADO_DML
{
    internal class Program
    {

        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Encrypt=False";
        static void Main(string[] args)
        {
            /*SUPRESSION with ExecuteScalar (OUTPUT)
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



                /***INSERTION W****SQL PARAMETERS****

                //Insertion using parameters where all things have values:

                //Section wad = new Section()
                //{
                //    Section_Id = 2425,
                //    Section_Name = "WAD24",
                //    Delegate_Id = 13
                //};


                //Same insertion style AVEC VALEUR NULL
                Section wad = new Section()
                {
                    Section_Id = 2426,
                    Section_Name = "WAD25",
                    Delegate_Id = null
                };


                using (SqlConnection connection1 = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        //command.CommandText = "INSERT INTO section (section_id, section_name, delegate_id) VALUES (2425, 'WAD24', 13)";
                        //the above text will never have a plus or an interpellation in the string.
                        command.CommandText = "INSERT INTO section (section_id, section_name, delegate_id) VALUES (@section_id, @section_name, @delegate_id)";
                        //the directly above is the way of obscuring the information being placed in the request
                        
                        SqlParameter p_section_id = new SqlParameter()
                        {
                            ParameterName = "section_id",
                            Value = wad.Section_Id
                        };
                        command.Parameters.Add(p_section_id); //this line adds the parameter we've created into our dictionary of parameters.

                        //command.Parameters.AddWithValue("section_name", wad.Section_Name);//this line is the direct equivalent of the creation and adding of a parameter above (though for another parameter.  We can only do one parameter per 'entry' of code though, so one line like the above per parameter.



                        /////////////////////Long form again this time for the NULL value stuff//////////
                        SqlParameter p_section_name = new SqlParameter()
                        {
                            ParameterName = "section_name",
                            Value = (object)wad.Section_Name ?? DBNull.Value
                        };
                        command.Parameters.Add(p_section_name); //this line adds the parameter we've created into our dictionary of parameters.


                        command.Parameters.AddWithValue("delegate_id", (object?)wad.Delegate_Id ?? DBNull.Value);//This is for NULL values, the below line is for regular
                        //command.Parameters.AddWithValue("delegate_id", wad.Delegate_Id);
                        
                        connection.Open();
                        int nb_row =  command.ExecuteNonQuery();
                        if (nb_row > 0)
                        {
                            Console.WriteLine("enregistrement ok");
                        }
                        else
                        {
                            Console.WriteLine("enregistrement non ok");  
                        }*/


            //****recuperation of nullable data
            //int section_id = 2526;
            //Section wad = new Section();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT section_id, section_name, delegate_id FROM section WHERE section_id = @section_id";
            //        //command.Parameters.AddWithValue("section_id", section_id); the below is another way to say this
            //        command.Parameters.AddWithValue(nameof(section_id), section_id);
            //        connection.Open();
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                wad = new Section()
            //                {
            //                    Section_Id = (int)reader["section_id"],
            //                    Section_Name = (reader["section_name"] is DBNull)? null : (string?)reader["section_name"],
            //                    Delegate_Id = (reader["delegate_id"] is DBNull)? null : (int?)reader["delegate_id"]
            //                };
            //            }
            //        }
            //        connection.Close();
            //    }
            //}
            //Console.WriteLine($"Voici le groupe {wad.Section_Id} ({wad.Section_Id}), qui ont pour delegue {wad.Delegate_Id.ToString() ?? "Aucun"}! ");



            //////EXO 11h de 15-1-2025
            Student Jessica = new Student("Jessica", "Co", new DateTime(1980, 02, 14), 1320);

            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection1.CreateCommand())
                {
                    command.CommandText = "INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) OUTPUT inserted.student_id VALUES (@first_name, @last_name, @birth_date, @login, @section_id, @year_result, @course_id)";
                    //the directly above is the way of obscuring the information being placed in the request

                    command.Parameters.AddWithValue("first_name", (object?)Jessica.First_Name ?? DBNull.Value);//this line is the direct equivalent of the creation and adding of a parameter

                    command.Parameters.AddWithValue("last_name", (object?)Jessica.Last_Name ?? DBNull.Value);//this line is the direct equivalent of the creation and adding of a parameter

                    command.Parameters.AddWithValue("birth_date", (object?)Jessica.Birth_Date ?? DBNull.Value);//this line is the direct equivalent of the creation and adding of a parameter

                    command.Parameters.AddWithValue("login", (object?)Jessica.Login ?? DBNull.Value);//this line is the direct equivalent of the 
                    command.Parameters.AddWithValue("section_id", (object?)Jessica.Section_Id ?? DBNull.Value);//this line is the direct equivalent of the creation and adding of a parameter

                    command.Parameters.AddWithValue("year_result", (object?)Jessica.Year_Result ?? DBNull.Value);//this line is the direct equivalent of the creation and adding of a parameter

                    command.Parameters.AddWithValue("course_id", Jessica.Course_Id);//this line is the direct equivalent of the creation and adding of a parameter

                    connection1.Open();
                    Jessica.Student_Id = (int)command.ExecuteScalar();
                    connection1.Close();

                    Console.WriteLine(($"{Jessica.First_Name} {Jessica.Last_Name} was added with student Id {Jessica.Student_Id}"));
                    //int nb_row = 0;
                    //try
                    //{
                    //    nb_row = command.ExecuteNonQuery();
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //    Console.WriteLine("Erreur en base de données");
                    //}
                    //connection1.Close();
                    //if (nb_row > 0) // if the one line we want to insert has been inserted there will be 1
                    //{
                    //    Console.WriteLine("La donnée a bien été enregistrée!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("impossible de sauvegarder la donnée.");
                    //}


                }
            }
        }
    }
}


