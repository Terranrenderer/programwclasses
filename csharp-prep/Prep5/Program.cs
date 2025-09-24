using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        {
            hallo();

            string userName = PromptUserName();
            int userNumber = IDNumber();

            int sqr = sqrrt(userNumber);

            int birfYear;
            PromptBirfYear(out birfYear);


            DisplayResult(userName, sqr, birfYear);
        }
        static void hallo()
        {
            Console.Write("Hallo Mein Friund");
        }
        static string PromptUserName()
        {
            Console.Write("\nYour name?");
            string name = Console.ReadLine();

            return name;
        }
        static int IDNumber()
        {
            Console.Write("Your identification number?");
            int number = int.Parse(Console.ReadLine());

            return number;
        }
        static void PromptBirfYear(out int birfYear)
        {
            Console.Write("Mmh, what is your year of birth?");
            birfYear = int.Parse(Console.ReadLine());
        }
        static int sqrrt(int number)
        {
            int sqr = number * number;

            return sqr;
        }
        static void DisplayResult(string name, int square, int birfYear)
        {
            Console.WriteLine($"{name}, the square of your number is {square}.");
            Console.WriteLine($"{name}, you will turn {2025 - birfYear} years old this year.");
        }

        
        
    }
}