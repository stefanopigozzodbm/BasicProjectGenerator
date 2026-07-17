using Siemens.Engineering;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace Basic_Project_Generator.Interfaces
{
    public class ApiWrapper : INotifyPropertyChanged
    {
        #region fields

        private IList<TiaPortalProcess> _tiaPortalProcessList;
        private readonly TraceWriter _traceWriter;
        private TiaPortalMode _tiaPortalMode;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Fields

        #region ctor

        public ApiWrapper(TraceWriter traceWriter, [CallerMemberName] string caller = "")
        {
            _traceWriter = traceWriter;
            var methodBase = MethodBase.GetCurrentMethod();
            _traceWriter.Write(methodBase.Name + " called from " + caller + "\n");
        }

        #endregion // ctor

        #region properties

        public TiaPortalProcess CurrentTiaPortalProcess
        {
            get;
            set;
        }

        public TiaPortal TiaPortal
        {
            get;
            set;
        }

        public bool TiaPortalIsDisposed
        {
            get;
            set;
        }

        public bool IsModified
        {
            get;
            set;
        }

        public Project CurrentProject
        {
            get;
            set;
        }

        public Project AvailableProject
        {
            get;
            set;
        }

        public TiaPortalMode TiaPortalMode
        {
            get => _tiaPortalMode;
            set
            {
                if (value != _tiaPortalMode)
                {
                    _tiaPortalMode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Device Device
        {
            get;
            set;
        }

        #endregion // properties

        #region methods

        #region common

        /// <summary>
        /// Notification of changes
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " " + propertyName);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Get the enum value to a string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        public T GetEnumValue<T>(string value, [CallerMemberName] string caller = "") where T : struct, IConvertible
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            if (!typeof(T).IsEnum)
            {
                _traceWriter.Write("T must be an Enumeration type!");
                throw new Exception("T must be an Enumeration type!");
            }
            var enumValue = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(value))
            {
                foreach (var itemValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (itemValue.ToString().ToUpper().Equals(value.ToUpper()))
                    {
                        enumValue = itemValue;
                        break;
                    }
                }
            }
            return enumValue;
        }

        #endregion // common

        #region TIA Portal

        /// <summary>
        /// Open a TIA Portal instance
        /// </summary>
        /// <param name="caller"></param>
        public void DoOpenTiaPortal([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            TiaPortal = new TiaPortal(TiaPortalMode);
            TiaPortalIsDisposed = false;
        }

        /// <summary>
        /// Connect to a open TIA Portal instance
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="caller"></param>
        public void DoConnectTiaPortal(int processId, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var portal = TiaPortal.GetProcess(processId, 5000).Attach();
            if (portal != null)
            {
                TiaPortal?.Dispose();
                TiaPortalIsDisposed = true;
                CurrentProject = null;
                TiaPortal = portal;
                TiaPortalIsDisposed = false;
            }
        }

        /// <summary>
        /// Close a TIA Portal instance
        /// </summary>
        /// <param name="caller"></param>
        public void DoCloseTiaPortal([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            TiaPortal.GetCurrentProcess().Dispose();
            TiaPortalIsDisposed = true;
            CurrentProject = null;
        }

        /// <summary>
        /// Get all TIA Portal processes on the local machine
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public IList<string> DoGetTiaPortalProcesses([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            IList<string> processIds = null;
            CurrentTiaPortalProcess = TiaPortal?.GetCurrentProcess();
            _tiaPortalProcessList = new List<TiaPortalProcess>();
            _tiaPortalProcessList = TiaPortal.GetProcesses();
            if (_tiaPortalProcessList.Count > 0)
            {
                processIds = new List<string>();
                foreach (var item in _tiaPortalProcessList)
                {
                    var mode = item.Mode == TiaPortalMode.WithoutUserInterface ? " Without UI" : " With UI";
                    processIds.Add($"ID {item.Id} \t {mode}");
                }
            }
            return processIds;
        }

        /// <summary>
        /// Get the current process id
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public string DoGetCurrentTiaProcessId([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            return CurrentTiaPortalProcess != null ? CurrentTiaPortalProcess.Id.ToString() : string.Empty;
        }

        #endregion // TIA Portal

        #region TIA Portal Project

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="projectModel"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool DoCreateNewProject(Models.ProjectModel projectModel, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;
            DoCloseProject();
            var newProject = TiaPortal.Projects.Create(projectModel.TargetDirectory, projectModel.Name);
            _traceWriter.Write($"TiaPortal.Projects.Create({projectModel.TargetDirectory.FullName}, {projectModel.Name}");
            if (newProject != null)
            {
                CurrentProject = newProject;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Open a project
        /// </summary>
        /// <param name="path"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool DoOpenProject(string path, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var processId = -1;
            var result = false;
            var loadOpenProject = false;
            var accessGranted = true;
            DoCloseProject();
            _tiaPortalProcessList = new List<TiaPortalProcess>();
            _tiaPortalProcessList = TiaPortal.GetProcesses();
            if (_tiaPortalProcessList.Count > 0)
            {
                foreach (var item in _tiaPortalProcessList)
                {
                    if (item.ProjectPath != null && item.ProjectPath.FullName == path)
                    {
                        processId = item.Id;
                        accessGranted = false;
                        loadOpenProject = true;
                        if (MessageBox.Show("Do you want to connect to the instance (process: " + processId + ")?", "The project is already open", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            accessGranted = true;
                        }
                        break;
                    }
                }
            }
            if (!loadOpenProject)
            {
                var newProject = TiaPortal.Projects.Open(new FileInfo(path));
                _traceWriter.Write($"TiaPortal.Projects.Open({path}");
                if (newProject != null)
                {
                    CurrentProject = newProject;
                    result = true;
                }
            }
            if (loadOpenProject && accessGranted && processId != -1)
            {
                DoConnectTiaPortal(processId);
                DoLoadProject();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Load a project from connected instance -> see 'DoConnectTiaPortal'
        /// </summary>
        /// <param name="caller"></param>
        public void DoLoadProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            CurrentProject = TiaPortal.Projects.FirstOrDefault();
        }

        /// <summary>
        /// Save changes to a project
        /// </summary>
        /// <param name="caller"></param>
        public void DoSaveProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null)
                _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            CurrentProject.Save();
        }

        /// <summary>
        /// Closes the first and only open project of the connected TIA portal instance 
        /// </summary>
        /// <param name="caller"></param>
        public void DoCloseProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            if (!TiaPortalIsDisposed && TiaPortal?.Projects.Count > 0)
            {
                var project = TiaPortal.Projects.FirstOrDefault();
                project?.Close();
            }
            CurrentProject = null;
        }

        #endregion // TIA Portal Project

        #region Device

        /// <summary>
        /// Get the list of devices in the loaded project
        /// </summary>
        /// <param name="deviceModel"></param>
        /// <param name="caller"></param>
        public void GetCurrentDeviceList(Models.DeviceModel deviceModel, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            foreach (var device in CurrentProject.Devices)
            {
                var deviceItemComposition = device.DeviceItems;
                foreach (var deviceItem in deviceItemComposition)
                {
                    if (deviceItem.Classification == DeviceItemClassifications.CPU)
                    {
                        var newItem = new Models.DeviceItem
                        {
                            Name = deviceItem.Name,
                            DeviceName = device.Name,
                            Classification = deviceItem.Classification.ToString()
                        };
                        deviceModel.DeviceItemComposition.Add(newItem);
                    }
                }
            }
        }

        /// <summary>
        /// Set the selected deviceItem as the current device
        /// </summary>
        /// <param name="deviceItem"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool SetCurrentDevice(Models.DeviceItem deviceItem, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;
            foreach (var device in CurrentProject.Devices)
            {
                if (device.Name == deviceItem.DeviceName)
                {
                    var deviceItemComposition = device.DeviceItems;
                    foreach (var item in deviceItemComposition)
                    {
                        if (item.Name == deviceItem.Name)
                        {
                            Device = device;
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Add a new device based on device template
        /// </summary>
        /// <param name="typeIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="deviceName"></param>
        /// <param name="caller"></param>
        public void DoAddNewDevice(string typeIdentifier, string name, string deviceName, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            Device = CurrentProject.Devices.CreateWithItem(typeIdentifier, name, deviceName);
            IsModified = CurrentProject.IsModified;
        }

        /// <summary>
        /// Set PLC security settings
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="includeFailsafe"></param>
        /// <param name="protectConfiguration"></param>
        /// <param name="accessLevel"></param>
        /// <param name="masterSecretPassword"></param>
        /// <param name="accessLevelPassword"></param>
        /// <param name="caller"></param>
        public void DoSetPlcSecuritySettings(string deviceName, bool includeFailsafe, bool protectConfiguration, string accessLevel, SecureString masterSecretPassword, SecureString accessLevelPassword, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var accessLevelValue = GetEnumValue<PlcProtectionAccessLevel>(accessLevel);
            if (protectConfiguration)
            {
                SetPlcMasterSecretConfiguration(deviceName, masterSecretPassword);
            }
            SetPlcProtectionAccessLevel(deviceName, includeFailsafe, accessLevelValue, accessLevelPassword);
        }

        /// <summary>
        /// Set PLC protection settings
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="password"></param>
        /// <param name="caller"></param>
        private void SetPlcMasterSecretConfiguration(string deviceName, SecureString password, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var deviceItemComposition = Device.DeviceItems;
            foreach (var deviceItem in deviceItemComposition)
            {
                if (deviceItem.Name == deviceName || Device.Name == deviceName)
                {
                    var plcMasterSecretConfigurator = deviceItem.GetService<PlcMasterSecretConfigurator>();
                    plcMasterSecretConfigurator?.Protect(password);
                }
            }
        }

        /// <summary>
        /// Set PLC protection access level
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="includeFailsafe"></param>
        /// <param name="accessLevel"></param>
        /// <param name="password"></param>
        /// <param name="caller"></param>
        private void SetPlcProtectionAccessLevel(string deviceName, bool includeFailsafe, PlcProtectionAccessLevel accessLevel, SecureString password, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var deviceItemComposition = Device.DeviceItems;
            foreach (var deviceItem in deviceItemComposition)
            {
                if (deviceItem.Name == deviceName || Device.Name == deviceName)
                {
                    var plcAccessLevelProvider = deviceItem.GetService<PlcAccessLevelProvider>();
                    if (plcAccessLevelProvider != null)
                    {
                        if (accessLevel == PlcProtectionAccessLevel.FullAccess)
                        {
                            plcAccessLevelProvider.PlcProtectionAccessLevel = accessLevel;
                        }
                        else
                        {
                            plcAccessLevelProvider.PlcProtectionAccessLevel = accessLevel;
                            if (includeFailsafe)
                            {
                                plcAccessLevelProvider.SetPassword(PlcProtectionAccessLevel.FullAccessIncludingFailsafe, password);
                            }
                            else
                            {
                                plcAccessLevelProvider.SetPassword(PlcProtectionAccessLevel.FullAccess, password);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set display protection settings
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="displayProtection"></param>
        /// <param name="timeUntilDisplayAutoLogoff"></param>
        /// <param name="displayProtectionPassword"></param>
        /// <param name="caller"></param>
        public void DoSetDisplayProtection(string deviceName, bool displayProtection, string timeUntilDisplayAutoLogoff, SecureString displayProtectionPassword, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var deviceItemComposition = Device.DeviceItems;
            foreach (var deviceItem in deviceItemComposition)
            {
                if (deviceItem.Name == deviceName || Device.Name == deviceName)
                {
                    var items = deviceItem.DeviceItems;
                    if (items != null && items.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            var displayProtectionService = item.GetService<DisplayProtection>();
                            if (displayProtectionService != null)
                            {
                                if (displayProtection)
                                {
                                    var displayAutoLogOffTime = GetEnumValue<DisplayAutoLogOffTime>(timeUntilDisplayAutoLogoff);
                                    displayProtectionService.SetAttribute("DisplayProtection", true);
                                    displayProtectionService.SetAttribute("DisplayAutoLogOffTime", displayAutoLogOffTime);
                                    displayProtectionService.SetPassword(displayProtectionPassword);
                                }
                                else
                                {
                                    displayProtectionService.SetAttribute("DisplayProtection", false);
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        #endregion // Device

        #region Compile

        /// <summary>
        /// Compile a device
        /// </summary>
        /// <param name="deviceItem"></param>
        /// <param name="caller"></param>
        public void DoCompileDevice(Models.DeviceItem deviceItem, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var deviceNotFound = true;
            foreach (var device in CurrentProject.Devices)
            {
                if (device.Name == deviceItem.DeviceName)
                {
                    var deviceItemComposition = device.DeviceItems;
                    foreach (var item in deviceItemComposition)
                    {
                        if (item.Name == deviceItem.Name)
                        {
                            var softwareContainer = item.GetService<SoftwareContainer>();
                            if (softwareContainer != null)
                            {
                                if (softwareContainer.Software is PlcSoftware)
                                {
                                    var controllerTarget = softwareContainer.Software as PlcSoftware;
                                    if (controllerTarget != null)
                                    {
                                        deviceNotFound = false;
                                        var plcCompiler = controllerTarget.GetService<ICompilable>();
                                        var plcCompilerResult = plcCompiler.Compile();
                                        var compilerMessage = "Compiling Software of " + deviceItem.DeviceName + " - " + deviceItem.Name;
                                        _traceWriter.Write(compilerMessage);
                                        if (plcCompilerResult.Messages.Count > 0)
                                        {
                                            if (plcCompilerResult.Messages != null && plcCompilerResult.Messages.Count > 0)
                                            {
                                                GetCompilerMessages("", plcCompilerResult.Messages);
                                            }
                                        }
                                    }
                                }
                                if (softwareContainer.Software is HmiTarget)
                                {
                                    var hmiTarget = softwareContainer.Software as HmiTarget;
                                    if (hmiTarget != null)
                                    {
                                        deviceNotFound = false;
                                        var hmiCompiler = hmiTarget.GetService<ICompilable>();
                                        var hmiCompilerResult = hmiCompiler.Compile();
                                        var compilerMessage = "Compiling HMI of " + deviceItem.DeviceName + " - " + deviceItem.Name;
                                        _traceWriter.Write(compilerMessage);
                                        if (hmiCompilerResult.Messages.Count > 0)
                                        {
                                            if (hmiCompilerResult.Messages != null && hmiCompilerResult.Messages.Count > 0)
                                            {
                                                GetCompilerMessages("", hmiCompilerResult.Messages);
                                            }
                                        }
                                    }
                                }
                            }
                            var compileProvider = item.GetService<ICompilable>();
                            if (compileProvider != null)
                            {
                                deviceNotFound = false;
                                var compileResult = compileProvider.Compile();
                                var compilerMessage = "Compiling Hardware of " + deviceItem.DeviceName + " - " + deviceItem.Name;
                                _traceWriter.Write(compilerMessage);
                                if (compileResult.Messages.Count > 0)
                                {
                                    if (compileResult.Messages != null && compileResult.Messages.Count > 0)
                                    {
                                        GetCompilerMessages("", compileResult.Messages);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (deviceNotFound)
            {
                _traceWriter.Write("No device found to compile!");
            }
        }

        /// <summary>
        /// Retrieve recursive the compile messages
        /// </summary>
        /// <param name="path"></param>
        /// <param name="messageComposition"></param>
        private void GetCompilerMessages(string path, CompilerResultMessageComposition messageComposition)
        {
            foreach (var message in messageComposition)
            {
                if (message.Messages != null && message.Messages.Count > 0)
                {
                    GetCompilerMessages(message.Path, message.Messages);
                }
                if (!string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(message.Description))
                {
                    var compilerMessage = "Path: " + path + " / State: " + message.State + " / Description: " + message.Description;
                    _traceWriter.Write(compilerMessage);
                }
                if (string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(message.Description))
                {
                    var compilerMessage = "State: " + message.State + " / Description: " + message.Description;
                    _traceWriter.Write(compilerMessage);
                }
            }
        }

        #endregion // Compile

        #endregion // methods
    }
}
