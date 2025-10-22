using System.ComponentModel.DataAnnotations;

class Reference
{
    private string _REF = "";

    public void handleRefEntry(string refEntry)//setter
    {
        _REF = refEntry;
    }
    public void Display()
    {
        Console.Write(_REF);
    }
}

