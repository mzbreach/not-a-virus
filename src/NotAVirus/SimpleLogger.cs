using System;
using System.IO;

namespace NotAVirus;

internal sealed class SimpleLogger
{
    private readonly string _logFilePath;

    public SimpleLogger()
    {
        string baseDirectory = AppContext.BaseDirectory;
        string logDirectory = Path.Combine(baseDirectory, "logs");
        Directory.CreateDirectory(logDirectory);

        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        _logFilePath = Path.Combine(logDirectory, $"not-a-virus_{timestamp}.log");
    }

    public static SimpleLogger Start()
    {
        SimpleLogger logger = new();
        logger.Info("Application started");
        return logger;
    }

    public void Info(string message) => Write("INFO", message);

    public void Warn(string message) => Write("WARN", message);

    public void Debug(string message) => Write("DEBUG", message);

    private void Write(string level, string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        File.AppendAllText(_logFilePath, $"[{timestamp}] [{level}] {message}{Environment.NewLine}");
    }
}
