using System.Text.Json;
public class JsonResponseProvider : IResponseProvider
{
    // create a private readonly List<string> field of responses
    private readonly List<string> _responses;
    // create a private readonly Random number generator
    private readonly Random _random = new Random();

    // create the primary constructor
    public JsonResponseProvider(string filePath)
    {
        // basic input/output, 
        // where we read all the text inside of the json document that is provided to the constructor
        string jsonData = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<ResponseData>(jsonData);
        _responses = data?.Responses ?? new List<string>();
    }

    public string GetResponse(string userInput)
    {
        // check if the List<string> is an empty collection or not
        if (_responses.Count == 0)
        {
            return "No responses was loaded, an error occured!";
        }
        return _responses[_random.Next(_responses.Count)];
    }

    private class ResponseData
    {
        public List<string>? Responses { get; set; }
    }
}