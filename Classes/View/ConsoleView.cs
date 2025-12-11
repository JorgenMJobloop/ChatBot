using Spectre.Console;
/// <summary>
/// The terminal-ui (TUI) for the ChatBot application, using Spectre.Console as UI-library
/// </summary>
public static class ConsoleView
{
    public static void PrintBotMessage(string message)
    {
        var panel = new Panel(message)
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Blue)
            .Header("[yellow]Bot[/]");
        AnsiConsole.Write(panel);
    }

    // helper method, print system messages & log errors to a file
    public static void PrintSystemMessage(string message)
    {
        AnsiConsole.MarkupLine($"[grey]System:{message}[/]");
    }
}