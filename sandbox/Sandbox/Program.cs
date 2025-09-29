using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software engineer";
        job1._company = "MIcrosoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myresume = new Resume();
        myresume._name = "Allison Rose";

        myresume._jobs.Add(job1);
        myresume._jobs.Add(job2);

        myresume.Display();
    }
}