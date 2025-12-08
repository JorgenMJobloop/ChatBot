public interface IResponseProvider
{
    /// <summary>
    /// Give a response from the chatbot to the user
    /// </summary>
    /// <param name="userInput">user input as text</param>
    /// <returns>text response</returns>
    string GetResponse(string userInput);
}