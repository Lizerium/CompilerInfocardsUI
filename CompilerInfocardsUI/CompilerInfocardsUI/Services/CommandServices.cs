using System.Diagnostics;
using System.Windows.Forms;

namespace CompilerInfocardsUI.Services
{
    public class CommandServices
    {
        public Action<string> LogAction;

        /// <summary>
        /// Запускает программу с параметрами
        /// 
        /// Например:
        ///  exePath = @".\frc.exe";
        ///  args = @".\FRC\MergedStrings\FRC_HTML_ORIGINAL\HTML_InfoCards_original.frc .\infocards.dll";
        /// </summary>
        /// <param name="exePath">путь к exe</param>
        /// <param name="args">аргументы</param>
        public async Task RunExeCommand(string exePath, string args = "")
        {
            try
            {
                var tcs = new TaskCompletionSource<bool>();

                var process = new Process();
                process.StartInfo.FileName = exePath;
                process.StartInfo.Arguments = args;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.OutputDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                        LogAction.Invoke("Вывод: " + exePath + Environment.NewLine);
                };

                process.ErrorDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                        LogAction.Invoke("Ошибка: " + exePath + Environment.NewLine);
                };

                process.EnableRaisingEvents = true;
                process.Exited += (s, ev) =>
                {
                    tcs.SetResult(true);
                    process.Dispose();
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await tcs.Task; // дожидаемся завершения процесса
            }
            catch (Exception ex)
            {
                LogAction.Invoke("Ошибка запуска: " + ex.Message + Environment.NewLine);
            }
        }
    }
}
