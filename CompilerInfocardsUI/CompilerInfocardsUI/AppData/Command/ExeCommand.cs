/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 11 июля 2026 14:00:28
 * Version: 1.0.322
 */

namespace CompilerInfocardsUI.AppData.Command
{
    public class ExeCommand
    {
        public string ExePath { get; set; }
        public string Arguments { get; set; }

        public ExeCommand(string exePath, string arguments)
        {
            ExePath = exePath;
            Arguments = arguments;
        }
    }
}
