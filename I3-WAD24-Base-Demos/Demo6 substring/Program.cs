namespace Demo6_substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string email = "samuel.legrain@bstorm.be";
            int positionArobase = email.IndexOf('@');
            int positionPremierDot = email.IndexOf(".");

            int firstNameLength = positionPremierDot; //the length of the first name corresponds to the index of the point (6)

            string firstName = email.Substring(0, positionPremierDot); /* we give the departure point and define the number of characters.  Instead of positionPremierDot we could use firstNameLength, which was added in by Samuel in the demo to be able to be a little clearer.*/

            string lastName = email.Substring (positionPremierDot + 1, positionArobase - positionPremierDot-1);

            string domainName = email.Substring(positionArobase + 1); // we give the departure point and it goes until the end if we don't specify the end.

            Console.WriteLine($"First name is {firstName} and family name is {lastName} and domain name is {domainName}");
        }
    }
}
