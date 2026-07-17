
namespace Basic_Project_Generator.UserInterfaces
{
    partial class PlcSecuritySettings
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
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grb_PlcProtectionConfiguration = new System.Windows.Forms.GroupBox();
            this.cbo_PlcProtectionConfiguration = new System.Windows.Forms.CheckBox();
            this.txb_ConfirmMasterSecretPassword = new System.Windows.Forms.TextBox();
            this.txb_MasterSecretPassword = new System.Windows.Forms.TextBox();
            this.lab_ConfirmPlcProtectinPassword = new System.Windows.Forms.Label();
            this.lab_NewPlcProtectionPassword = new System.Windows.Forms.Label();
            this.grb_PlzAccessProtection = new System.Windows.Forms.GroupBox();
            this.txb_ConfirmAccessLevelPassword = new System.Windows.Forms.TextBox();
            this.txb_AccessLevelPassword = new System.Windows.Forms.TextBox();
            this.lab_ConfirmAccessLevelPassword = new System.Windows.Forms.Label();
            this.lab_NewAccessLevelPassword = new System.Windows.Forms.Label();
            this.lab_AccessLevel = new System.Windows.Forms.Label();
            this.cob_AccessLevel = new System.Windows.Forms.ComboBox();
            this.grb_DisplayProtection = new System.Windows.Forms.GroupBox();
            this.cob_TimeUntilAutoLogoff = new System.Windows.Forms.ComboBox();
            this.lab_TimeUntilAutoLogoff = new System.Windows.Forms.Label();
            this.txb_ConfirmDisplayProtectionPassword = new System.Windows.Forms.TextBox();
            this.txb_DisplayProtectionPassword = new System.Windows.Forms.TextBox();
            this.lab_ConfirmDisplayProtectinPassword = new System.Windows.Forms.Label();
            this.lab_NewDisplayProtectionPassword = new System.Windows.Forms.Label();
            this.cbo_DisplayProtection = new System.Windows.Forms.CheckBox();
            this.grb_PlcProtectionConfiguration.SuspendLayout();
            this.grb_PlzAccessProtection.SuspendLayout();
            this.grb_DisplayProtection.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(139, 394);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(99, 23);
            this.btn_Create.TabIndex = 3;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(244, 394);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(99, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // grb_PlcProtectionConfiguration
            // 
            this.grb_PlcProtectionConfiguration.Controls.Add(this.cbo_PlcProtectionConfiguration);
            this.grb_PlcProtectionConfiguration.Controls.Add(this.txb_ConfirmMasterSecretPassword);
            this.grb_PlcProtectionConfiguration.Controls.Add(this.txb_MasterSecretPassword);
            this.grb_PlcProtectionConfiguration.Controls.Add(this.lab_ConfirmPlcProtectinPassword);
            this.grb_PlcProtectionConfiguration.Controls.Add(this.lab_NewPlcProtectionPassword);
            this.grb_PlcProtectionConfiguration.Location = new System.Drawing.Point(12, 12);
            this.grb_PlcProtectionConfiguration.Name = "grb_PlcProtectionConfiguration";
            this.grb_PlcProtectionConfiguration.Size = new System.Drawing.Size(331, 113);
            this.grb_PlcProtectionConfiguration.TabIndex = 0;
            this.grb_PlcProtectionConfiguration.TabStop = false;
            this.grb_PlcProtectionConfiguration.Text = "Protection of confidential PLC data";
            // 
            // cbo_PlcProtectionConfiguration
            // 
            this.cbo_PlcProtectionConfiguration.AutoSize = true;
            this.cbo_PlcProtectionConfiguration.Location = new System.Drawing.Point(128, 25);
            this.cbo_PlcProtectionConfiguration.Name = "cbo_PlcProtectionConfiguration";
            this.cbo_PlcProtectionConfiguration.Size = new System.Drawing.Size(189, 17);
            this.cbo_PlcProtectionConfiguration.TabIndex = 0;
            this.cbo_PlcProtectionConfiguration.Text = "Protect the PLC configuration data";
            this.cbo_PlcProtectionConfiguration.UseVisualStyleBackColor = true;
            this.cbo_PlcProtectionConfiguration.CheckedChanged += new System.EventHandler(this.cbo_PlcProtectionConfiguration_CheckedChanged);
            // 
            // txb_ConfirmMasterSecretPassword
            // 
            this.txb_ConfirmMasterSecretPassword.Location = new System.Drawing.Point(128, 74);
            this.txb_ConfirmMasterSecretPassword.Name = "txb_ConfirmMasterSecretPassword";
            this.txb_ConfirmMasterSecretPassword.PasswordChar = '*';
            this.txb_ConfirmMasterSecretPassword.Size = new System.Drawing.Size(191, 20);
            this.txb_ConfirmMasterSecretPassword.TabIndex = 4;
            this.txb_ConfirmMasterSecretPassword.Leave += new System.EventHandler(this.txb_ConfirmPlcProtectionPassword_Leave);
            // 
            // txb_MasterSecretPassword
            // 
            this.txb_MasterSecretPassword.Location = new System.Drawing.Point(128, 48);
            this.txb_MasterSecretPassword.Name = "txb_MasterSecretPassword";
            this.txb_MasterSecretPassword.PasswordChar = '*';
            this.txb_MasterSecretPassword.Size = new System.Drawing.Size(191, 20);
            this.txb_MasterSecretPassword.TabIndex = 2;
            this.txb_MasterSecretPassword.Leave += new System.EventHandler(this.txb_MasterSecretPassword_Leave);
            // 
            // lab_ConfirmPlcProtectinPassword
            // 
            this.lab_ConfirmPlcProtectinPassword.AutoSize = true;
            this.lab_ConfirmPlcProtectinPassword.Location = new System.Drawing.Point(32, 77);
            this.lab_ConfirmPlcProtectinPassword.Name = "lab_ConfirmPlcProtectinPassword";
            this.lab_ConfirmPlcProtectinPassword.Size = new System.Drawing.Size(90, 13);
            this.lab_ConfirmPlcProtectinPassword.TabIndex = 3;
            this.lab_ConfirmPlcProtectinPassword.Text = "Confirm password";
            // 
            // lab_NewPlcProtectionPassword
            // 
            this.lab_NewPlcProtectionPassword.AutoSize = true;
            this.lab_NewPlcProtectionPassword.Location = new System.Drawing.Point(45, 51);
            this.lab_NewPlcProtectionPassword.Name = "lab_NewPlcProtectionPassword";
            this.lab_NewPlcProtectionPassword.Size = new System.Drawing.Size(77, 13);
            this.lab_NewPlcProtectionPassword.TabIndex = 1;
            this.lab_NewPlcProtectionPassword.Text = "New password";
            // 
            // grb_PlzAccessProtection
            // 
            this.grb_PlzAccessProtection.Controls.Add(this.txb_ConfirmAccessLevelPassword);
            this.grb_PlzAccessProtection.Controls.Add(this.txb_AccessLevelPassword);
            this.grb_PlzAccessProtection.Controls.Add(this.lab_ConfirmAccessLevelPassword);
            this.grb_PlzAccessProtection.Controls.Add(this.lab_NewAccessLevelPassword);
            this.grb_PlzAccessProtection.Controls.Add(this.lab_AccessLevel);
            this.grb_PlzAccessProtection.Controls.Add(this.cob_AccessLevel);
            this.grb_PlzAccessProtection.Location = new System.Drawing.Point(12, 131);
            this.grb_PlzAccessProtection.Name = "grb_PlzAccessProtection";
            this.grb_PlzAccessProtection.Size = new System.Drawing.Size(331, 119);
            this.grb_PlzAccessProtection.TabIndex = 1;
            this.grb_PlzAccessProtection.TabStop = false;
            this.grb_PlzAccessProtection.Text = "PLC access protection";
            // 
            // txb_ConfirmAccessLevelPassword
            // 
            this.txb_ConfirmAccessLevelPassword.Location = new System.Drawing.Point(128, 79);
            this.txb_ConfirmAccessLevelPassword.Name = "txb_ConfirmAccessLevelPassword";
            this.txb_ConfirmAccessLevelPassword.PasswordChar = '*';
            this.txb_ConfirmAccessLevelPassword.Size = new System.Drawing.Size(191, 20);
            this.txb_ConfirmAccessLevelPassword.TabIndex = 5;
            this.txb_ConfirmAccessLevelPassword.Leave += new System.EventHandler(this.txb_ConfirmAccessLevelPassword_Leave);
            // 
            // txb_AccessLevelPassword
            // 
            this.txb_AccessLevelPassword.Location = new System.Drawing.Point(128, 53);
            this.txb_AccessLevelPassword.Name = "txb_AccessLevelPassword";
            this.txb_AccessLevelPassword.PasswordChar = '*';
            this.txb_AccessLevelPassword.Size = new System.Drawing.Size(191, 20);
            this.txb_AccessLevelPassword.TabIndex = 3;
            this.txb_AccessLevelPassword.Leave += new System.EventHandler(this.txb_AccessLevelPassword_Leave);
            // 
            // lab_ConfirmAccessLevelPassword
            // 
            this.lab_ConfirmAccessLevelPassword.AutoSize = true;
            this.lab_ConfirmAccessLevelPassword.Location = new System.Drawing.Point(32, 82);
            this.lab_ConfirmAccessLevelPassword.Name = "lab_ConfirmAccessLevelPassword";
            this.lab_ConfirmAccessLevelPassword.Size = new System.Drawing.Size(90, 13);
            this.lab_ConfirmAccessLevelPassword.TabIndex = 4;
            this.lab_ConfirmAccessLevelPassword.Text = "Confirm password";
            // 
            // lab_NewAccessLevelPassword
            // 
            this.lab_NewAccessLevelPassword.AutoSize = true;
            this.lab_NewAccessLevelPassword.Location = new System.Drawing.Point(45, 56);
            this.lab_NewAccessLevelPassword.Name = "lab_NewAccessLevelPassword";
            this.lab_NewAccessLevelPassword.Size = new System.Drawing.Size(77, 13);
            this.lab_NewAccessLevelPassword.TabIndex = 2;
            this.lab_NewAccessLevelPassword.Text = "New password";
            // 
            // lab_AccessLevel
            // 
            this.lab_AccessLevel.AutoSize = true;
            this.lab_AccessLevel.Location = new System.Drawing.Point(55, 29);
            this.lab_AccessLevel.Name = "lab_AccessLevel";
            this.lab_AccessLevel.Size = new System.Drawing.Size(67, 13);
            this.lab_AccessLevel.TabIndex = 0;
            this.lab_AccessLevel.Text = "Access level";
            // 
            // cob_AccessLevel
            // 
            this.cob_AccessLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_AccessLevel.FormattingEnabled = true;
            this.cob_AccessLevel.Location = new System.Drawing.Point(128, 26);
            this.cob_AccessLevel.Name = "cob_AccessLevel";
            this.cob_AccessLevel.Size = new System.Drawing.Size(191, 21);
            this.cob_AccessLevel.TabIndex = 1;
            this.cob_AccessLevel.SelectedIndexChanged += new System.EventHandler(this.cob_AccessLevel_SelectedIndexChanged);
            // 
            // grb_DisplayProtection
            // 
            this.grb_DisplayProtection.Controls.Add(this.cob_TimeUntilAutoLogoff);
            this.grb_DisplayProtection.Controls.Add(this.lab_TimeUntilAutoLogoff);
            this.grb_DisplayProtection.Controls.Add(this.txb_ConfirmDisplayProtectionPassword);
            this.grb_DisplayProtection.Controls.Add(this.txb_DisplayProtectionPassword);
            this.grb_DisplayProtection.Controls.Add(this.lab_ConfirmDisplayProtectinPassword);
            this.grb_DisplayProtection.Controls.Add(this.lab_NewDisplayProtectionPassword);
            this.grb_DisplayProtection.Controls.Add(this.cbo_DisplayProtection);
            this.grb_DisplayProtection.Location = new System.Drawing.Point(12, 256);
            this.grb_DisplayProtection.Name = "grb_DisplayProtection";
            this.grb_DisplayProtection.Size = new System.Drawing.Size(331, 132);
            this.grb_DisplayProtection.TabIndex = 2;
            this.grb_DisplayProtection.TabStop = false;
            this.grb_DisplayProtection.Text = "CPU display protection";
            // 
            // cob_TimeUntilAutoLogoff
            // 
            this.cob_TimeUntilAutoLogoff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_TimeUntilAutoLogoff.FormattingEnabled = true;
            this.cob_TimeUntilAutoLogoff.Location = new System.Drawing.Point(128, 100);
            this.cob_TimeUntilAutoLogoff.Name = "cob_TimeUntilAutoLogoff";
            this.cob_TimeUntilAutoLogoff.Size = new System.Drawing.Size(191, 21);
            this.cob_TimeUntilAutoLogoff.TabIndex = 6;
            this.cob_TimeUntilAutoLogoff.SelectedIndexChanged += new System.EventHandler(this.cob_TimeUntilAutoLogoff_SelectedIndexChanged);
            // 
            // lab_TimeUntilAutoLogoff
            // 
            this.lab_TimeUntilAutoLogoff.AutoSize = true;
            this.lab_TimeUntilAutoLogoff.Location = new System.Drawing.Point(17, 103);
            this.lab_TimeUntilAutoLogoff.Name = "lab_TimeUntilAutoLogoff";
            this.lab_TimeUntilAutoLogoff.Size = new System.Drawing.Size(105, 13);
            this.lab_TimeUntilAutoLogoff.TabIndex = 5;
            this.lab_TimeUntilAutoLogoff.Text = "Time until auto logoff";
            // 
            // txb_ConfirmDisplayProtectionPassword
            // 
            this.txb_ConfirmDisplayProtectionPassword.Location = new System.Drawing.Point(128, 74);
            this.txb_ConfirmDisplayProtectionPassword.Name = "txb_ConfirmDisplayProtectionPassword";
            this.txb_ConfirmDisplayProtectionPassword.PasswordChar = '*';
            this.txb_ConfirmDisplayProtectionPassword.Size = new System.Drawing.Size(191, 20);
            this.txb_ConfirmDisplayProtectionPassword.TabIndex = 4;
            this.txb_ConfirmDisplayProtectionPassword.Leave += new System.EventHandler(this.txb_ConfirmDisplayProtectionPassword_Leave);
            // 
            // txb_DisplayProtectionPassword
            // 
            this.txb_DisplayProtectionPassword.Location = new System.Drawing.Point(128, 48);
            this.txb_DisplayProtectionPassword.Name = "txb_DisplayProtectionPassword";
            this.txb_DisplayProtectionPassword.PasswordChar = '*';
            this.txb_DisplayProtectionPassword.Size = new System.Drawing.Size(191, 20);
            this.txb_DisplayProtectionPassword.TabIndex = 2;
            this.txb_DisplayProtectionPassword.Leave += new System.EventHandler(this.txb_DisplayProtectionPassword_Leave);
            // 
            // lab_ConfirmDisplayProtectinPassword
            // 
            this.lab_ConfirmDisplayProtectinPassword.AutoSize = true;
            this.lab_ConfirmDisplayProtectinPassword.Location = new System.Drawing.Point(32, 77);
            this.lab_ConfirmDisplayProtectinPassword.Name = "lab_ConfirmDisplayProtectinPassword";
            this.lab_ConfirmDisplayProtectinPassword.Size = new System.Drawing.Size(90, 13);
            this.lab_ConfirmDisplayProtectinPassword.TabIndex = 3;
            this.lab_ConfirmDisplayProtectinPassword.Text = "Confirm password";
            // 
            // lab_NewDisplayProtectionPassword
            // 
            this.lab_NewDisplayProtectionPassword.AutoSize = true;
            this.lab_NewDisplayProtectionPassword.Location = new System.Drawing.Point(45, 51);
            this.lab_NewDisplayProtectionPassword.Name = "lab_NewDisplayProtectionPassword";
            this.lab_NewDisplayProtectionPassword.Size = new System.Drawing.Size(77, 13);
            this.lab_NewDisplayProtectionPassword.TabIndex = 1;
            this.lab_NewDisplayProtectionPassword.Text = "New password";
            // 
            // cbo_DisplayProtection
            // 
            this.cbo_DisplayProtection.AutoSize = true;
            this.cbo_DisplayProtection.Location = new System.Drawing.Point(128, 25);
            this.cbo_DisplayProtection.Name = "cbo_DisplayProtection";
            this.cbo_DisplayProtection.Size = new System.Drawing.Size(144, 17);
            this.cbo_DisplayProtection.TabIndex = 0;
            this.cbo_DisplayProtection.Text = "Enable display protection";
            this.cbo_DisplayProtection.UseVisualStyleBackColor = true;
            this.cbo_DisplayProtection.CheckedChanged += new System.EventHandler(this.cbo_DisplayProtection_CheckedChanged);
            // 
            // PlcSecuritySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 427);
            this.ControlBox = false;
            this.Controls.Add(this.grb_DisplayProtection);
            this.Controls.Add(this.grb_PlzAccessProtection);
            this.Controls.Add(this.grb_PlcProtectionConfiguration);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlcSecuritySettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PLC security settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlcSecuritySettings_FormClosing);
            this.Load += new System.EventHandler(this.PlcSecuritySettings_Load);
            this.grb_PlcProtectionConfiguration.ResumeLayout(false);
            this.grb_PlcProtectionConfiguration.PerformLayout();
            this.grb_PlzAccessProtection.ResumeLayout(false);
            this.grb_PlzAccessProtection.PerformLayout();
            this.grb_DisplayProtection.ResumeLayout(false);
            this.grb_DisplayProtection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox grb_PlcProtectionConfiguration;
        private System.Windows.Forms.Label lab_ConfirmPlcProtectinPassword;
        private System.Windows.Forms.Label lab_NewPlcProtectionPassword;
        private System.Windows.Forms.GroupBox grb_PlzAccessProtection;
        private System.Windows.Forms.CheckBox cbo_PlcProtectionConfiguration;
        private System.Windows.Forms.TextBox txb_ConfirmMasterSecretPassword;
        private System.Windows.Forms.TextBox txb_MasterSecretPassword;
        private System.Windows.Forms.TextBox txb_ConfirmAccessLevelPassword;
        private System.Windows.Forms.TextBox txb_AccessLevelPassword;
        private System.Windows.Forms.Label lab_ConfirmAccessLevelPassword;
        private System.Windows.Forms.Label lab_NewAccessLevelPassword;
        private System.Windows.Forms.Label lab_AccessLevel;
        private System.Windows.Forms.ComboBox cob_AccessLevel;
        private System.Windows.Forms.GroupBox grb_DisplayProtection;
        private System.Windows.Forms.ComboBox cob_TimeUntilAutoLogoff;
        private System.Windows.Forms.Label lab_TimeUntilAutoLogoff;
        private System.Windows.Forms.TextBox txb_ConfirmDisplayProtectionPassword;
        private System.Windows.Forms.TextBox txb_DisplayProtectionPassword;
        private System.Windows.Forms.Label lab_ConfirmDisplayProtectinPassword;
        private System.Windows.Forms.Label lab_NewDisplayProtectionPassword;
        private System.Windows.Forms.CheckBox cbo_DisplayProtection;
    }
}