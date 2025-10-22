// there needs to be alist
// this list needs to be empty and ready to recieve a scripture.
// iteravte thru for each word so i can process them through word

class Scripture
{
    //attrivutes
    private List<Word> _scridders = new List<Word>() { };
    //behaviors
    public void handleEntry(string entry)//gettter
    {
        string[] words = entry.Split(' ');
        foreach (string w in words)
        {
            _scridders.Add(new Word(w));
        }
    }
    public bool knowHidden() //getter
    {
        foreach (Word w in _scridders)
        {
            if (w.IsRevealed())
            {
                return false;
            }
        }
        return true;
    }
    public void HideRandom()
    {
    Random random = new Random();

    List<int> indexes = new List<int>();
    for (int i = 0; i < _scridders.Count; i++)
    {
        if (_scridders[i].IsRevealed())
        {
            indexes.Add(i);
        }
    }

    if (indexes.Count == 0)
    {
        return;
    }

    int randomIndexInList = random.Next(indexes.Count);
    int wordIndex = indexes[randomIndexInList];

    _scridders[wordIndex].Hide();
}

    public void Display()
    {
        foreach (Word w in _scridders)
        {
            w.Display();
        }
            Console.WriteLine();
    }
}