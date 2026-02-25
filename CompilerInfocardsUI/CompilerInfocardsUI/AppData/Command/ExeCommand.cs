/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 25 февраля 2026 14:01:35
 * Version: 1.0.181
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
