namespace OVERLIMIT.Utility.Logging
{
    public enum LogLevels
    {
        // Controls visibility via LogSettings.MinimumLevel. Different levels change console filtering.
        None = 0, // Default fallback to ensure enum safety and prevent initialization bugs.
        Success = 1, // Displays all logs (Success, Warning, Error).
        Warning = 2, // Displays Warnings and Errors.
        Error = 3, // Displays Errors only.
        Off = 4, // Completely mutes all logger outputs.
    }
}
