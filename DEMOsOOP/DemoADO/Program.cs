using DemoADO.Models;
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
            List<Personne> personnes = new List<Personne>();
            DataTable datas = new DataTable();
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

                int sectionDelegateID = 0;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT delegate_id FROM section WHERE section_id = {choice}";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine($"Section {choice} has {reader["delegate_id"]} as their delegate.");
                            sectionDelegateID = (int)reader["delegate_id"];
                        };
                        //the above should be done with a scalar demand (more efficient):
                        //sectionDelegateID = (int)command.ExecuteScalar();
                    }
                    connection.Close();
                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT first_name, last_name FROM student WHERE student_id = {sectionDelegateID}";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Section {choice} has {reader["first_name"]} {reader["last_name"]} as their delegate.");
                        }
                    }
                    connection.Close();
                }

                int sectionStudentCount = 0;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM student WHERE section_id = {choice}";
                    //plus efficace: $"SELECT COUNT(student_id) FROM student WHERE section_id = {choice}";
                    //puis vue que c'est un scalar demande, traiter ainsi après avoir ouvert la connection:
                    //sectionStudentCount = (int)command.ExecuteScalar()
                    //Console.WriteLine($"Il y a en tout {sectionStudentCount} étudiants dans cette section");
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            sectionStudentCount++;
                    }
                    Console.WriteLine($"This section has {sectionStudentCount} students.");
                    connection.Close();
                }

                //exo partie 2 
                //creer la classe personne avec properties nom et prenom
                //recuperer la liste des professeurs (professeur_name & professeur_surname) ainsi que
                //la liste des étudiants (last_name & first_name) dans un datatable
                //transferer chaque ligne de votre datatable dans une nouvelle instance de Personne et l'ajouter dans une
                //liste<Personne>

                //Place the below 2 lines outside of the connection (3rd line) ... Here I am already using a connection (above) so these two lines appear ^^ up there.
                //List<Personne> personnes = new List<Personne>();
                //DataTable datas = new DataTable();
                //using (SqlConnection connection = new SqlConnection(connectionString)) { put the other stuff in here if not already connected }



                using (SqlCommand command1 = connection.CreateCommand())
                {
                    command1.CommandText = "SELECT first_name, last_name FROM student UNION SELECT professor_surname, professor_name FROM professor";
                    SqlDataAdapter adapter = new SqlDataAdapter(command1);
                    adapter.Fill(datas); //**c'est le Fill function that opens, gets data, and closes the connection 
                }
            }
            foreach (DataRow row in datas.Rows)
            {
                personnes.Add(new Personne(row["first_name"].ToString(), (string)row["last_name"]));
            }

            foreach (Personne p in personnes)
            {
                Console.WriteLine($"{p.Prenom} {p.Nom}");
            }

            // DML EXO SOLUTION:

            Student s = new Student("Samuel", "Legrain", new DateTime(1987, 9, 27), 1120);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO student (first_name, last_name, birth_date, login, year_result, section_id, course_id) OUTPUT inserted.student_id VALUES ('{s.First_Name}', '{s.Last_Name}', '{s.Birth_Date?.ToString("yyyy-MM-dd") ?? "NULL"}', '{s.Login}', {(object)s.Year_Result ?? "NULL"}, {s.Section_Id}, '{s.Course_Id}')";
                    connection.Open();
                    s.Student_Id = (int)command.ExecuteScalar();
                    connection.Close();
                }

            }

            Console.WriteLine($"L'étudiant {s.First_Name} {s.Last_Name} est bien enregistré, il a l'identifiant {s.Student_Id}.");


            





        }
    }
}
