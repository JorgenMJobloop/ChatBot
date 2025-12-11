namespace ChatBot;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Serializing C# Dictionary values, to JSON format.");
        // SerializeToJson serializeToJson = new SerializeToJson();
        // Console.WriteLine("Writing changes to JSON document.");
        // serializeToJson.SaveToDocument("example.json");
        // Console.Read();
        // create a new instance object of our service class
        IResponseProvider provider = new JsonResponseProvider("responses.json");
        ISystemLogger logger = new SystemLogger("events.log");
        // create a new instance object of our chatbot class
        MainChatbot chatbot = new MainChatbot(provider, logger);

        //List<MainChatbot> chatbotList = new();

        // Run the chatbot's main loop.
        chatbot.RunMainloop();

        //chatbotList.Add(chatbot);
        //Console.WriteLine(chatbotList.Count()); // check the count, if it is 0, it was not properly assigned, if it is 1, it works.
    }
}
