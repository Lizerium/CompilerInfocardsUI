/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 10 января 2026 06:52:00
 * Version: 1.0.135
 */

using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

using CompilerInfocardsUI.AppData.Command;

namespace CompilerInfocardsUI.Services
{
    public class CommandServices
    {
        public Action<string> LogAction;
        public Dictionary<string, ExeCommand> Commands { get; private set; } = new Dictionary<string, ExeCommand>();

        public CommandServices(string jsonPath)
        {
            LoadCommands(jsonPath);
        }

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
                        LogAction?.Invoke($"[{exePath}] STDOUT: {ev.Data}{Environment.NewLine}");
                };

                process.ErrorDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                        LogAction?.Invoke($"[{exePath}] STDERR: {ev.Data}{Environment.NewLine}");
                };

                process.EnableRaisingEvents = true;
                process.Exited += (s, ev) =>
                {
                    if (!tcs.Task.IsCompleted)
                        tcs.SetResult(true);
                    process.Dispose();
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await tcs.Task; // дожидаемся завершения процесса
            }
            catch (Win32Exception ex)
            {
                LogAction?.Invoke($"⚠ Ошибка Win32 при запуске {exePath}: {ex.Message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                LogAction?.Invoke("Ошибка запуска: " + ex.Message + Environment.NewLine);
            }
        }

        private void LoadCommands(string jsonPath)
        {
            if (!File.Exists(jsonPath))
                throw new FileNotFoundException($"Файл команд не найден: {jsonPath}");

            string json = File.ReadAllText(jsonPath);
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var doc = JsonSerializer.Deserialize<CommandsRoot>(json, jsonOptions);

            // создаём словарь
            Commands = doc.Commands.ToDictionary(
                x => x.Key,
                x => new ExeCommand(x.ExePath, x.Arguments.Replace("{currentPath}", AppDomain.CurrentDomain.BaseDirectory))
            );
        }
    }
}
