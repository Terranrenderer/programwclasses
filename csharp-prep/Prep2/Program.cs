using System;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How bad are u failing, scale of grade?");
        string grade = Console.ReadLine();
        int gradeNum = int.Parse(grade);

        if (gradeNum >= 90)
        {
            Console.WriteLine("A");
        }
        else if (gradeNum >= 80)
        {
            Console.WriteLine("B");
        }
        else if (gradeNum >= 70)
        {
            Console.WriteLine("C");
        }
        else if (gradeNum >= 60)
        {
            Console.WriteLine("D");
        }
        else
        {
            Console.WriteLine("F");
        }
    }
}