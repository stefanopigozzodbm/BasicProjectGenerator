using Basic_Project_Generator.Interfaces;
using Basic_Project_Generator.Models;
using Basic_Project_Generator.Services;
using Siemens.Engineering;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Basic_Project_Generator.UserInterfaces
{
    /// <summary>
    /// The main application form
    /// </summary>
    public partial class BasicProjectGenerator : Form
    {
        #region fields

        private readonly ApiWrapper _apiWrapper;
        private readonly ProjectGeneratorService _projectGeneratorService;
        private readonly TraceWriter _traceWriter;

        #endregion // fields

        #region ctor

        public BasicProjectGenerator([CallerMemberName] string caller = "")
        {
            InitializeComponent();

            _traceWriter = new TraceWriter(lib_TraceWriterOutput);
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name + " called from " + caller + "\n");

            _apiWrapper = new ApiWrapper(_traceWriter);

            _projectGeneratorService = new ProjectGeneratorService(_traceWriter, _apiWrapper);

            ManageUiState();
        }

        #endregion // ctor

        #region methods

        #region BasicProjectGenerator

        /// <summary>
        /// Initialization of controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicProjectGenerator_Load(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            AddRadioCheckedBinding(rdb_WithoutUI, _apiWrapper, nameof(_apiWrapper.TiaPortalMode), TiaPortalMode.WithoutUserInterface);
            AddRadioCheckedBinding(rdb_WithUI, _apiWrapper, nameof(_apiWrapper.TiaPortalMode), TiaPortalMode.WithUserInterface);

            _apiWrapper.TiaPortalMode = TiaPortalMode.WithUserInterface;

            cob_DeviceList.ValueMember = _projectGeneratorService.DeviceModel.GetDeviceNamePropertyName();
            cob_DeviceList.Text = _projectGeneratorService.DeviceModel.GetNamePropertyName();

            GeneratorToolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = false
            };
        }

        /// <summary>
        /// Add a property binding to radio button
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="radio"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataMember"></param>
        /// <param name="trueValue"></param>
        private void AddRadioCheckedBinding<T>(RadioButton radio, object dataSource, string dataMember, T trueValue)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            var binding = new Binding(nameof(RadioButton.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) =>
            {
                if ((bool)a.Value) a.Value = trueValue;
            };
            binding.Format += (s, a) =>
            {
                a.Value = ((T)a.Value).Equals(trueValue);
            };
            radio.DataBindings.Add(binding);
        }

        /// <summary>
        /// Retrieve the selected index and item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cob_ProcessIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            _projectGeneratorService.SelectedProcessIndex = cob_ProcessIds.SelectedIndex;
            _projectGeneratorService.SelectedProcessItem = cob_ProcessIds.SelectedItem.ToString();

            UpdateProcessUiState();
        }

        /// <summary>
        /// Manage the UI state
        /// </summary>
        private void ManageUiState()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            UpdateProcessList();
            UpdateProcessUiState();
            UpdateProjectUiState();
            UpdateDeviceUiState();
            UpdateCompileUiState();
        }

        /// <summary>
        /// Manage process list changes
        /// </summary>
        private void UpdateProcessList()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            cob_ProcessIds.Items.Clear();
            cob_ProcessIds.ResetText();

            var processIds = _projectGeneratorService.GetTiaPortalProcesses();
            if (processIds != null && processIds.Count > 0)
            {
                foreach (var item in processIds)
                {
                    cob_ProcessIds.Items.Add(item);
                }

                var index = cob_ProcessIds.FindString($"ID {_projectGeneratorService.GetCurrentTiaProcessId()}");
                cob_ProcessIds.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Manage controls for the TIA Portal process region
        /// </summary>
        private void UpdateProcessUiState()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            var currentProcessId = _projectGeneratorService.GetCurrentTiaProcessId();
            txb_CurrentProcessId.Text = currentProcessId;
            var availableProcessId = _projectGeneratorService.GetSelectedProcessIdAsString();

            rdb_WithUI.Enabled = string.IsNullOrEmpty(currentProcessId);
            rdb_WithoutUI.Enabled = string.IsNullOrEmpty(currentProcessId);
            btn_OpenTiaPortal.Enabled = string.IsNullOrEmpty(currentProcessId);
            txb_CurrentProcessId.Enabled = !string.IsNullOrEmpty(currentProcessId);
            cob_ProcessIds.Enabled = cob_ProcessIds.Items.Count > 0;
            btn_ConnectTiaPortal.Enabled = cob_ProcessIds.Items.Count > 0 && (cob_ProcessIds.SelectedIndex > -1 && string.IsNullOrEmpty(currentProcessId) || currentProcessId != availableProcessId);
            btn_CloseTiaPortal.Enabled = !string.IsNullOrEmpty(currentProcessId);
        }

        /// <summary>
        /// Manage controls for the project region
        /// </summary>
        private void UpdateProjectUiState()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            txb_CurrentProjectName.Text = _projectGeneratorService.GetCurrentProjectName();
            txb_TargetDirectory.Text = _projectGeneratorService.GetTargetDirectory();
            txb_AvailableProjectName.Text = _projectGeneratorService.GetAvailableProject();

            var currentProcessId = _projectGeneratorService.GetCurrentTiaProcessId();
            btn_CreateNewProject.Enabled = !string.IsNullOrEmpty(currentProcessId);
            btn_OpenProject.Enabled = !string.IsNullOrEmpty(currentProcessId);
            txb_CurrentProjectName.Enabled = !string.IsNullOrEmpty(currentProcessId);
            txb_TargetDirectory.Enabled = !string.IsNullOrEmpty(currentProcessId);
            txb_AvailableProjectName.Enabled = !string.IsNullOrEmpty(currentProcessId);
            btn_LoadProject.Enabled = string.IsNullOrEmpty(txb_CurrentProjectName.Text) && !string.IsNullOrEmpty(txb_AvailableProjectName.Text);
            btn_SaveProject.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text) && _apiWrapper.CurrentProject.IsModified;
            btn_CloseProject.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);

            if (!string.IsNullOrEmpty(txb_CurrentProjectName.Text))
            {
                GetCurrentDeviceCount();
                LoadDeviceCatalog();
            }
        }

        /// <summary>
        /// Manage controls for the device region
        /// </summary>
        private void UpdateDeviceUiState()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            cob_DeviceTemplates.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
            ckb_IncludeFailsafe.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
            txb_DeviceName.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
            txb_Station.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
            txb_TypeIdentifier.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
            txb_OrderNr.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
            txb_Version.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
            btn_AddNewDevice.Enabled = !string.IsNullOrEmpty(txb_CurrentProjectName.Text);
        }

        /// <summary>
        /// Manage controls for the compile region
        /// </summary>
        private void UpdateCompileUiState()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            cob_DeviceList.Enabled = cob_DeviceList.Items.Count > 0;
            lib_DeviceList.Enabled = cob_DeviceList.Items.Count > 0;
            btn_CompileDevice.Enabled = cob_DeviceList.Items.Count > 0;
        }

        private void txb_CurrentProcessId_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_CurrentProcessId, txb_CurrentProcessId.Text);
        }

        private void txb_TargetDirectory_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_TargetDirectory, txb_TargetDirectory.Text);
        }

        private void txb_CurrentProjectName_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_CurrentProjectName, txb_CurrentProjectName.Text);
        }

        private void txb_AvailableProjectName_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_AvailableProjectName, txb_AvailableProjectName.Text);
        }

        private void txb_Station_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_Station, txb_Station.Text);
        }

        private void txb_DeviceName_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_DeviceName, txb_DeviceName.Text);
        }

        private void txb_TypeIdentifier_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_TypeIdentifier, txb_TypeIdentifier.Text);
        }

        private void txb_OrderNr_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_OrderNr, txb_OrderNr.Text);
        }

        private void txb_Version_MouseHover(object sender, EventArgs e)
        {
            GeneratorToolTip.SetToolTip(txb_Version, txb_Version.Text);
        }

        private void txb_OrderNr_Leave(object sender, EventArgs e)
        {
            txb_TypeIdentifier.Text = "OrderNumber:" + txb_OrderNr.Text + "/" + txb_Version.Text;
        }

        private void txb_Version_Leave(object sender, EventArgs e)
        {
            txb_TypeIdentifier.Text = "OrderNumber:" + txb_OrderNr.Text + "/" + txb_Version.Text;
        }

        #endregion // BasicProjectGenerator

        #region TIA Portal

        /// <summary>
        /// Open a TIA Portal instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenTiaPortal_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            Cursor.Current = Cursors.WaitCursor;

            _projectGeneratorService.OpenTiaPortal();

            ResetDeviceList();
            ResetDeviceCatalog();

            ManageUiState();

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Connect to a open TIA Portal instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConnectTiaPortal_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            var canConnectToTiaPortal = CheckProjectModified();

            var processId = _projectGeneratorService.GetSelectedProcessId();

            if (canConnectToTiaPortal && processId != -1)
            {
                CloseProject();

                Cursor.Current = Cursors.WaitCursor;

                _projectGeneratorService.ConnectTiaPortal(processId);

                ManageUiState();

                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Close a TIA Portal instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CloseTiaPortal_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            var canCloseTiaPortal = CheckProjectModified();

            if (canCloseTiaPortal)
            {
                CloseProject();
                ResetDeviceList();
                ResetDeviceCatalog();

                _projectGeneratorService.CloseTiaPortal();

                ManageUiState();
            }
        }

        #endregion // TIA Portal

        #region TIA Portal Project

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CreateNewProject_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            var canCreateProject = true;

            if (!string.IsNullOrEmpty(_projectGeneratorService.GetCurrentProjectName()))
            {
                canCreateProject = CheckProjectModified();
            }

            if (canCreateProject)
            {
                CloseProject();

                Cursor.Current = Cursors.WaitCursor;

                _projectGeneratorService.CreateNewProject();

                ManageUiState();

                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Open a selected project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenProject_Click(object sender, EventArgs e)
        {
            try
            {
                var methodBase = MethodBase.GetCurrentMethod();
                _traceWriter.Write(methodBase.Name);

                var canOpenProject = true;

                if (!string.IsNullOrEmpty(_projectGeneratorService.GetCurrentProjectName()))
                {
                    canOpenProject = CheckProjectModified();
                }

                if (canOpenProject)
                {
                    CloseProject();

                    Cursor.Current = Cursors.WaitCursor;

                    _projectGeneratorService.OpenProject();

                    ManageUiState();

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                _traceWriter.Write(exception.Message);
            }
        }

        /// <summary>
        /// Load a open project from connected instance -> see 'DoConnectTiaPortal'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadProject_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            Cursor.Current = Cursors.WaitCursor;

            _projectGeneratorService.LoadProject();

            ManageUiState();

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Save the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveProject_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            Cursor.Current = Cursors.WaitCursor;

            _projectGeneratorService.SaveProject();

            ManageUiState();

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Check for changes and close the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CloseProject_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            var close = CheckProjectModified();

            if (close)
            {
                CloseProject();
            }
        }

        /// <summary>
        /// Close the project and reset details
        /// </summary>
        private void CloseProject()
        {
            _projectGeneratorService.CloseProject();

            ResetDeviceList();
            ResetDeviceCatalog();

            ManageUiState();
        }

        /// <summary>
        /// Check for project changes
        /// </summary>
        /// <returns></returns>
        private bool CheckProjectModified()
        {
            var projectSaved = true;

            if (_apiWrapper.CurrentProject != null && _apiWrapper.CurrentProject.IsModified)
            {
                projectSaved = false;
                var result = MessageBox.Show("Do you want to save the changes to the current project?", "Project has been modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes || result == DialogResult.No)
                {
                    projectSaved = true;
                    if (result == DialogResult.Yes)
                    {
                        _projectGeneratorService.SaveProject();
                    }
                }
                else
                {
                    _traceWriter.Write("Close project was canceled!");
                }
            }

            return projectSaved;
        }

        #endregion // TIA Portal

        #region Device

        /// <summary>
        /// Load the template catalog for new devices from xml.
        /// If th catalog is changed, the current project should be close and reopened
        /// to reload the catalog changes.
        /// </summary>
        private void LoadDeviceCatalog()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            if (_projectGeneratorService.LoadDeviceCatalog())
            {
                if (_projectGeneratorService.DeviceModel.DeviceCatalog.DeviceItemComposition.Count > 0)
                {
                    cob_DeviceTemplates.Items.Clear();
                    cob_DeviceTemplates.ResetText();
                }

                foreach (var device in _projectGeneratorService.DeviceModel.DeviceCatalog.DeviceItemComposition)
                {
                    cob_DeviceTemplates.Items.Add(device.TemplateName);
                }

                if (cob_DeviceTemplates.Items.Count > 0)
                {
                    cob_DeviceTemplates.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Retrieve the device count from project
        /// </summary>
        private void GetCurrentDeviceCount()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            _projectGeneratorService.DeviceModel.CurrentDeviceCount = _apiWrapper.CurrentProject.Devices.Count;

            ResetDeviceList();

            _projectGeneratorService.GetCurrentDeviceList();

            foreach (var item in _projectGeneratorService.DeviceModel.DeviceItemComposition)
            {
                cob_DeviceList.Items.Add(item);
            }
            if (cob_DeviceList.Items.Count > 0)
            {
                cob_DeviceList.SelectedIndex = 0;
            }

            // Get device name for listbox
            foreach (var device in _apiWrapper.CurrentProject.Devices)
            {
                lib_DeviceList.Items.Add(device.Name);
            }
        }

        /// <summary>
        /// Update the UI with new Information if the selected device template has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cob_DeviceTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            if (_projectGeneratorService.DeviceCatalogLoaded)
            {
                var deviceItem =
                    (from device in _projectGeneratorService.DeviceModel.DeviceCatalog.DeviceItemComposition
                     where device.TemplateName == cob_DeviceTemplates.SelectedItem.ToString()
                     select device).FirstOrDefault();

                if (deviceItem != null)
                {
                    _projectGeneratorService.NewDevice = new Device
                    {
                        Station = deviceItem.Station,
                        TemplateName = deviceItem.TemplateName,
                        DeviceName = deviceItem.DeviceName,
                        OrderNumber = deviceItem.OrderNumber,
                        FirmwareVersion = deviceItem.FirmwareVersion,
                        IncludeFailsafe = deviceItem.IncludeFailsafe,
                        PositionNumber = _projectGeneratorService.DeviceModel.CurrentDeviceCount
                    };

                    ckb_IncludeFailsafe.Checked = _projectGeneratorService.NewDevice.IncludeFailsafe;
                    txb_DeviceName.Text = _projectGeneratorService.NewDevice.DeviceName + "_" + (_projectGeneratorService.DeviceModel.CurrentDeviceCount + 1).ToString();
                    txb_Station.Text = _projectGeneratorService.NewDevice.Station;
                    txb_TypeIdentifier.Text = _projectGeneratorService.NewDevice.TypeIdentifier;
                    txb_OrderNr.Text = _projectGeneratorService.NewDevice.OrderNumber;
                    txb_Version.Text = _projectGeneratorService.NewDevice.FirmwareVersion;
                }
            }
        }

        /// <summary>
        /// Reset the device list
        /// </summary>
        private void ResetDeviceList()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            cob_DeviceList.Items.Clear();
            cob_DeviceList.ResetText();

            lib_DeviceList.Items.Clear();
            lib_DeviceList.ResetText();
        }

        /// <summary>
        /// Reset the device catalog (device template list)
        /// </summary>
        private void ResetDeviceCatalog()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            cob_DeviceTemplates.Items.Clear();
            cob_DeviceTemplates.ResetText();

            ckb_IncludeFailsafe.Checked = false;

            txb_DeviceName.Text = string.Empty;
            txb_Station.Text = string.Empty;
            txb_TypeIdentifier.Text = string.Empty;
            txb_OrderNr.Text = string.Empty;
            txb_Version.Text = string.Empty;
        }

        /// <summary>
        /// Retrieve a new device and add it to the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddNewDevice_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            try
            {
                if (GetNewDevice())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    _projectGeneratorService.AddNewDevice(_projectGeneratorService.NewDevice);

                    Cursor.Current = Cursors.Default;

                    _projectGeneratorService.SetPlcSecuritySettings(_projectGeneratorService.NewDevice.Name, _projectGeneratorService.NewDevice.IncludeFailsafe);

                    GetCurrentDeviceCount();

                    ManageUiState();
                }
                else
                {
                    _traceWriter.Write("Error: New device object could not be created.");
                    MessageBox.Show("The properties device name, station, order number and version are required!", "Error create a new device", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                _traceWriter.Write(exception.Message);
            }
        }

        /// <summary>
        /// Create a new device object
        /// </summary>
        /// <returns></returns>
        private bool GetNewDevice()
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            var result = false;

            try
            {
                if (_projectGeneratorService.NewDevice != null)
                {
                    _projectGeneratorService.NewDevice.Station = txb_Station.Text;
                    _projectGeneratorService.NewDevice.DeviceName = txb_DeviceName.Text;
                    _projectGeneratorService.NewDevice.OrderNumber = txb_OrderNr.Text;
                    _projectGeneratorService.NewDevice.FirmwareVersion = txb_Version.Text;
                    _projectGeneratorService.NewDevice.IncludeFailsafe = ckb_IncludeFailsafe.Checked;

                    result = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(txb_Station.Text) ||
                        string.IsNullOrEmpty(txb_DeviceName.Text) ||
                        string.IsNullOrEmpty(txb_OrderNr.Text) ||
                        string.IsNullOrEmpty(txb_Version.Text))
                    {
                        throw new Exception("Error: The properties device name, station, order number and version are required!");
                    }
                    else
                    {
                        _projectGeneratorService.NewDevice = new Device
                        {
                            Station = txb_Station.Text,
                            TemplateName = "custom edit",
                            DeviceName = txb_DeviceName.Text,
                            OrderNumber = txb_OrderNr.Text,
                            FirmwareVersion = txb_Version.Text,
                            IncludeFailsafe = ckb_IncludeFailsafe.Checked,
                            PositionNumber = _projectGeneratorService.DeviceModel.CurrentDeviceCount
                        };

                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                _traceWriter.Write(e.Message);
            }

            return result;
        }

        #endregion // Device

        #region Compile

        /// <summary>
        /// Set the current device if the selected item has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cob_DeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            if (cob_DeviceList.Items.Count > 0)
            {
                _projectGeneratorService.SetCurrentDevice((DeviceItem)cob_DeviceList.SelectedItem);
            }
        }

        /// <summary>
        /// Compile the selected device item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CompileDevice_Click(object sender, EventArgs e)
        {
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name);

            Cursor.Current = Cursors.WaitCursor;

            var deviceItem = (DeviceItem)cob_DeviceList.SelectedItem;

            _projectGeneratorService.CompileDevice(deviceItem);

            Cursor.Current = Cursors.Default;
        }

        #endregion // Compile

        #endregion // methods
    }
}
