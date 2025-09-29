class Job
{
//Attributes
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    //Behaviors
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

/*Class: Person
Attributes:
* _givenName : string
* _familyName : string

Behaviors:
* ShowEasternName() : void
* ShowWesternName() : void*/