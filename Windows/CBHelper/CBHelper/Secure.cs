using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WUApiLib;
using NetFwTypeLib;
using System.IO;
using System.Text;

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

        // Basically completely pointless and inefficient, but I decided "I can do this... I should do this."
        private void DiagHTML_Click(object sender, EventArgs e)
        {
            string path = @"HTMLDiag.html";
            int uptime = Environment.TickCount & Int32.MaxValue;
            string time = DateTime.Now.ToShortTimeString();
            //string media = FindMedia();
            Process[] processlist = Process.GetProcesses();
            string processes = "";

            foreach (Process process in processlist)
            {
                Console.WriteLine("Process: {0}   ID: {1}", process.ProcessName, process.Id);
                processes += "Process: " + process.ProcessName + "   ID: " + process.Id + "\n\n";
            }

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
                    Byte[] info = new UTF8Encoding(true).GetBytes(
                        "<html><head><title>"+Environment.MachineName+" | " + time + "</title></head>"+
                        "<body><h1>System info</h1><p>"+ time + "</p>"+
                        "<h2>System uptime</h2><pre>"+ uptime + " ms</pre>"+
                        "<h2>Current processes</h2>" +
                        "<pre>"+
                        processes +
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
                Process.Start(string.Format("http://stackoverflow.com/search?q=%5Bc%23%5D%20{0}", Uri.EscapeUriString(ex.Message)));
            }
        }

        // These buttons used to do something else,
        // but that other thing was stupid.
        // So now they run executables, because it was more work to remove them than reuse them.
        #region Installs
        #region Ninite
        private void Install8Ninite_Click(object sender, EventArgs e)
        {
            Process.Start(@"RandomTools\Ninite8.exe");
        }

        private void InstallNon8Ninite_Click(object sender, EventArgs e)
        {
            Process.Start(@"RandomTools\NiniteServer.exe");
        }
        #endregion

        #region Search Everything
        private void InstallSearch_Click(object sender, EventArgs e)
        {
            Process.Start(@"RandomTools\EverythingSetup.exe");
        }
        #endregion

        #region Unlocker
        private void InstallUnlocker_Click(object sender, EventArgs e)
        {
            Process.Start(@"RandomTools\Unlocker.exe");
        }
        #endregion

        #region MBSA
        private void InstallMBSA_Click(object sender, EventArgs e)
        {
            Process.Start(@"RandomTools\MBSASetup.msi");
        }
        #endregion

        #region CCleaner
        private void InstallCCleaner_Click(object sender, EventArgs e)
        {
            Process.Start(@"RandomTools\ccsetup.exe");
        }
        #endregion
        #endregion

        // These are cool
        #region User Commands
        // Disables guest account, if it is enabled
        private void DisableGuest_Click(object sender, EventArgs e)
        {
            ExecCommand("net user Guest /active:no");
        }
        
        // Set password policy to:
        // Three login attempts
        // Minimum length of 12
        // Max age until required reset of 60
        // Min age until resetable to 30
        // Have to go 3 passwords until an old one can be reused
        private void PasswordPolicy_Click(object sender, EventArgs e)
        {
            ExecCommand("net accounts /lockoutthreshold:3 && net accounts /MINPWLEN:12 /MAXPWAGE:60 /MINPWAGE:30 /UNIQUEPW:3 && @powershell Start-process secpol.msc");
        }
        #endregion

        // Also pretty cool. Wish I could do more with them.
        // Probably can, actually.
        #region Updates and Policy
        // Set updates to:
        // Download updates automatically
        // Notify before installing them
        private void EnableUpdates_Click(object sender, EventArgs e)
        {
            AutomaticUpdates auc = new AutomaticUpdates();
            auc.Settings.NotificationLevel = AutomaticUpdatesNotificationLevel.aunlNotifyBeforeInstallation;
            if (!auc.Settings.ReadOnly)
                auc.Settings.Save();

            ExecCommand("control update");
            Console.WriteLine("Set successfully");
        }

        // Turns the firewall on.
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
                ExecCommand("auditpol.exe /set /category:" + item + " /failure:enable /success:enable");
            }
        }
        #endregion
        
        /// <summary>
        /// Execute a command in Command Prompt.
        /// </summary>
        /// <param name="arguments">Command to run.</param>
        private void ExecCommand(string arguments)
        {
            var proc1 = new ProcessStartInfo();
            Process p = new Process();
            proc1.UseShellExecute = false;
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.RedirectStandardOutput = true;
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/C " + arguments;
            proc1.CreateNoWindow = true;
            p.StartInfo = proc1;
            p.Start();

            string consoleOutput = p.StandardOutput.ReadToEnd();
            Console.Write(consoleOutput);
            p.WaitForExit();
        }
    }
}
