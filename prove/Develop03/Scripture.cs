// Create a list of scriptures
// Get random and save index
// Methods: Get scripture, get index

class Scripture
{
    public List<string> _scridders = new List<string>
    {
        "Buh",
        "Cuh",
        "And i was gay"
    };

    public void getScridder()
    {
        foreach (string scridder in _scridders)
        {
            
            Console.WriteLine(scridder);
        }
    }
}