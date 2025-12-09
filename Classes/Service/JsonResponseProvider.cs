using System.Data;
using System.Text;
using System.Text.Json;
public class JsonResponseProvider : IResponseProvider
{
    // create a private readonly List<string> field of default responses
    private readonly List<string> _defaultResponses;
    // create a private readonly Random number generator
    private readonly Random _random = new Random();
    // create a private readonly Rule field, to keep track of precedence in our algorithm
    private readonly List<Rules> _rules;

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
        _rules = data?.Rules ?? new List<Rules>();
        _defaultResponses = data?.DefaultResponses ?? new List<string>();
    }

    public string GetResponse(string userInput)
    {
        string lower = userInput.ToLowerInvariant();
        // keeping track of the best rule score for the Rules model
        Rules? bestRuleScore = null;
        // precedence in our algorithm, increases with 1 when a keyword is matched
        int bestScore = 0;

        // Scoring step: check each rule, 
        // rule 1 = 1, 
        // rule 2 = 2, 
        // rule 3 = 0

        foreach (var rule in _rules)
        {
            if (rule.Keywords == null || rule.Keywords.Count == 0)
            {
                continue;
            }
            // keep track of a score internally inside the foreach loop
            int score = 0;

            // do a nested foreach loop(algorithm step)
            foreach (var keyword in rule.Keywords!)
            {
                string k = keyword.ToLowerInvariant(); // keep track of every individual keyword

                // strongly matched (score 3)
                if (lower == k || lower.Split(' ').Contains(k))
                {
                    // any of the two statements in the condition above is true
                    // we set the score to 3, and continue the loop
                    score += 3; // strong match
                    continue;
                }

                // loosely matched(weak match), score = 1
                if (lower.Contains(k))
                {
                    score += 1;
                }

            }
            // do swapping based on the current best scores
            if (score > bestScore)
            {
                bestScore = score;
                bestRuleScore = rule; // if this is true & not null, we have found a match.
            }
        }

        // if we have found a "winner" so a score greather than or equal to 2
        // we return this scored response
        if (bestRuleScore != null && bestRuleScore.Response != null && bestRuleScore.Response.Count > 0)
        {
            return bestRuleScore.Response[_random.Next(bestRuleScore.Response.Count)];
        }

        // if we dont find a match at all (or the user does not trigger any keywords)
        // we fall back to our default responses.
        if (_defaultResponses.Count > 0)
        {
            return _defaultResponses[_random.Next(_defaultResponses.Count)];
        }

        // if we either do not get a match at all, or something else fails entirely in the program
        // we return with an error message
        return "No responses found in the JSON file, an unexpected error occured!";
    }

    public string DebugMatch(string userInput)
    {
        // configuring steps for debugging
        // otherwise, the algorithm is exactly the same way as in the GetResponse method
        var sb = new StringBuilder(); // create a new instance of the stringbuilder class
        string lower = userInput.ToLowerInvariant();

        // "build" the debug string using StringBuilder
        sb.AppendLine($"DEBUG: Current scoring for input: \"{userInput}\"");
        sb.AppendLine(new string('-', 40));

        Rules bestRuleScore = null!;
        int bestScore = 0;

        foreach (var rule in _rules)
        {
            int score = 0;

            if (rule.Keywords != null)
            {
                foreach (var keyword in rule.Keywords)
                {
                    if (lower.Contains(keyword.ToLowerInvariant()))
                    {
                        score++;
                    }
                }
            }

            sb.AppendLine($"-> Rule: [{string.Join(", ", rule.Keywords! ?? new List<string>())}] -> Score: {score}");

            if (score > bestScore)
            {
                bestScore = score;
                bestRuleScore = rule;
            }
        }

        sb.AppendLine(new string('-', 40));

        if (bestRuleScore != null)
        {
            sb.AppendLine("Winner rule:");
            sb.AppendLine($"Keywords: {string.Join(", ", bestRuleScore.Keywords!)}");
            sb.AppendLine($"Possible responses: {bestRuleScore.Response!.Count}");
        }
        else
        {
            sb.AppendLine("No rule matches was found at all. Only default responses will be used.");
        }

        return sb.ToString();
    }
}