using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.Models
{
    internal class Student
    {
        public int Student_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Login { get; set; }
        public int Section_Id { get; set; }
        public int? Year_Result { get; set; }
        public string Course_Id { get; set; }

        public Student(string firstname, string lastname, DateTime birthday, int sectionId)
        {
            //Id = id; b/c
            First_Name = firstname;
            Last_Name = lastname;
            Birth_Date = birthday;
            Login = (firstname.Substring(0, 1) + lastname.Substring(0, (lastname.Length<7)?lastname.Length:7)).ToLower();
            //Login: ceci se forme automatiquement grace au premier lettre de firstname, 7 of lastname (note ternery for
            //last name which looks at if the last name is less than 7 letters, and if it is then the lastname.Substring
            //endpoint is the lastname.Length.  If it is not shorter than 7 letters, then the stoppoint of the substring
            //is the seventh place)
            Section_Id = sectionId; //give 1320
            Year_Result = null; // give null
            Course_Id = "0"; //give "0"
        }
    }
}
