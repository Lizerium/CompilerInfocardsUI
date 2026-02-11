/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 11 февраля 2026 09:14:24
 * Version: 1.0.167
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
