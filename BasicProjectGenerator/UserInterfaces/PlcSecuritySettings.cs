using Basic_Project_Generator.Models;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Basic_Project_Generator.UserInterfaces
{
    public partial class PlcSecuritySettings : Form
    {
        #region fields

        private SecureString _confirmMasterSecretPassword;
        private SecureString _confirmAccessLevelPassword;
        private SecureString _confirmDisplayProtectionPassword;
        private PlcAccessLevel _plcAccessLevel;
        private DisplayAutoLogoff _displayAutoLogoff;

        #endregion // fields

        #region ctor

        public PlcSecuritySettings()
        {
            InitializeComponent();

            btn_Create.DialogResult = DialogResult.OK;
            btn_Cancel.DialogResult = DialogResult.Cancel;
        }

        #endregion // ctor

        #region properties

        public string AccessLevel
        {
            get;
            set;
        }

        public SecureString MasterSecretPassword
        {
            get;
            set;
        }

        public SecureString AccessLevelPassword
        {
            get;
            set;
        }

        public SecureString DisplayProtectionPassword
        {
            get;
            set;
        }

        public bool IncludeFailsafe
        {
            get;
            set;
        }

        public bool ProtectPlcConfiguration
        {
            get;
            set;
        }

        public bool ProtectPlcConfigurationError
        {
            get;
            set;
        }

        public bool AccessLevelError
        {
            get;
            set;
        }

        public static bool ExceptionOccurred
        {
            get;
            set;
        }

        public bool DisplayProtection
        {
            get;
            set;
        }

        public bool DisplayProtectionError
        {
            get;
            set;
        }

        public string TimeUntilDisplayAutoLogoff
        {
            get;
            set;
        }

        #endregion // properties

        #region methods

        /// <summary>
        /// Initialization of controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlcSecuritySettings_Load(object sender, EventArgs e)
        {
            cbo_PlcProtectionConfiguration.Checked = true;

            _plcAccessLevel = new PlcAccessLevel(IncludeFailsafe);
            cob_AccessLevel.ValueMember = _plcAccessLevel.GetNamePropertyName();
            cob_AccessLevel.Text = _plcAccessLevel.GetTagPropertyName();

            foreach (var accessLevel in _plcAccessLevel.AccessLevels)
            {
                cob_AccessLevel.Items.Add(accessLevel);
            }

            cob_AccessLevel.SelectedIndex = 0;

            _displayAutoLogoff = new DisplayAutoLogoff();
            cob_TimeUntilAutoLogoff.ValueMember = _displayAutoLogoff.GetNamePropertyName();
            cob_TimeUntilAutoLogoff.Text = _displayAutoLogoff.GetTagPropertyName();

            cbo_DisplayProtection.Checked = true;

            foreach (var autoLogoff in _displayAutoLogoff.AutoLogoffs)
            {
                cob_TimeUntilAutoLogoff.Items.Add(autoLogoff);
            }

            cob_TimeUntilAutoLogoff.SelectedIndex = 5;
        }

        /// <summary>
        /// Activate or deactivate the PLC Protection controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_PlcProtectionConfiguration_CheckedChanged(object sender, EventArgs e)
        {
            ProtectPlcConfiguration = cbo_PlcProtectionConfiguration.Checked;

            txb_MasterSecretPassword.Enabled = cbo_PlcProtectionConfiguration.Checked;
            txb_ConfirmMasterSecretPassword.Enabled = cbo_PlcProtectionConfiguration.Checked;
        }

        /// <summary>
        /// Check input when leave the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MasterSecretPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_MasterSecretPassword.Text))
            {
                if (!CheckPasswordRule(txb_MasterSecretPassword.Text, false))
                {
                    ProtectPlcConfigurationError = true;
                }
            }
        }

        /// <summary>
        /// Check input when leave the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_ConfirmPlcProtectionPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ConfirmMasterSecretPassword.Text))
            {
                if (!CheckPasswordRule(txb_ConfirmMasterSecretPassword.Text, false))
                {
                    ProtectPlcConfigurationError = true;
                }
                else
                {
                    MasterSecretPassword = GetSecureString(txb_MasterSecretPassword.Text);
                    _confirmMasterSecretPassword = GetSecureString(txb_ConfirmMasterSecretPassword.Text);

                    ProtectPlcConfigurationError = SecureStringEqual("PLC Protection password", MasterSecretPassword, _confirmMasterSecretPassword);
                }
            }
        }

        /// <summary>
        /// Activate or deactivate the access level protection controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cob_AccessLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccessLevel = ((AccessLevel)cob_AccessLevel.SelectedItem).Tag;

            if (cob_AccessLevel.Items.Count == 4 && cob_AccessLevel.SelectedIndex == 0 ||
                cob_AccessLevel.Items.Count == 5 && (cob_AccessLevel.SelectedIndex == 0 || cob_AccessLevel.SelectedIndex == 1))
            {
                txb_AccessLevelPassword.Enabled = false;
                txb_ConfirmAccessLevelPassword.Enabled = false;
            }
            else
            {
                txb_AccessLevelPassword.Enabled = true;
                txb_ConfirmAccessLevelPassword.Enabled = true;
            }
        }

        /// <summary>
        /// Check input when leave the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_AccessLevelPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_AccessLevelPassword.Text))
            {
                if (!CheckPasswordRule(txb_AccessLevelPassword.Text, false))
                {
                    AccessLevelError = true;
                }
            }
        }

        /// <summary>
        /// Check input when leave the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_ConfirmAccessLevelPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ConfirmAccessLevelPassword.Text))
            {
                if (!CheckPasswordRule(txb_ConfirmAccessLevelPassword.Text, false))
                {
                    AccessLevelError = true;
                }
                else
                {
                    AccessLevelPassword = GetSecureString(txb_AccessLevelPassword.Text);
                    _confirmAccessLevelPassword = GetSecureString(txb_ConfirmAccessLevelPassword.Text);

                    AccessLevelError = SecureStringEqual("Access Level password", AccessLevelPassword, _confirmAccessLevelPassword);
                }
            }
        }

        /// <summary>
        /// Activate or deactivate the display protection and the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_DisplayProtection_CheckedChanged(object sender, EventArgs e)
        {
            DisplayProtection = cbo_DisplayProtection.Checked;

            txb_DisplayProtectionPassword.Enabled = cbo_DisplayProtection.Checked;
            txb_ConfirmDisplayProtectionPassword.Enabled = cbo_DisplayProtection.Checked;
            cob_TimeUntilAutoLogoff.Enabled = cbo_DisplayProtection.Checked;
        }

        /// <summary>
        /// Check input when leave the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_DisplayProtectionPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_DisplayProtectionPassword.Text))
            {
                if (!CheckPasswordRule(txb_DisplayProtectionPassword.Text.ToUpper(), true))
                {
                    DisplayProtectionError = true;
                }
            }
        }

        /// <summary>
        /// Check input when leave the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_ConfirmDisplayProtectionPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ConfirmDisplayProtectionPassword.Text))
            {
                if (!CheckPasswordRule(txb_ConfirmDisplayProtectionPassword.Text.ToUpper(), true))
                {
                    ProtectPlcConfigurationError = true;
                }
                else
                {
                    DisplayProtectionPassword = GetSecureString(txb_DisplayProtectionPassword.Text.ToUpper());
                    _confirmDisplayProtectionPassword = GetSecureString(txb_ConfirmDisplayProtectionPassword.Text.ToUpper());

                    DisplayProtectionError = SecureStringEqual("Display Protection password", DisplayProtectionPassword, _confirmDisplayProtectionPassword);
                }
            }
        }

        /// <summary>
        /// Set the selected time for display auto logoff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cob_TimeUntilAutoLogoff_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeUntilDisplayAutoLogoff = ((AutoLogoff)cob_TimeUntilAutoLogoff.SelectedItem).Tag;
        }

        /// <summary>
        /// Validation the input
        /// </summary>
        private void ValidationProvider()
        {
            ExceptionOccurred = false;
            ProtectPlcConfigurationError = false;
            AccessLevelError = false;

            if (cbo_PlcProtectionConfiguration.Checked)
            {
                ProtectPlcConfigurationError = SecureStringEqual("PLC Protection password", MasterSecretPassword, _confirmMasterSecretPassword);
            }

            if (cob_AccessLevel.Items.Count == 4 && cob_AccessLevel.SelectedIndex > 0)
            {
                AccessLevelError = SecureStringEqual("Access Level password", AccessLevelPassword, _confirmAccessLevelPassword);
            }

            if (cob_AccessLevel.Items.Count == 5 && cob_AccessLevel.SelectedIndex > 1)
            {
                AccessLevelError = SecureStringEqual("Access Level password", AccessLevelPassword, _confirmAccessLevelPassword);
            }
        }

        /// <summary>
        /// Validation the input and canceling close if an error occurred
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlcSecuritySettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                ValidationProvider();

                if (ProtectPlcConfigurationError || AccessLevelError || ExceptionOccurred)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Check the password string
        /// </summary>
        /// <param name="password"></param>
        /// <param name="cpuDisplay"></param>
        /// <returns></returns>
        private static bool CheckPasswordRule(string password, bool cpuDisplay)
        {
            Match match;

            var plcRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{9,}$");
            var cpuRegex = new Regex("^(?=.*[A-Z])(?=.*\\d)[A-Z\\d]{3,8}$");

            if (cpuDisplay)
            {
                match = cpuRegex.Match(password);
            }
            else
            {
                match = plcRegex.Match(password);
            }


            if (!match.Success)
            {
                if (cpuDisplay)
                {
                    MessageBox.Show("The password must contain 3-8 characters. Only upper case letters and numbers are allowed. Lower case letters will be entered automatically as upper case letters.!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The password must be at least 9 characters long and contain a capital letter, a number and a special character (@$!%*?&)!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


            return match.Success;
        }

        /// <summary>
        /// Create a secure string from input
        /// </summary>
        /// <param name="plainString"></param>
        /// <returns></returns>
        private static SecureString GetSecureString(string plainString)
        {
            SecureString secureString = null;

            try
            {
                if (plainString != null)
                {
                    secureString = new SecureString();

                    foreach (var c in plainString)
                    {
                        secureString.AppendChar(c);
                    }

                    secureString.MakeReadOnly();
                }
            }
            catch (Exception exception)
            {
                ExceptionOccurred = true;
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return secureString;
        }

        /// <summary>
        /// Compare the password and the confirmation
        /// </summary>
        /// <param name="passwordName"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        private static bool SecureStringEqual(string passwordName, SecureString password, SecureString confirmPassword)
        {
            var errorOccurred = false;

            if (password == null || confirmPassword == null)
            {
                MessageBox.Show("The " + passwordName + " and confirm password must not be null!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (password.Length != confirmPassword.Length)
            {
                MessageBox.Show("The " + passwordName + " and confirm password do not match!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            var secureStringPasswordPtr = IntPtr.Zero;
            var secureStringConfirmPasswordPtr = IntPtr.Zero;

            try
            {
                secureStringPasswordPtr = Marshal.SecureStringToBSTR(password);
                secureStringConfirmPasswordPtr = Marshal.SecureStringToBSTR(confirmPassword);

                var stringPassword = Marshal.PtrToStringBSTR(secureStringPasswordPtr);
                var stringConfirmPassword = Marshal.PtrToStringBSTR(secureStringConfirmPasswordPtr);

                if (!stringPassword.Equals(stringConfirmPassword))
                {
                    errorOccurred = true;
                    MessageBox.Show("The " + passwordName + " and confirm password do not match!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                ExceptionOccurred = true;
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (secureStringPasswordPtr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(secureStringPasswordPtr);
                }

                if (secureStringConfirmPasswordPtr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(secureStringConfirmPasswordPtr);
                }
            }

            return errorOccurred;
        }

        #endregion // methods
    }
}
