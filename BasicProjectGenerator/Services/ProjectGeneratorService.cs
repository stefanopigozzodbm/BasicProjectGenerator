using Basic_Project_Generator.Interfaces;
using Basic_Project_Generator.Models;
using Basic_Project_Generator.UserInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Basic_Project_Generator.Services
{
    public class ProjectGeneratorService
    {
        #region fields

        private readonly TraceWriter _traceWriter;
        private readonly ApiWrapper _apiWrapper;

        #endregion // fields

        #region ctor

        public ProjectGeneratorService(TraceWriter traceWriter, ApiWrapper apiWrapper)
        {
            _traceWriter = traceWriter;
            _apiWrapper = apiWrapper;
            NewProject = new ProjectModel();
            DeviceModel = new DeviceModel
            {
                DeviceItemComposition = new List<DeviceItem>()
            };
            SelectedProcessIndex = -1;
            NewDevice = null;
        }

        #endregion // ctor

        #region properties

        public ProjectModel NewProject
        {
            get;
            set;
        }

        public int SelectedProcessIndex
        {
            get;
            set;
        }

        public string SelectedProcessItem
        {
            get;
            set;
        }

        public string SelectedProject
        {
            get;
            set;
        }

        public XDocument DeviceCatalogXml
        {
            get;
            set;
        }

        public DeviceModel DeviceModel
        {
            get;
            set;
        }

        public bool DeviceCatalogLoaded
        {
            get;
            set;
        }

        public Device NewDevice
        {
            get;
            set;
        }

        #endregion // properties

        #region methods

        #region TIA Portal

        /// <summary>
        /// Open a TIA Portal instance
        /// </summary>
        /// <param name="caller"></param>
        public void OpenTiaPortal([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoOpenTiaPortal();
        }

        /// <summary>
        /// Connect to a open TIA Portal instance
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="caller"></param>
        public void ConnectTiaPortal(int processId, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoConnectTiaPortal(processId);
        }

        /// <summary>
        /// Close a TIA Portal instance
        /// </summary>
        /// <param name="caller"></param>
        public void CloseTiaPortal([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoCloseTiaPortal();
        }

        /// <summary>
        /// Retrieve the current process id
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public string GetCurrentTiaProcessId([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            return _apiWrapper.DoGetCurrentTiaProcessId();
        }

        /// <summary>
        /// Get all TIA Portal processes on the local machine
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public IList<string> GetTiaPortalProcesses([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            return _apiWrapper.DoGetTiaPortalProcesses();
        }

        /// <summary>
        /// Extract the process id from selected item and convert to int value
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public int GetSelectedProcessId([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var id = -1;
            if (SelectedProcessIndex > -1)
            {
                id = Convert.ToInt32(SelectedProcessItem.Split(' ')[1]);
            }
            return id;
        }

        /// <summary>
        /// Extract the process id from selected item and get it as string
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public string GetSelectedProcessIdAsString([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var processId = string.Empty;
            if (GetSelectedProcessId() > -1)
            {
                processId = GetSelectedProcessId().ToString();
            }
            return processId;
        }

        #endregion // TIA Portal.

        #region TIA Portal Project

        /// <summary>
        /// Retrieve the current project name
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public string GetCurrentProjectName([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            return _apiWrapper.CurrentProject != null ? _apiWrapper.CurrentProject.Name : string.Empty;
        }

        /// <summary>
        /// Retrieve the current project target directory
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public string GetTargetDirectory([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            return _apiWrapper.CurrentProject != null ? _apiWrapper.CurrentProject.Path.DirectoryName : string.Empty;
        }

        /// <summary>
        /// Retrieve the available project from TIA Portal instance
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public string GetAvailableProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var availableProject = string.Empty;
            if (_apiWrapper.TiaPortal != null && _apiWrapper.TiaPortalIsDisposed == false)
            {
                _apiWrapper.AvailableProject = _apiWrapper.TiaPortal.Projects.FirstOrDefault();

                if (_apiWrapper.AvailableProject != null)
                {
                    availableProject = _apiWrapper.AvailableProject.Name;
                }
            }
            return availableProject;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool CreateNewProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;
            var newTiaPortalProject = new NewTiaPortalProject();
            if (DialogResult.OK == newTiaPortalProject.ShowDialog())
            {
                NewProject.Name = newTiaPortalProject.ProjectName;
                NewProject.TargetDirectory = new DirectoryInfo(newTiaPortalProject.Path);
                if (_apiWrapper.DoCreateNewProject(NewProject))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Open a selected project
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool OpenProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;
            if (SelectProject())
            {
                if (_apiWrapper.DoOpenProject(SelectedProject))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Open a file dialog and retrieve all *.ap* files to select a project file
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        private bool SelectProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;
            SelectedProject = string.Empty;
            var fileSearch = new OpenFileDialog
            {
                Filter = "TIA Portal projects|*.ap*",
                RestoreDirectory = true
            };
            if (DialogResult.OK == fileSearch.ShowDialog())
            {
                SelectedProject = fileSearch.FileName;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Load a open project from connected instance -> see 'DoConnectTiaPortal'
        /// </summary>
        /// <param name="caller"></param>
        public void LoadProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoLoadProject();
        }

        /// <summary>
        /// Save changes to a project
        /// </summary>
        /// <param name="caller"></param>
        public void SaveProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoSaveProject();
        }

        /// <summary>
        /// Close a project
        /// </summary>
        /// <param name="caller"></param>
        public void CloseProject([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoCloseProject();
        }

        /// <summary>
        /// Retrieve the device list from current project
        /// </summary>
        /// <param name="caller"></param>
        public void GetCurrentDeviceList([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            DeviceModel.DeviceItemComposition.Clear();
            _apiWrapper.GetCurrentDeviceList(DeviceModel);
        }

        /// <summary>
        /// Set the selected deviceItem as the current device 
        /// </summary>
        /// <param name="deviceItem"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool SetCurrentDevice(DeviceItem deviceItem, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = _apiWrapper.SetCurrentDevice(deviceItem);
            if (!result)
            {
                _traceWriter.Write("No device found!");
            }
            else
            {
                _traceWriter.Write("Device found: " + deviceItem.DeviceName);
            }
            return result;
        }

        #endregion // TIA Portal Project

        #region Device

        /// <summary>
        /// Load the template catalog for new devices from xml.
        /// If th catalog is changed, the current project should be close and reopened
        /// to reload the catalog changes.
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool LoadDeviceCatalog([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            DeviceCatalogLoaded = false;
            DeviceCatalogXml = XDocument.Load("Assets\\DeviceCatalog.xml");
            DeviceModel.LoadDeviceCatalog(DeviceCatalogXml);
            DeviceCatalogLoaded = true;
            return DeviceCatalogLoaded;
        }

        /// <summary>
        /// Add a new device to a project
        /// </summary>
        /// <param name="device"></param>
        /// <param name="caller"></param>
        public void AddNewDevice(Device device, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoAddNewDevice(device.TypeIdentifier, device.Name, device.TypeName);
        }

        /// <summary>
        /// Set PLC Security settings.
        /// The Security settings dialog will be opened for entering the security configuration.
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="includeFailsafe"></param>
        /// <param name="caller"></param>
        public void SetPlcSecuritySettings(string deviceName, bool includeFailsafe, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var plcSecuritySettings = new PlcSecuritySettings
            {
                IncludeFailsafe = includeFailsafe
            };
            if (DialogResult.OK == plcSecuritySettings.ShowDialog())
            {
                var protectPlcConfiguration = plcSecuritySettings.ProtectPlcConfiguration;
                var masterSecretPassword = plcSecuritySettings.MasterSecretPassword;
                var accessLevelPassword = plcSecuritySettings.AccessLevelPassword;
                var accessLevel = plcSecuritySettings.AccessLevel;
                var displayProtection = plcSecuritySettings.DisplayProtection;
                var displayProtectionPassword = plcSecuritySettings.DisplayProtectionPassword;
                var timeUntilDisplayAutoLogoff = plcSecuritySettings.TimeUntilDisplayAutoLogoff;

                _apiWrapper.DoSetPlcSecuritySettings(deviceName, includeFailsafe, protectPlcConfiguration, accessLevel, masterSecretPassword, accessLevelPassword);
                _apiWrapper.DoSetDisplayProtection(deviceName, displayProtection, timeUntilDisplayAutoLogoff, displayProtectionPassword);
            }
        }

        #endregion // Device

        #region Compile

        /// <summary>
        /// Compile a selected device item
        /// </summary>
        /// <param name="deviceItem"></param>
        /// <param name="caller"></param>
        public void CompileDevice(DeviceItem deviceItem, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoCompileDevice(deviceItem);
        }

        #endregion // Compile

        #endregion // methods
    }
}
