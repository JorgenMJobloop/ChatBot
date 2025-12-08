public class KeywordResponseProvider : IResponseProvider
{

    // create a private readonly List<string> of responses
    private readonly List<string> _responses = new List<string>
    {
        "Hello! How can I help you?","Interesting, please tell me more!","That sounds exciting.",
        "I did not quite catch that, but I will try to keep up!", "Thank you for sharing this.",
        "Would you like to learn more about C#?", "https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/"
    };

    // create a random number generator, to randomize the output. As a private readonly field
    private readonly Random _random = new Random();
    public string GetResponse(string userInput)
    {
        // use the ToLowerInvariant() method, on our userInput parameter argument
        string toLower = userInput.ToLowerInvariant();
        // check the input, and based on the input, return the proper response (not random)
        if (toLower.Contains("hi") || toLower.Contains("hello"))
        {
            return $"Hello! I am a simple chatbot.";
        }
        // return a useful phrase, if the input contains "learn"
        if (toLower.Contains("learn"))
        {
            return $"Okay, if you want to learn more about C#.\nYou can check out this link:{_responses[6]}";
        }
        // default return values, randomly selected.
        return _responses[_random.Next(_responses.Count)];
    }
}