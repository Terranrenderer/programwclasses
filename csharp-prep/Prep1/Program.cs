using System;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your First Name?");
        string first = Console.ReadLine();
        Console.WriteLine("What is your Last Name?");
        string last = Console.ReadLine();
        Console.WriteLine($"\nYour name is {last}, {first} {last}");
    }
}