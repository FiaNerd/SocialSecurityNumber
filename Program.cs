using System;
using System.Globalization;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;

            try
            {
                // Input
                if (args.Length > 0)
                {
                    firstName = args[0];
                    lastName = args[1];
                    socialSecurityNumber = args[2];
                }
                else
                {
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();

                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();

                    Console.Write("Social security number (YYYYMMDD-XXXX): ");
                    socialSecurityNumber = Console.ReadLine();
                }

                Console.Clear();

                while (socialSecurityNumber.Length != 13)
                {
                    Console.Write("Invalid input, please enter your \nSocail Security Number (YYYYMMDD-XXXX): ");
                    socialSecurityNumber = Console.ReadLine();
                    Console.Clear();
                }
               
                int genderNumber = Convert.ToInt32(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

                //string gender = "Female" the penultimate even digit of the social security number is a woman
                string gender = genderNumber % 2 == 0 ? "Female" : "Male";

                DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

                int age = DateTime.Now.Year - birthDate.Year;

                if ((birthDate.Month > DateTime.Now.Month) && (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
                {
                    age--;
                }

                const int greatesGenerationBegins = 1910;
                const int greatesGenerationEnds = 1924;
                const int silentGenrationBegins = 1925;
                const int silentGenerationEnds = 1945;
                const int babyBoomersBegins = 1946;
                const int babyBoomersEnds = 1964;
                const int generationXBegins = 1965;
                const int generationXEnds = 1979;
                const int millennianBegins = 1980;
                const int millennianEnds = 1994;
                const int generationZBegins = 1995;
                const int generationZEnds = 2012;
                const int genAlphaBegins = 2013;
                const int genAlphaEnds = 2025;

                int userYear = Convert.ToInt32(socialSecurityNumber.Substring(socialSecurityNumber.Length - 13, 4));

                string userGeneration = userYear >= greatesGenerationBegins && userYear <= greatesGenerationEnds ? "The Greatest Generation" :
                       userYear >= silentGenrationBegins && userYear <= silentGenerationEnds ? "The Silent Generation" :
                       userYear >= babyBoomersBegins && userYear <= babyBoomersEnds ? "The Baby Boomers" :
                       userYear >= generationXBegins && userYear <= generationXEnds ? "Generation X" :
                       userYear >= millennianBegins && userYear <= millennianEnds ? "Millennian" :
                       userYear >= generationZBegins && userYear <= generationZEnds ? "Generation Z" :
                       userYear >= genAlphaBegins && userYear <= genAlphaEnds ? "Genaration Alpha" : "Sorry, your generation isn't in our register";


                Console.WriteLine($"Name: {firstName} {lastName}\nSSN: {socialSecurityNumber}\nGender: {gender}");
                Console.WriteLine($"Age: { age}\nGeneration: {userGeneration}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.Write("Sorry, wrong input\nTry again (YYYYMMDD-XXXX): ", e.Message);
                Console.ReadLine();
            }
        }

    }
}

