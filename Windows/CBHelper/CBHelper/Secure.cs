using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WUApiLib;
using NetFwTypeLib;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Principal;

namespace CBHelper
{
    public partial class Secure : Form
    {

        TextWriter writer = null;

        public Secure()
        {
            InitializeComponent();
        }

        private void Secure_Load(object sender, EventArgs e)
        {
            writer = new TextBoxStreamWriter(ConsoleText);
            Console.SetOut(writer);
        }

        private void Chocolatey_Click(object sender, EventArgs e)
        {
            exec_cmd("@powershell -NoProfile -ExecutionPolicy Bypass -Command \"iex((new- object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))\" && SET PATH=%PATH%;%ALLUSERSPROFILE%\\chocolatey\bin");
        }

        private void DiagHTML_Click(object sender, EventArgs e)
        {
            string path = @"HTMLDiag.html";
            int uptime = Environment.TickCount & Int32.MaxValue;
            string time = DateTime.Now.ToShortTimeString();

            try
            {

                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(path);
                }

                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    string media = FindMedia();
                    Byte[] info = new UTF8Encoding(true).GetBytes(
                        "<html><head><title>"+Environment.MachineName+" | " + time + "</title></head>"+
                        "<body><h1>System info</h1><p>"+ time + "</p>"+
                        "<h2>System uptime</h2><pre>"+ uptime/600000 + " minutes</pre>"+
                        "<h2>Attempt to find media files</h2>"+
                        "<pre>"+
                        media + "</pre>"+
                        "</pre></body></head>");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #region Installs
        #region Firefox
        private void InstallFirefox_Click(object sender, EventArgs e)
        {
            exec_cmd("choco install firefox -y");
        }

        private void UpdateFirefox_Click(object sender, EventArgs e)
        {
            exec_cmd("choco upgrade firefox -y");
        }
        #endregion

        #region Malwarebytes
        private void InstallMalwarebytes_Click(object sender, EventArgs e)
        {
            exec_cmd("choco install malwarebytes -y");
        }
        #endregion

        #region Spybot - Search and Destroy
        private void InstallSpybot_Click(object sender, EventArgs e)
        {
            exec_cmd("choco install spybot");
        }
        #endregion
        #endregion

        #region User Commands
        private void DisableGuest_Click(object sender, EventArgs e)
        {
            exec_cmd("net user Guest /active:no");
        }

        private void PasswordPolicy_Click(object sender, EventArgs e)
        {
            exec_cmd("net accounts /lockoutthreshold:5 && net accounts /MINPWLEN:12 /MAXPWAGE:30 /UNIQUEPW:3 && @powershell Start-process secpol.msc");
        }
        #endregion

        #region Updates and Policy
        private void EnableUpdates_Click(object sender, EventArgs e)
        {
            AutomaticUpdates auc = new AutomaticUpdates();
            auc.Settings.NotificationLevel = AutomaticUpdatesNotificationLevel.aunlNotifyBeforeInstallation;
            if (!auc.Settings.ReadOnly)
                auc.Settings.Save();

            exec_cmd("control update");
        }

        private void ConfigureFirewall_Click(object sender, EventArgs e)
        {
            Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);
            INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(NetFwMgrType);
            bool Firewallenabled = mgr.LocalPolicy.CurrentProfile.FirewallEnabled;
            mgr.LocalPolicy.CurrentProfile.FirewallEnabled = true;
            Console.WriteLine("Firewall enabled");

            // Might do something with this later
            /*INetFwOpenPorts ports;
            INetFwOpenPort port;
            port.Port = 8080;
            port.Name = "Application1";
            port.Enabled = true;
            ports = (INetFwOpenPorts)mgr.LocalPolicy.CurrentProfile.GloballyOpenPorts;
            ports.Add(port);*/
        }

        private void SetupAuditing_Click(object sender, EventArgs e)
        {
            object[] items = AuditList.CheckedItems.OfType<object>().ToArray();
            foreach (string item in items)
            {
                exec_cmd("auditpol.exe /set /category:" + item + " /failure:enable");
            }
        }
        #endregion
        
        /// <summary>
        /// Execute a command in Command Prompt.
        /// </summary>
        /// <param name="arguments">Command to run.</param>
        private void exec_cmd(string arguments)
        {
            var proc1 = new ProcessStartInfo();
            Process p = new Process();
            proc1.UseShellExecute = false;
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.RedirectStandardOutput = true;
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/C " + arguments;
            p.StartInfo = proc1;
            p.Start();

            string consoleOutput = p.StandardOutput.ReadToEnd();
            Console.Write(consoleOutput);
            p.WaitForExit();
        }

        // TODO: Finish this.
        /// <summary>
        /// Searches for media files in the Users directory. Currently fails because of permission errors.
        /// </summary>
        /// <returns></returns>
        private string FindMedia()
        {
            string result = "";
            try
            {
                var files = from file in
                   Directory.EnumerateFiles(@"C:\Users", "*.jpg", SearchOption.AllDirectories)
                            select file;

                // Show results.
                foreach (var file in files)
                {
                    result += file.ToString() +"\n";
                }
                Console.WriteLine("{0} jpgs found.",
                    files.Count<string>().ToString());
            }

            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }

            return result;
        }
    }
}
