public class SimpleListResponseProvider : IResponseProvider
{

    // create a private readonly List<string> of responses
    private readonly List<string> _responses = new List<string>
    {
        "Hello! How can I help you?","Interesting, please tell me more!","That sounds exciting.",
        "I did not quite catch that, but I will try to keep up!", "Thank you for sharing this.",
        "Would you like to learn more about C#?", "Alright, here is the C# documentation: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/"
    };

    // create a random number generator, to randomize the output. As a private readonly field
    private readonly Random _random = new Random();

    public string GetResponse(string userInput)
    {
        return _responses[_random.Next(_responses.Count)];
    }
}