/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 14 декабря 2025 14:34:12
 * Version: 1.0.108
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
