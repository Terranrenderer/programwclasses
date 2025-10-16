//Create a list of Prompts in a list
//Display a random prompt
//Got to also, hold that random prompt in a var and then save it with the answer?

using System.Security.Cryptography.X509Certificates;

class Prompt
{
    //attributes
    public string promptContainer;
    public List<string> _questions = new List<string>
    {
        "Something you smelled today?",
        "Something that made you think of the Lord",
        "Something that makes you smile",
        "Something that was hard today",
        "Soemthing you learned"
    };

    //Begin handling random gen
    public void getPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_questions.Count);
        
        promptContainer = _questions[index];
        Console.WriteLine(promptContainer);
    }

}
