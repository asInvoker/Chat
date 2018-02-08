namespace Core.Logging
{
    public interface ILogger
    {
        string Name { get; set; }

        void Trace(string traceMessage);
        void Debug(string debugMessage);
        void Info(string infoMessage);
        void Warn(string warnMessage);
        void Error(string errorMessage);
        void Fatal(string fatalErrorMessage);
    }
}
