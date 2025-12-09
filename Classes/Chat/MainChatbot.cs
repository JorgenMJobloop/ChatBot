public class MainChatbot
{
    // create a private readonly IReponseProvider field
    private readonly IResponseProvider _responseProvider;
    private readonly DebuggableResponseProvider _debug = new DebuggableResponseProvider(null!);

    public MainChatbot(IResponseProvider responseProvider)
    {
        _responseProvider = responseProvider;
    }

    // Create the main chat loop
    public void RunMainloop()
    {
        Console.WriteLine("Chatbot started! Type 'exit' to quit the program...");

        while (true)
        {
            Console.Write("> ");
            // get user input
            var input = Console.ReadLine();
            // validate user input
            if (input!.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            // handle user input, and output a response phrase
            string response = _responseProvider.GetResponse(input);
            Console.WriteLine($"Bot: {response}");
        }
    }
}