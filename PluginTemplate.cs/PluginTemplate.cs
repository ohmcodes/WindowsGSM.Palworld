using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using WindowsGSM.Functions;
using WindowsGSM.GameServer.Engine;
using WindowsGSM.GameServer.Query;
using System.Collections.Generic;

namespace WindowsGSM.Plugins
{
    public class PluginTemplate : SteamCMDAgent
    {
        // - Plugin Details
        public Plugin Plugin = new Plugin
        {
            name = "WindowsGSM.PluginTemplate", // WindowsGSM.XXXX
            author = "ohmcodes",
            description = "WindowsGSM plugin for supporting PluginTemplate Dedicated Server",
            version = "1.0",
            url = "https://github.com/ohmcodes/WindowsGSM.PluginTemplate", // Github repository link (Best practice)
            color = "#1E8449" // Color Hex
        };

        // - Standard Constructor and properties
        public PluginTemplate(ServerConfig serverData) : base(serverData) => base.serverData = _serverData = serverData;
        private readonly ServerConfig _serverData;
        public string Error, Notice;

        // - Settings properties for SteamCMD installer
        public override bool loginAnonymous => false;
        public override string AppId => "420"; /* taken via https://steamdb.info/app/420/info/ */

        // - Game server Fixed variables
        public override string StartPath => "executable.exe"; // Game server start path
        public string FullName = "PluginTemplate Dedicated Server"; // Game server FullName
        public bool AllowsEmbedConsole = true;  // Does this server support output redirect?
        public int PortIncrements = 0; // This tells WindowsGSM how many ports should skip after installation
        public object QueryMethod = new A2S(); // Query method should be use on current server type. Accepted value: null or new A2S() or new FIVEM() or new UT3()

        // - Game server default values
        public string ServerName = "PluginTemplate";
        public string Defaultmap = ""; // Original (MapName)
        public string Maxplayers = "10"; // WGSM reads this as string but originally it is number or int (MaxPlayers)
        public string Port = "27015"; // WGSM reads this as string but originally it is number or int
        public string QueryPort = "27016"; // WGSM reads this as string but originally it is number or int (SteamQueryPort)
        public string Additional = string.Empty;


        private Dictionary<string, string> configData = new Dictionary<string, string>();


        // - Create a default cfg for the game server after installation
        public async void CreateServerCFG()
        {

        }

        // - Start server function, return its Process to WindowsGSM
        public async Task<Process> Start()
        {
            string shipExePath = Functions.ServerPath.GetServersServerFiles(_serverData.ServerID, StartPath);
            if (!File.Exists(shipExePath))
            {
                Error = $"{Path.GetFileName(shipExePath)} not found ({shipExePath})";
                return null;
            }

            string param = string.Empty;

            // Prepare Process
            var p = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = ServerPath.GetServersServerFiles(_serverData.ServerID),
                    FileName = shipExePath,
                    Arguments = param.ToString(),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false

                },
                EnableRaisingEvents = true
            };

            // Set up Redirect Input and Output to WindowsGSM Console if EmbedConsole is on
            if (AllowsEmbedConsole)
            {
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                var serverConsole = new ServerConsole(_serverData.ServerID);
                p.OutputDataReceived += serverConsole.AddOutput;
                p.ErrorDataReceived += serverConsole.AddOutput;
            }

            // Start Process
            try
            {
                p.Start();
                if (AllowsEmbedConsole)
                {
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                }

                return p;
            }
            catch (Exception e)
            {
                Error = e.Message;
                return null; // return null if fail to start
            }
        }

        // - Stop server function
        public async Task Stop(Process p)
        {
            await Task.Run(() =>
            {
                Functions.ServerConsole.SetMainWindow(p.MainWindowHandle);
                Functions.ServerConsole.SendWaitToMainWindow("^c");
            });
            await Task.Delay(20000);
        }

        // - Update server function
        public async Task<Process> Update(bool validate = false, string custom = null)
        {
            var (p, error) = await Installer.SteamCMD.UpdateEx(serverData.ServerID, AppId, validate, custom: custom, loginAnonymous: loginAnonymous);
            Error = error;
            await Task.Run(() => { p.WaitForExit(); });
            return p;
        }

        public bool IsInstallValid()
        {
            return File.Exists(Functions.ServerPath.GetServersServerFiles(_serverData.ServerID, StartPath));
        }

        public bool IsImportValid(string path)
        {
            string exePath = Path.Combine(path, "PackageInfo.bin");
            Error = $"Invalid Path! Fail to find {Path.GetFileName(exePath)}";
            return File.Exists(exePath);
        }

        public string GetLocalBuild()
        {
            var steamCMD = new Installer.SteamCMD();
            return steamCMD.GetLocalBuild(_serverData.ServerID, AppId);
        }

        public async Task<string> GetRemoteBuild()
        {
            var steamCMD = new Installer.SteamCMD();
            return await steamCMD.GetRemoteBuild(AppId);
        }
    }
}
