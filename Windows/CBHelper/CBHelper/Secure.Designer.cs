namespace CBHelper
{
    partial class Secure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InstallFirefox = new System.Windows.Forms.Button();
            this.Chocolatey = new System.Windows.Forms.Button();
            this.UpdateFirefox = new System.Windows.Forms.Button();
            this.FirefoxLabel = new System.Windows.Forms.Label();
            this.UserCommandsLabel = new System.Windows.Forms.Label();
            this.DisableGuest = new System.Windows.Forms.Button();
            this.UpdatePolicyLabel = new System.Windows.Forms.Label();
            this.EnableUpdates = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InstallMalwarebytes = new System.Windows.Forms.Button();
            this.MalwarebytesLabel = new System.Windows.Forms.Label();
            this.ConfigureFirewall = new System.Windows.Forms.Button();
            this.PasswordPolicy = new System.Windows.Forms.Button();
            this.PassReminder = new System.Windows.Forms.TextBox();
            this.SpybotLabel = new System.Windows.Forms.Label();
            this.InstallSpybot = new System.Windows.Forms.Button();
            this.SetupAuditing = new System.Windows.Forms.Button();
            this.AuditList = new System.Windows.Forms.CheckedListBox();
            this.AuditReminder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InstallFirefox
            // 
            this.InstallFirefox.Location = new System.Drawing.Point(12, 138);
            this.InstallFirefox.Name = "InstallFirefox";
            this.InstallFirefox.Size = new System.Drawing.Size(128, 23);
            this.InstallFirefox.TabIndex = 0;
            this.InstallFirefox.Text = "Install Firefox";
            this.InstallFirefox.UseVisualStyleBackColor = true;
            this.InstallFirefox.Click += new System.EventHandler(this.InstallFirefox_Click);
            // 
            // Chocolatey
            // 
            this.Chocolatey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chocolatey.Location = new System.Drawing.Point(12, 12);
            this.Chocolatey.Name = "Chocolatey";
            this.Chocolatey.Size = new System.Drawing.Size(900, 57);
            this.Chocolatey.TabIndex = 1;
            this.Chocolatey.Text = "Install Chocolatey Package Manager for Windows";
            this.Chocolatey.UseVisualStyleBackColor = true;
            this.Chocolatey.Click += new System.EventHandler(this.Chocolatey_Click);
            // 
            // UpdateFirefox
            // 
            this.UpdateFirefox.Location = new System.Drawing.Point(145, 138);
            this.UpdateFirefox.Name = "UpdateFirefox";
            this.UpdateFirefox.Size = new System.Drawing.Size(128, 23);
            this.UpdateFirefox.TabIndex = 2;
            this.UpdateFirefox.Text = "Update Firefox";
            this.UpdateFirefox.UseVisualStyleBackColor = true;
            this.UpdateFirefox.Click += new System.EventHandler(this.UpdateFirefox_Click);
            // 
            // FirefoxLabel
            // 
            this.FirefoxLabel.AutoSize = true;
            this.FirefoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirefoxLabel.Location = new System.Drawing.Point(111, 113);
            this.FirefoxLabel.Name = "FirefoxLabel";
            this.FirefoxLabel.Size = new System.Drawing.Size(65, 22);
            this.FirefoxLabel.TabIndex = 3;
            this.FirefoxLabel.Text = "Firefox";
            // 
            // UserCommandsLabel
            // 
            this.UserCommandsLabel.AutoSize = true;
            this.UserCommandsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserCommandsLabel.Location = new System.Drawing.Point(707, 87);
            this.UserCommandsLabel.Name = "UserCommandsLabel";
            this.UserCommandsLabel.Size = new System.Drawing.Size(143, 22);
            this.UserCommandsLabel.TabIndex = 4;
            this.UserCommandsLabel.Text = "User Commands";
            // 
            // DisableGuest
            // 
            this.DisableGuest.Location = new System.Drawing.Point(711, 112);
            this.DisableGuest.Name = "DisableGuest";
            this.DisableGuest.Size = new System.Drawing.Size(128, 23);
            this.DisableGuest.TabIndex = 5;
            this.DisableGuest.Text = "Disable Guest";
            this.DisableGuest.UseVisualStyleBackColor = true;
            this.DisableGuest.Click += new System.EventHandler(this.DisableGuest_Click);
            // 
            // UpdatePolicyLabel
            // 
            this.UpdatePolicyLabel.AutoSize = true;
            this.UpdatePolicyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePolicyLabel.Location = new System.Drawing.Point(390, 87);
            this.UpdatePolicyLabel.Name = "UpdatePolicyLabel";
            this.UpdatePolicyLabel.Size = new System.Drawing.Size(165, 22);
            this.UpdatePolicyLabel.TabIndex = 6;
            this.UpdatePolicyLabel.Text = "Updates and Policy";
            // 
            // EnableUpdates
            // 
            this.EnableUpdates.Location = new System.Drawing.Point(410, 112);
            this.EnableUpdates.Name = "EnableUpdates";
            this.EnableUpdates.Size = new System.Drawing.Size(128, 23);
            this.EnableUpdates.TabIndex = 7;
            this.EnableUpdates.Text = "Enable Auto Updating";
            this.EnableUpdates.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "This column requires Chocolatey";
            // 
            // InstallMalwarebytes
            // 
            this.InstallMalwarebytes.Location = new System.Drawing.Point(12, 209);
            this.InstallMalwarebytes.Name = "InstallMalwarebytes";
            this.InstallMalwarebytes.Size = new System.Drawing.Size(128, 23);
            this.InstallMalwarebytes.TabIndex = 9;
            this.InstallMalwarebytes.Text = "Install Malwarebytes";
            this.InstallMalwarebytes.UseVisualStyleBackColor = true;
            this.InstallMalwarebytes.Click += new System.EventHandler(this.InstallMalwarebytes_Click);
            // 
            // MalwarebytesLabel
            // 
            this.MalwarebytesLabel.AutoSize = true;
            this.MalwarebytesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MalwarebytesLabel.Location = new System.Drawing.Point(83, 184);
            this.MalwarebytesLabel.Name = "MalwarebytesLabel";
            this.MalwarebytesLabel.Size = new System.Drawing.Size(120, 22);
            this.MalwarebytesLabel.TabIndex = 10;
            this.MalwarebytesLabel.Text = "Malwarebytes";
            // 
            // ConfigureFirewall
            // 
            this.ConfigureFirewall.Location = new System.Drawing.Point(410, 163);
            this.ConfigureFirewall.Name = "ConfigureFirewall";
            this.ConfigureFirewall.Size = new System.Drawing.Size(128, 23);
            this.ConfigureFirewall.TabIndex = 11;
            this.ConfigureFirewall.Text = "Configure Firewall";
            this.ConfigureFirewall.UseVisualStyleBackColor = true;
            this.ConfigureFirewall.Click += new System.EventHandler(this.ConfigureFirewall_Click);
            // 
            // PasswordPolicy
            // 
            this.PasswordPolicy.Location = new System.Drawing.Point(711, 162);
            this.PasswordPolicy.Name = "PasswordPolicy";
            this.PasswordPolicy.Size = new System.Drawing.Size(128, 23);
            this.PasswordPolicy.TabIndex = 12;
            this.PasswordPolicy.Text = "Set Password Policy";
            this.PasswordPolicy.UseVisualStyleBackColor = true;
            this.PasswordPolicy.Click += new System.EventHandler(this.PasswordPolicy_Click);
            // 
            // PassReminder
            // 
            this.PassReminder.Location = new System.Drawing.Point(678, 191);
            this.PassReminder.Multiline = true;
            this.PassReminder.Name = "PassReminder";
            this.PassReminder.Size = new System.Drawing.Size(199, 63);
            this.PassReminder.TabIndex = 13;
            this.PassReminder.Text = "Remember to enable \"Password must meet complexity requirements\" under \"Account Po" +
    "licies\" -> \"Password Policy\" in secpol.msc.";
            // 
            // SpybotLabel
            // 
            this.SpybotLabel.AutoSize = true;
            this.SpybotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpybotLabel.Location = new System.Drawing.Point(21, 263);
            this.SpybotLabel.Name = "SpybotLabel";
            this.SpybotLabel.Size = new System.Drawing.Size(241, 22);
            this.SpybotLabel.TabIndex = 14;
            this.SpybotLabel.Text = "Spybot - Search and Destroy";
            // 
            // InstallSpybot
            // 
            this.InstallSpybot.Location = new System.Drawing.Point(12, 288);
            this.InstallSpybot.Name = "InstallSpybot";
            this.InstallSpybot.Size = new System.Drawing.Size(128, 23);
            this.InstallSpybot.TabIndex = 15;
            this.InstallSpybot.Text = "Install Spybot";
            this.InstallSpybot.UseVisualStyleBackColor = true;
            this.InstallSpybot.Click += new System.EventHandler(this.InstallSpybot_Click);
            // 
            // SetupAuditing
            // 
            this.SetupAuditing.Location = new System.Drawing.Point(410, 208);
            this.SetupAuditing.Name = "SetupAuditing";
            this.SetupAuditing.Size = new System.Drawing.Size(128, 23);
            this.SetupAuditing.TabIndex = 16;
            this.SetupAuditing.Text = "Setup Auditing";
            this.SetupAuditing.UseVisualStyleBackColor = true;
            this.SetupAuditing.Click += new System.EventHandler(this.SetupAuditing_Click);
            // 
            // AuditList
            // 
            this.AuditList.FormattingEnabled = true;
            this.AuditList.Items.AddRange(new object[] {
            "Account Logon",
            "Account Management",
            "Detailed Tracking",
            "DS Access",
            "Logon/Logoff",
            "Object Access",
            "Policy Change",
            "Privilege Use",
            "System"});
            this.AuditList.Location = new System.Drawing.Point(410, 288);
            this.AuditList.Name = "AuditList";
            this.AuditList.Size = new System.Drawing.Size(128, 139);
            this.AuditList.TabIndex = 17;
            // 
            // AuditReminder
            // 
            this.AuditReminder.Location = new System.Drawing.Point(374, 433);
            this.AuditReminder.Multiline = true;
            this.AuditReminder.Name = "AuditReminder";
            this.AuditReminder.Size = new System.Drawing.Size(199, 63);
            this.AuditReminder.TabIndex = 13;
            this.AuditReminder.Text = "Double check that this is working in: \"Local Policies\" -> \"Audit Policy\" in secpo" +
    "l.msc.";
            // 
            // Secure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 754);
            this.Controls.Add(this.AuditList);
            this.Controls.Add(this.SetupAuditing);
            this.Controls.Add(this.InstallSpybot);
            this.Controls.Add(this.SpybotLabel);
            this.Controls.Add(this.AuditReminder);
            this.Controls.Add(this.PassReminder);
            this.Controls.Add(this.PasswordPolicy);
            this.Controls.Add(this.ConfigureFirewall);
            this.Controls.Add(this.MalwarebytesLabel);
            this.Controls.Add(this.InstallMalwarebytes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnableUpdates);
            this.Controls.Add(this.UpdatePolicyLabel);
            this.Controls.Add(this.DisableGuest);
            this.Controls.Add(this.UserCommandsLabel);
            this.Controls.Add(this.FirefoxLabel);
            this.Controls.Add(this.UpdateFirefox);
            this.Controls.Add(this.Chocolatey);
            this.Controls.Add(this.InstallFirefox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Secure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CBHelper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InstallFirefox;
        private System.Windows.Forms.Button Chocolatey;
        private System.Windows.Forms.Button UpdateFirefox;
        private System.Windows.Forms.Label FirefoxLabel;
        private System.Windows.Forms.Label UserCommandsLabel;
        private System.Windows.Forms.Button DisableGuest;
        private System.Windows.Forms.Label UpdatePolicyLabel;
        private System.Windows.Forms.Button EnableUpdates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InstallMalwarebytes;
        private System.Windows.Forms.Label MalwarebytesLabel;
        private System.Windows.Forms.Button ConfigureFirewall;
        private System.Windows.Forms.Button PasswordPolicy;
        private System.Windows.Forms.TextBox PassReminder;
        private System.Windows.Forms.Label SpybotLabel;
        private System.Windows.Forms.Button InstallSpybot;
        private System.Windows.Forms.Button SetupAuditing;
        private System.Windows.Forms.CheckedListBox AuditList;
        private System.Windows.Forms.TextBox AuditReminder;
    }
}

