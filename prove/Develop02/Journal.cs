// Store entries ( I think thatll include handling reading them)
// Display entries
using System.Data;
using System.Data.Common;
using System.Net.Mail;

class Journal
{
    public List<string> _entries = new List<string>();
    public void appendEntry()
    {
        string entry = Console.ReadLine();
        _entries.Add(entry);
        _entries.Add("");
    }

    public void Display()
    {
        foreach (string entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }
}