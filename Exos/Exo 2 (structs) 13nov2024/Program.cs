using System.ComponentModel.Design;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

namespace Exo_2__structs__13nov2024
{   //Dans une application console en.net 8, créez les structures suivantes :

    //-"Person" comportant les variables:
    //    -lastname et firstname de type string
    //    -birthdate de type DateTime nullable
    //    -address de type Address nullable

    //-"Address" comportant les variables:
    //    -street, number, zipCode, city, country de type string

    //L'utilisateur pourra créer une liste de contactes constituée de Person.
    //Les personnes doivent avoir un nom et prénom, et possiblement, une date de naissance et une adresse postale.

    public struct Address
    {
        public string street, number, zipCode, city, country;
    }
    
    public struct Person
    {
        public string lastname, firstname;
        public DateTime? birthdate;
        public Address? address;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            char goOn = 'Y';
            char goOnAddress;
            char goOnBirthdate;
            int yearOfBirth;
            int monthOfBirth;
            int dateOfBirth;
            bool givenGoOnParseable;
            bool givenGoOnBirthdateParseable;
            bool givenGoOnAddressParseable;
            bool givenYearOfBirthStringParseable;
            bool givenMonthOfBirthStringParseable;
            bool givenDateOfBirthStringParseable;


            List<Person> people = new List<Person>();

            if (people.Count > 0)
            {
                foreach (Person p in people)
                {
                    Console.WriteLine($"{p.lastname} {p.firstname}");
                    if (p.birthdate != null)
                    {
                        Console.WriteLine($"birthday: {((DateTime)p.birthdate).ToShortDateString()}");
                    }
                    if (p.address != null)
                    {
                        Address a = (Address)p.address;
                        Console.WriteLine($"{a.street} {a.number}\n{a.zipCode} {a.city}\n{a.country.ToUpper()}");
                    }
                    Console.WriteLine("----------------");
                }
            }
            else
            {
                Console.WriteLine("There are not yet any contacts");
            }


            do
            {
                Console.WriteLine("Welcome to Contact-List 3000, to add a new person to the list, enter Y.  To quit enter Q. ");
                string givenGoOnString = Console.ReadLine().ToUpper();
                givenGoOnParseable = char.TryParse(givenGoOnString, out goOn);
            } while (!givenGoOnParseable);

            if (goOn == 'Y')
            {
                Person invented;
                Console.WriteLine("Please enter the new persons first name:");
                invented.firstname = Console.ReadLine();
                Console.WriteLine("Please enter the new persons last name:");
                invented.lastname = Console.ReadLine();

                //ask if they want to assign a birthday to the person while verifying the answer
                do
                {
                    Console.WriteLine("Do you want to assign a birthdate to this person?  If so enter Y.  If not enter N.");
                    string givenGoOnBirthdateString = Console.ReadLine().ToUpper();
                    givenGoOnBirthdateParseable = char.TryParse(givenGoOnBirthdateString, out goOnBirthdate);
                } while (!givenGoOnBirthdateParseable);

                //if they DO want to assign a birthday collect the correct inputs, verify them, and assemble them into a DateTime
                if (goOnBirthdate == 'Y')
                {
                    do
                    {
                        Console.WriteLine("Please enter this persons year of birth (4 digits):");
                        string givenYearOfBirthString = Console.ReadLine();
                        givenYearOfBirthStringParseable = int.TryParse(givenYearOfBirthString, out yearOfBirth);
                    } while (!givenYearOfBirthStringParseable);

                    do
                    {
                        Console.WriteLine("Please enter this persons month of birth (either one or two digits):");
                        string givenMonthOfBirthString = Console.ReadLine();
                        givenMonthOfBirthStringParseable = int.TryParse(givenMonthOfBirthString, out monthOfBirth);
                    } while (!givenMonthOfBirthStringParseable);

                    do
                    {
                        Console.WriteLine("Please enter this persons date of birth (either one or two digits):");
                        string givenDateOfBirthString = Console.ReadLine();
                        givenDateOfBirthStringParseable = int.TryParse(givenDateOfBirthString, out dateOfBirth);
                    } while (!givenDateOfBirthStringParseable);

                    invented.birthdate = new DateTime(yearOfBirth, monthOfBirth, dateOfBirth);
                }
                else
                {
                    invented.birthdate = null;
                }

                //Ask if they want to add an address for the person, while verifying the answer
                do
                {
                    Console.WriteLine("Do you want to assign an address to this person?  If so enter Y.  If not enter N.");
                    string givenGoOnAddressString = Console.ReadLine().ToUpper();
                    givenGoOnAddressParseable = char.TryParse(givenGoOnAddressString, out goOnAddress);
                } while (!givenGoOnAddressParseable);

                //if they DO want to assign an address collect the correct inputs, verify them, and assemble them into the address info
                if (goOnAddress == 'Y')
                {
                    Address addy;
                    Console.WriteLine("Please enter the new persons street name:");
                    addy.street = Console.ReadLine();
                    Console.WriteLine("Please enter the new persons street number:");
                    addy.number = Console.ReadLine();
                    Console.WriteLine("Please enter the new persons zipcode:");
                    addy.zipCode = Console.ReadLine();
                    Console.WriteLine("Please enter the new persons city:");
                    addy.city = Console.ReadLine();
                    Console.WriteLine("Please enter the new persons country:");
                    addy.country = Console.ReadLine();
                    invented.address = addy;
                }
                else
                {
                    invented.address = null;
                }
                people.Add(invented);
            }
            else if (goOn == 'Q')
            {
                Console.WriteLine("Thank you for using Contact-List 3000");
            }









            }
    }
}
