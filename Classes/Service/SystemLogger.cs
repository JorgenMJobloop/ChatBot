public class SystemLogger : ISystemLogger
{
    public bool ExceptionThrown { get; set; } // implementing the property from the interface, now as a field

    // private readonly field, that hold the file path to the logfile to create.
    private readonly string _logfilePath; // encapsulated field, we need to make this visible outside of this class, by using a constructor

    public SystemLogger(string logfilePath)
    {
        _logfilePath = logfilePath; // now the private field, takes ownership of the argument passed to the primary constructor, it is still not visible to other classes & objects, outside of this class.

        // we can ensure, that the file exists or not, by checking inside the constructor, rather than inside of a method.
        if (!File.Exists(_logfilePath))
        {
            // create a new log file, the underscore, signifies a "discarded" variable, this is because, the variable only has a use-case once, and this if-statement will only ever be true one time.
            using var _ = File.Create(_logfilePath);
        }
    }

    public void Log(string message)
    {
        if (!ExceptionThrown)
        {
            return; // we only log something to the logfile, when we need to.
        }

        // create a formatted string.
        string formatted = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}\n";
        // append the formatted string as text data, to the log file
        File.AppendAllText(_logfilePath, formatted);
    }
}