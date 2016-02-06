using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WUApiLib;
using NetFwTypeLib;

namespace CBHelper
{
    public partial class Secure : Form
    {
        public Secure()
        {
            InitializeComponent();
        }

        private void Chocolatey_Click(object sender, EventArgs e)
        {
            exec_cmd("@powershell -NoProfile -ExecutionPolicy Bypass -Command \"iex((new- object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))\" && SET PATH=%PATH%;%ALLUSERSPROFILE%\\chocolatey\bin");
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
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/C " + arguments;
            Process.Start(proc1);
        }
    }
}
