using System;
using System.IO;
using System.Windows.Forms;

namespace Basic_Project_Generator.UserInterfaces
{
    public partial class NewTiaPortalProject : Form
    {
        #region fields

        private FolderBrowserDialog _folderBrowserDialog;

        #endregion // fields

        #region ctor

        public NewTiaPortalProject()
        {
            InitializeComponent();

            btn_Create.DialogResult = DialogResult.OK;
            btn_Cancel.DialogResult = DialogResult.Cancel;
            txb_ProjectName.Text = string.Empty;
            ProjectName = string.Empty;
            txb_Path.Text = string.Empty;
            Path = string.Empty;
            ProjectNameValidationError = false;
            PathValidationError = false;
        }

        #endregion // ctor

        #region properties

        public string ProjectName
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public bool ProjectNameValidationError
        {
            get;
            set;
        }

        public bool PathValidationError
        {
            get;
            set;
        }

        public bool ExceptionOccurred
        {
            get;
            set;
        }

        #endregion // properties

        #region methods

        /// <summary>
        /// Reset the validation error for the project name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectName_TextChanged(object sender, EventArgs e)
        {
            ProjectNameValidationError = false;
        }

        /// <summary>
        /// Open folder browser dialog for retrieve the target path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Path_Click(object sender, EventArgs e)
        {
            try
            {
                _folderBrowserDialog = new FolderBrowserDialog();

                var result = _folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txb_Path.Text = _folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception exception)
            {
                ExceptionOccurred = true;
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reset the validation error for the path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Path_TextChanged(object sender, EventArgs e)
        {
            PathValidationError = false;
        }

        /// <summary>
        /// Validation the input
        /// </summary>
        private void ValidationProvider()
        {
            ExceptionOccurred = false;
            try
            {
                ProjectNameValidationError = false;
                ProjectName = txb_ProjectName.Text;
                if (string.IsNullOrEmpty(ProjectName))
                {
                    ProjectNameValidationError = true;
                }
            }
            catch (Exception exception)
            {
                ExceptionOccurred = true;
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                PathValidationError = false;
                Path = txb_Path.Text;
                if (string.IsNullOrEmpty(Path) || Directory.Exists(Path) == false)
                {
                    PathValidationError = true;
                }
            }
            catch (Exception exception)
            {
                ExceptionOccurred = true;
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validation the input and canceling close if an error occurred
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTiaPortalProject_Closing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                ValidationProvider();

                if (ProjectNameValidationError || PathValidationError)
                {
                    e.Cancel = true;
                    MessageBox.Show("Project name and valid path are both required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ExceptionOccurred)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion // methods
    }
}
