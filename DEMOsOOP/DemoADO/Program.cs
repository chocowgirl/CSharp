using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Encrypt=False";

            int nbStudent;
            DataTable table_student = new DataTable();

            //by placing the using underneath with the brackets, the SqlConnection will exist only while what's in the code block is happening, then because this object is Idisposable, it will collect itself.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //***Connection test below
                //Console.WriteLine($"The state of the connection is: {connection.State}");
                //connection.Open();
                //Console.WriteLine($"The state of the connection is: {connection.State}");
                //connection.Close();
                //Console.WriteLine($"The state of the connection is: {connection.State}");

                //***Searching Scalar info via SQL command below
                //using (SqlCommand command = connection.CreateCommand())
                //{
                //    command.CommandText = "SELECT COUNT(student_id) FROM student";
                //    connection.Open();
                //    nbStudent = (int)command.ExecuteScalar();
                //    connection.Close();
                //}
                //Console.WriteLine($"Il y a {nbStudent} étudiants enregistrés en base de données.");

                //***Mode connecté tabulaire (ensemble de valeurs : peu importe le nombre de ligne ou colonne)
                //using SqlCommand command = connection.CreateCommand();
                //{
                //    command.CommandText = "SELECT login, birth_date FROM student";
                //    connection.Open();
                //    using (SqlDataReader reader = command.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            Console.WriteLine($"Login: {reader["login"]} - Date de naissance : {(DateTime)reader["birth_date"]}");
                //        };
                //    }
                //    connection.Close();
                //};


                //***Mode deconnecté
                //    using (SqlCommand command = connection.CreateCommand())
                //    {
                //        command.CommandText = "SELECT * FROM student";
                //        SqlDataAdapter adapter = new SqlDataAdapter(command);

                //        adapter.Fill(table_student);
                //    }


                //$$$EXO GIVEN AT END OF CLASS:
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT section_name, section_id FROM section";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"section name: {reader["section_name"]} - id : {reader["section_id"]}");
                        };
                    }
                    connection.Close();
                }

                Console.WriteLine("Please enter the section id for which you'd like more information and hit enter: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine($"You have chosen the section {choice}");
                using(SqlCommand command = connection.CreateCommand()) 
                {
                    command.CommandText = "SELECT delegate_id FROM section";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Section {choice} has {reader["delegate_id"]} as their delegate.");
                        };
                    }
                    connection.Close();
                    Console.WriteLine($"This section has ");
                };

            };

            //foreach (DataRow ligne_db in table_student.Rows)
            //{
            //    Console.WriteLine($"{ligne_db["student_id"]} : {ligne_db["first_name"]} {ligne_db["last_name"]}");
            //}

            


        }
    }
}
