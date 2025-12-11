using Spectre.Console;
/// <summary>
/// A wrapper for Spectre.Console's CLI promp classes (controller)
/// </summary>
public static class PromptUser
{
    public static string GetUserPrompt()
    {
        return AnsiConsole.Prompt(new TextPrompt<string>("[green]>[/]").PromptStyle("blue"));
    }
}