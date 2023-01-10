using System.IO;
using System.Text;

public static class Logger {
    public static string Location { get; set; }
    public static string CurrentLoan{ get; set; }
    public static AccessDatabase CurrentDb{ get; set; }
    public static void LogError(string error){
        error = "ERROR: " + error;
        Log(error);
    }

    public static void LogLoanError(string error){
        error = $"{CurrentLoan}: {error}";
        LogError(error);
    }

    public static void ReadingDb(){
        string msg = $"Reading from {CurrentDb.Name} at {CurrentDb.Location}";
        LogInfo(msg);
    }

    public static void LogInfo(string msg)
    {
        msg = "INFO: " + msg;
        Log(msg);
    }

    public static void LogLoanInfo(string msg){
        msg = $"{CurrentLoan}: {msg}";
        LogInfo(msg);
    }

    public static void LogWarn(string warn){
        warn = "WARN: " + warn;
        Log(warn);
    }

    public static void LogLoanWarn(string warn){
        warn = $"{CurrentLoan}: {warn}";
        LogWarn(warn);
    }

    private static void Log(string msg){
        msg += "\n";
        File.AppendAllText(Location, msg);
    }

}