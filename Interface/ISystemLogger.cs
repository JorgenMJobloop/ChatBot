public interface ISystemLogger
{
    // property
    bool ExceptionThrown { get; set; }

    void Log(string message);
}