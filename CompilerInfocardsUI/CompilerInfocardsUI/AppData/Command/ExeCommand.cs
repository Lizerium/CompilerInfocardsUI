/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 08 августа 2026 06:52:02
 * Version: 1.0.350
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
