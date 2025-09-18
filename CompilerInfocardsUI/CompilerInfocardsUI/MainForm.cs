/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 18 сентября 2025 06:52:13
 * Version: 1.0.21
 */

using System.Threading.Tasks;

using CompilerInfocardsUI.AppData.Command;
using CompilerInfocardsUI.Services;

namespace CompilerInfocardsUI
{
    public partial class MainForm : Form
    {
        private readonly CommandServices commandServices;
        private Dictionary<string, ExeCommand> commands;

        public MainForm()
        {
            commandServices = new CommandServices("configs.json");
            commands = commandServices.Commands;
            commandServices.LogAction += CommandServiceLog;
            InitializeComponent();

            var currentPath = AppDomain.CurrentDomain.BaseDirectory;



            //            commands = new Dictionary<string, ExeCommand>
            //            {
            //                { "TEST", new ExeCommand("notepad.exe", "") },
            //                { "VSCODE", new ExeCommand("cmd.exe",$"/C code \"{currentPath}\"" ) },
            //                { "ALL", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\ALL_merged.frc .\\ALL.dll") },
            //#region keys html and strings compile
            //                { "SBM_ALL", new ExeCommand("frc.exe", "-c .\\FRC\\MergedStrings\\FRC_RELEASE\\SBM.frc .\\SBM.dll") },
            //                { "SBM3_ALL", new ExeCommand("frc.exe", "-c .\\FRC\\MergedStrings\\FRC_RELEASE\\SBM3.frc .\\SBM3.dll") },
            //#endregion
            //#region keys html compile
            //                { "infocards_HTML", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_InfoCards_original.frc .\\infocards.dll") },
            //                { "SBM2_HTML", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_SBM2_original.frc .\\SBM2.dll") },
            //                { "misctextinfo2_HTML", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_MiscTextInfo2_original.frc .\\misctextinfo2.dll") },
            //                { "misctext_HTML", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_MiscText_original.frc .\\misctext.dll") },
            //                { "equipresources_HTML", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_EquipResources_original.frc .\\equipresources.dll") },
            //#endregion
            //#region keys strings compile
            //                { "SBM2_STRINGS", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\SBM2_merged.frc .\\SBM2.dll") },
            //                { "offerbriberesources_STRINGS", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\OfferBribeResources_merged.frc .\\offerbriberesources.dll") },
            //                { "equipresources_STRINGS", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\EquipResources_merged.frc .\\equipresources.dll") },
            //                { "nameresources_STRINGS", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\NameResources_merged.frc .\\nameresources.dll") },
            //                { "resources_STRINGS", new ExeCommand("frc.exe", ".\\FRC\\MergedStrings\\resources_merged.frc .\\resources.dll") },
            //#endregion
            //#region keys edit
            //                { "SBM_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\FRC_RELEASE\\SBM.frc\"") },
            //                { "SBM2_STRINGS_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\SBM2_merged.frc\"") },
            //                { "SBM2_HTML_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_SBM2_original.frc\"") },
            //                { "SBM3_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\FRC_RELEASE\\SBM3.frc\"") },
            //                { "resources_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\resources_merged.frc\"") },
            //                { "infocards_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_InfoCards_original.frc\"") },
            //                { "misctext_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_MiscText_original.frc\"") },
            //                { "nameresources_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\NameResources_merged.frc\"") },
            //                { "equipresources_STRINGS_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\EquipResources_merged.frc\"") },
            //                { "equipresources_HTML_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_EquipResources_original.frc\"") },
            //                { "offerbriberesources_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\OfferBribeResources_merged.frc\"") },
            //                { "misctextinfo2_EDIT", new ExeCommand("cmd.exe", "/C code \".\\FRC\\MergedStrings\\FRC_HTML_ORIGINAL\\HTML_MiscTextInfo2_original.frc\"") },
            //#endregion
            //            };
        }

        private async void materialButton_ALL_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM_ALL");
            await RunCommand("SBM3_ALL");
            await RunCommand("infocards_HTML");
            await RunCommand("SBM2_HTML");
            await RunCommand("misctextinfo2_HTML");
            await RunCommand("misctext_HTML");
            await RunCommand("equipresources_HTML");
            await RunCommand("SBM2_STRINGS");
            await RunCommand("offerbriberesources_STRINGS");
            await RunCommand("equipresources_STRINGS");
            await RunCommand("nameresources_STRINGS");
            await RunCommand("resources_STRINGS");
        }

