using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace ValorantReplays;

public class MinimalConsoleFormatter : ConsoleFormatter, IDisposable
{
    public MinimalConsoleFormatter() : base("minimal") { }

    public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider, TextWriter textWriter)
    {
        var formatter = logEntry.Formatter;
        if (formatter == null) return;
        string message = formatter(logEntry.State, logEntry.Exception);
        if (string.IsNullOrEmpty(message)) return;
        textWriter.WriteLine(message);
    }

    public void Dispose() { }
}
