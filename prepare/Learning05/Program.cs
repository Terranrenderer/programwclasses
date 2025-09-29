using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        int birthYear;
        PromptUserBirthYear(out birthYear);


        DisplayResult(userName, squaredNumber, birthYear);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write($"Enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());

    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2025 - birthYear} years old");
    }
}