using System.Text.Json;
/// <summary>
/// An example class, that helps visualise the serialization process in computing.
/// </summary>
public class SerializeToJson
{
    private readonly Dictionary<string, string> _updateTextPhrases = new Dictionary<string, string>(
    )
    {
        {"Hello","There"},
        {"Hello JSON", "Helloo"}
    };

    public void SaveToDocument(string filePath)
    {
        var jsonData = JsonSerializer.Serialize(_updateTextPhrases);
        File.WriteAllText(filePath, jsonData);
    }
}