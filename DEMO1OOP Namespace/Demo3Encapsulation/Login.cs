using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3Encapsulation
{
    public class Login
    {
        private string _email;
        public string Email // declaring a property to serve as guardian to treatment of private var qui est le string _email
        {
            get {
                return _email.ToLower();
            }
            set {
                if (value is null) return; //Plus tard remplacé par une exception
                value = value.Trim(); // we cut whitespaces
                if (value.Length > 320) return; // exception here later
                if (value.IndexOf("@") < 1 && value.IndexOf("@") > value.Length-1) return; //Plus tard exception here
                _email = value;
            }
        }

        public string EmailDomain
        {
            get
            {
                return Email.Substring(Email.IndexOf('@') + 1); //autocalculated property here
            }
        }

        public int EmailLength {  
            get { return Email.Length; } // autocalculated property here
        }

        private string _password;

        public string Password
        {
            private get
            {
                return _password;
            }
            set
            {
                if (value is null) return;
                value = value.Trim();
                if (value.Length < 8 || value.Length > 32) return;
                _password = value;
            }
        }

        public bool CheckIdentity(string email, string password)
        {
            return Email == email && Password == password;
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}
