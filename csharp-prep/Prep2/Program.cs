using System;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";
        Console.WriteLine("How bad are u failing, scale of grade?");
        string grade = Console.ReadLine();
        int gradeNum = int.Parse(grade);

        if (gradeNum >= 90)
        {
            letter = "A";
        }
        else if (gradeNum >= 80)
        {
            letter = "B";
        }
        else if (gradeNum >= 70)
        {
            letter = "C";
        }
        else if (gradeNum >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"{letter}");
        if (gradeNum < 70)
        {
            Console.WriteLine("BRUH");
        }
        else
        {
            Console.WriteLine("NICE");
        }
    }
}