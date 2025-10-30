using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Patrick", "CSE");
        string summary = assignment1.GetSummary();
        Console.WriteLine(summary);
        MathAssignment mathAssignment1 = new MathAssignment("Patrick", "Mth", "5", "6-7");
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writing1 = new WritingAssignment("retard liberals", "writing101", "why communism is good");
        Console.WriteLine(writing1.GetSummary());
        Console.WriteLine(writing1.GetWritingInfo());
    }
}