public class MainChatbot
{
    // create a private readonly IReponseProvider field
    private readonly IResponseProvider _responseProvider;
    // private readonly DebuggableResponseProvider _debug = new DebuggableResponseProvider(null!);
    private readonly ISystemLogger _logger;

    public MainChatbot(IResponseProvider responseProvider, ISystemLogger logger)
    {
        _responseProvider = responseProvider;
        _logger = logger;
    }

    // Create the main chat loop
    public void RunMainloop()
    {
        ConsoleView.PrintSystemMessage("Chatbot started! Type 'exit' to quit the program...");

        while (true)
        {
            try
            {
                string input = PromptUser.GetUserPrompt();

                if (input!.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                // handle user input, and output a response phrase
                string response = _responseProvider.GetResponse(input);
                ConsoleView.PrintBotMessage(response);
            }
            catch (Exception ex)
            {
                _logger.ExceptionThrown = true; // This is mutability in action
                if (_logger.ExceptionThrown)
                {
                    break;
                }
                _logger.Log($"An exception occured: {ex.Message}");

                ConsoleView.PrintSystemMessage("An internal error occured. Check the logfile: events.log");
            }
        }
    }
}