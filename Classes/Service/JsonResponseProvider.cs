using System.Text.Json;
public class JsonResponseProvider : IResponseProvider
{
    // create a private readonly Dictionary<string, string> field of keyword responses
    private readonly Dictionary<string, string> _keywordResponses;
    // create a private readonly List<string> field of default responses
    private readonly List<string> _defaultResponses;
    // create a private readonly Random number generator
    private readonly Random _random = new Random();

    // create the primary constructor
    public JsonResponseProvider(string filePath)
    {
        // basic input/output, 
        // where we read all the text inside of the json document that is provided to the constructor
        string jsonData = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<ResponseData>(
            jsonData,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        _keywordResponses = data?.KeywordResponses ?? new Dictionary<string, string>();
        _defaultResponses = data?.DefaultResponses ?? new List<string>();
    }

    public string GetResponse(string userInput)
    {
        // convert the userinput to lowercase
        string toLower = userInput.ToLowerInvariant();

        // loop through the dictionary and match the keywords.
        foreach (var entry in _keywordResponses)
        {
            if (toLower.Contains(entry.Key.ToLowerInvariant()))
            {
                return entry.Value;
            }
        }

        // the first if-statement simply checks that the data is loaded correctly, 
        // otherwise, 
        // the list is not empty and this statement can be ignored.
        if (_defaultResponses.Count == 0)
        {
            return "No responses was loaded from the JSON document. An error occured.";
        }
        // if we get keywords or phrases that are not recognized, 
        // we simply return a random value in the response
        return _defaultResponses[_random.Next(_defaultResponses.Count)];

    }

    private class ResponseData
    {
        public Dictionary<string, string>? KeywordResponses { get; set; }
        public List<string>? DefaultResponses { get; set; }
    }
}