        #region STRINGS COMPILE

        private async void materialButton_STRINGS_SBM2_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM2_STRINGS");
        }

        private async void materialButton_STRINGS_offerbriberesources_Click(object sender, EventArgs e)
        {
            await RunCommand("offerbriberesources_STRINGS");
        }

        private async void materialButton_STRINGS_equipresources_Click(object sender, EventArgs e)
        {
            await RunCommand("equipresources_STRINGS");
        }

        private async void materialButton_STRINGS_nameresources_Click(object sender, EventArgs e)
        {
            await RunCommand("nameresources_STRINGS");
        }

        private async void materialButton_STRINGS_resources_Click(object sender, EventArgs e)
        {
            await RunCommand("resources_STRINGS");
        }


        #endregion

        #region HTML COMPILE

        private async void materialButton_HTML_infocards_Click(object sender, EventArgs e)
        {
            await RunCommand("infocards_HTML");
        }

        private async void materialButton_HTML_SBM2_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM2_HTML");
        }

        private async void materialButton_HTML_misctextinfo2_Click(object sender, EventArgs e)
        {
            await RunCommand("misctextinfo2_HTML");
        }

        private async void materialButton_HTML_misctext_Click(object sender, EventArgs e)
        {
            await RunCommand("misctext_HTML");
        }

        private async void materialButtonHTML_equipresources_Click(object sender, EventArgs e)
        {
            await RunCommand("equipresources_HTML");
        }

        #endregion

        #region HTML AND STRING COMPILE

        private async void materialButton_ALL_SBM_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM_ALL");
        }

        private async void materialButton_ALL_SBM3_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM3_ALL");

        }

        #endregion

        #region EDIT FILES
        private async void materialButton_Open_DLLS_Click(object sender, EventArgs e)
        {
            await RunCommand("RootDLLS");
        }

        private async void materialButton_VSCODE_Click(object sender, EventArgs e)
        {
            await RunCommand("VSCODE");
        }

        private async void materialButton_E_SBM_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM_EDIT");
        }

        private async void materialButton_E_SBM2_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM2_STRINGS_EDIT");
            await RunCommand("SBM2_HTML_EDIT");
        }

        private async void materialButton_E_SBM3_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM3_EDIT");
        }

        private async void materialButton_E_resources_Click(object sender, EventArgs e)
        {
            await RunCommand("resources_EDIT");
        }

        private async void materialButton_E_infocards_Click(object sender, EventArgs e)
        {
            await RunCommand("infocards_EDIT");
        }

        private async void materialButton_E_misctext_Click(object sender, EventArgs e)
        {
            await RunCommand("misctext_EDIT");
        }

        private async void materialButton_E_nameresources_Click(object sender, EventArgs e)
        {
            await RunCommand("nameresources_EDIT");
        }

        private async void materialButton_E_equipresources_Click(object sender, EventArgs e)
        {
            await RunCommand("equipresources_STRINGS_EDIT");
            await RunCommand("equipresources_HTML_EDIT");
        }

        private async void materialButton_E_offerbriberesources_Click(object sender, EventArgs e)
        {
            await RunCommand("offerbriberesources_EDIT");
        }

        private async void materialButton_E_misctextinfo2_Click(object sender, EventArgs e)
        {
            await RunCommand("misctextinfo2_EDIT");
        }

        #endregion

        private async Task RunCommand(string key)
        {
            if (commands.TryGetValue(key, out var cmd))
            {
                await commandServices.RunExeCommand(cmd.ExePath, cmd.Arguments);
                textBoxLog.AppendText($"🔥 Выполнена команда: {key}" + Environment.NewLine);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }
            else
            {
                textBoxLog.AppendText($"💤 Команда {key} не найдена!" + Environment.NewLine);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }
        }

        private void CommandServiceLog(string msg)
        {
            textBoxLog.AppendText(msg + Environment.NewLine);
            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.ScrollToCaret();
        }
    }
}
