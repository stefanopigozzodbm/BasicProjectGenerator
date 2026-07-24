using NPOI.SS.Formula.Functions;
using NPOI.XSSF.Streaming.Values;
using Siemens.Collaboration.Net.Logging;
using Siemens.Engineering;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        public UserGlobalLibrary CurrentUserGLobalLibrary
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


        /// <summary>
        /// Open User Global Library
        /// </summary>
        /// <param name="caller"></param>
        public bool DoOpenLibrary(string path, [CallerMemberName] string caller = "")
        {
            var result = false;
            FileInfo fileInfo = new FileInfo(path); 

            UserGlobalLibrary userLib = TiaPortal.GlobalLibraries.Open(fileInfo, OpenMode.ReadOnly);

            //var itemList = TiaPortal.HardwareCatalog.Find("AL1102");



            //var first = itemList.First();

            //Debug.WriteLine(first.TypeIdentifier);
            var itemList = TiaPortal.HardwareCatalog.Find("AL1102");
            Debug.WriteLine("Trovati " + itemList.Count + " risultati");
            _traceWriter.Write("Trovati " + itemList.Count + " risultati");
            var first = itemList.First();
            foreach (var item in itemList)
            {
                Debug.WriteLine(first.TypeIdentifier);
                Debug.WriteLine(item.GetType().Name + " -> " + item.ToString());
                _traceWriter.Write(item.GetType().Name + " -> " + item.ToString());
            }

            foreach (var item in itemList)
            {
                var entry = item as Siemens.Engineering.HW.HardwareCatalog.CatalogEntry;
                if (entry == null) continue;

                _traceWriter.Write("--- CatalogEntry ---");
                foreach (var prop in entry.GetType().GetProperties())
                {
                    try
                    {
                        var value = prop.GetValue(entry);
                        Debug.WriteLine(prop.Name + " = " + value);
                        _traceWriter.Write(prop.Name + " = " + value);
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(prop.Name + " = (non leggibile: " + exception.Message + ")");
                        _traceWriter.Write(prop.Name + " = (non leggibile: " + exception.Message + ")");
                    }
                }
            }







            if (userLib != null)
            {
                CurrentUserGLobalLibrary = userLib;
                result = true;
            }

            DumpLibraryStructure();

            return result;
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
        /* in analogia a DoAddNewModule ma per i parametri di configurazione del PLC (doaddnewdevice) 
         * public void DoAddNewDevice(string typeIdentifier, string name, 
         * string deviceName,Basic_Project_Generator.Models.Device catalogDevice,
         * int? digitalInputStartAddress, int? digitalOutputStartAddress,int? analogInputStartAddress, 
         * int? analogOutputStartAddress,IReadOnlyDictionary<int, string> intPeriphName,string ipAddress, 
         * Dictionary<string, object> startupAttributes, [CallerMemberName] string caller = "")
        */

        public void DoAddNewDevice(Basic_Project_Generator.Models.DeviceConfiguration config, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            Device = CurrentProject.Devices.CreateWithItem(config.TypeIdentifier, config.Name, config.DeviceName);
            IsModified = CurrentProject.IsModified;

            try
            {
                if (Device != null)
                {
                    _traceWriter.Write("Assign IO Add to: " + config.Name);
                    SetDeviceAddresses(config.CatalogDevice, config.DigitalInputStartAddress, config.DigitalOutputStartAddress,
                        config.AnalogInputStartAddress, config.AnalogOutputStartAddress, config.IntPeriphName);
                    
                    SetDeviceIpAddress(Device.DeviceItems[1], config.StartupIpAddresses.TryGetValue("Intereface1", out var ipAddress) ? ipAddress.ToString() : string.Empty);
                    
                    SetDeviceAttributes(Device.DeviceItems[1], config.StartupAttributes);

                  
                }
            }
            catch (Exception exception)
            {
                if (methodBase.ReflectedType != null)
                {
                    _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " - trovato in intPeriphName: " + exception.Message);
                }
                else
                {
                    _traceWriter.Write("DoAddNewDevice - trovato in intPeriphName: " + exception.Message);
                }
            }
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

              

        /// <summary>
        /// Imposta l'indirizzo di start su PLC (Device)
        private void SetDeviceAddresses(Basic_Project_Generator.Models.Device catalogDevice,int? digitalInputStartAddress,int? digitalOutputStartAddress,int? analogInputStartAddress,int? analogOutputStartAddress,IReadOnlyDictionary<int, string> intPeriphName)
        {

            var excelAddresses = new List<int>();
            if (digitalInputStartAddress.HasValue) excelAddresses.Add(digitalInputStartAddress.Value);
            if (digitalOutputStartAddress.HasValue) excelAddresses.Add(digitalOutputStartAddress.Value);
            if (analogInputStartAddress.HasValue) excelAddresses.Add(analogInputStartAddress.Value);
            if (analogOutputStartAddress.HasValue) excelAddresses.Add(analogOutputStartAddress.Value);

            // Device qui è il campo di classe (Siemens HW Device), NON il parametro catalogDevice.
            // Device.DeviceItems[0] = rack, Device.DeviceItems[1] = PLC
            foreach (var (owner, address) in GetAllAddressesWithOwner(Device.DeviceItems[1]))
            {
                var ioType = address.GetAttribute("IoType")?.ToString();

                if (!intPeriphName.TryGetValue(owner.PositionNumber, out var onboardName))
                {
                    _traceWriter.Write(owner.PositionNumber + " - NON trovato in intPeriphName");
                    continue;
                }

                _traceWriter.Write(owner.PositionNumber + " - trovato in intPeriphName: " + onboardName);

                int? valueToSet = null;

                if (onboardName.StartsWith("HSC_") || onboardName.StartsWith("PTOPWM_"))
                {
                    valueToSet = catalogDevice.GetOnboardConstantAddress(onboardName);

                    if (valueToSet.HasValue && excelAddresses.Contains(valueToSet.Value))
                    {
                        _traceWriter.Write("ATTENZIONE: indirizzo costante " + valueToSet.Value + " di " + onboardName + " coincide con un indirizzo già assegnato dall'Excel. Verificare manualmente.");
                    }
                }
                else if (onboardName == "AI2" && ioType == "Input")
                {
                    valueToSet = analogInputStartAddress;
                }
                else if (onboardName == "DI14DQ10")
                {
                    valueToSet = ioType == "Input" ? digitalInputStartAddress : digitalOutputStartAddress;
                }

                if (valueToSet.HasValue)
                {
                    try
                    {
                        address.SetAttribute("StartAddress", valueToSet.Value);
                        _traceWriter.Write(onboardName + " (" + ioType + ") impostato a " + valueToSet.Value);
                    }
                    catch (Exception exception)
                    {
                        _traceWriter.Write("Errore impostando " + onboardName + ": " + exception.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Imposta l'indirizzo IP sull'interfaccia PROFINET del PLC appena creato.
        /// Cerca ricorsivamente, tra il DeviceItem del PLC e i suoi figli, il primo che espone
        /// il servizio NetworkInterface, e ne imposta il primo Node.
        /// NOTA: nomi "NetworkInterface"/"Address" da riconfermare con TIA Openness Explorer
        /// se il PLC ha più interfacce (es. seconda PROFINET) e serve puntarne una specifica.
        /// </summary>
        private void SetDeviceIpAddress(DeviceItem plcDeviceItem, string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                return;
            }

            if (!System.Net.IPAddress.TryParse(ipAddress, out _))
            {
                _traceWriter.Write("Indirizzo IP non valido: '" + ipAddress + "', assegnazione saltata.");
                return;
            }

            if (TrySetIpAddressRecursive(plcDeviceItem, ipAddress))
            {
                _traceWriter.Write("IP " + ipAddress + " impostato su " + plcDeviceItem.Name);
            }
            else
            {
                _traceWriter.Write("Nessuna interfaccia PROFINET trovata su " + plcDeviceItem.Name + ", IP non impostato.");
            }
        }

        private bool TrySetIpAddressRecursive(DeviceItem deviceItem, string ipAddress, string path = "")
        {
            var currentPath = string.IsNullOrEmpty(path) ? deviceItem.Name : path + " / " + deviceItem.Name;

            try
            {
                var networkInterface = deviceItem.GetService<Siemens.Engineering.HW.Features.NetworkInterface>();
                if (networkInterface != null && networkInterface.Nodes.Count > 0)
                {
                    networkInterface.Nodes[0].SetAttribute("Address", ipAddress);
                    _traceWriter.Write("NetworkInterface trovata al percorso: " + currentPath);
                    Debug.WriteLine("NetworkInterface trovata al percorso: " + currentPath);
                    return true;
                }
            }
            catch (Exception exception)
            {
                _traceWriter.Write("Errore impostando IP su " + currentPath + ": " + exception.Message);
            }

            foreach (var childItem in deviceItem.DeviceItems)
            {
                if (TrySetIpAddressRecursive(childItem, ipAddress, currentPath))
                {
                    return true;
                }
            }

            return false;
        }


        //non compresa CPU -> vd DoAddNewDevice
        /*vecchia implementazione prima del 23/07/2926, i parametri passati erano tutti
         * separati ma la cosa risultava troppo disordinata
         *...public bool DoAddNewModule(string typeIdentifier, string name, 
         *int? inputStartAddress = null, int? outputStartAddress = null, 
         *bool newPotentialGroup = false,[CallerMemberName] string caller = "")*/

        public bool DoAddNewModule(Basic_Project_Generator.Models.ModuleConfiguration config, [CallerMemberName] string caller = "")

        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;

            var rack = Device?.DeviceItems.FirstOrDefault();
            if (rack != null)
            {
                var occupiedSlots = rack.DeviceItems.Select(di => di.PositionNumber).ToList();

                for (var slot = 1; slot <= 20; slot++)
                {
                    if (occupiedSlots.Contains(slot)) continue;

                    try
                    {
                        var newModule = rack.PlugNew(config.TypeIdentifier, config.Name, slot);
                        if (newModule != null)
                        {
                                        IsModified = true;
                                        result = true;
                                        _traceWriter.Write("Module plugged in slot " + slot);

                                        SetModuleAddresses(newModule, config.InputStartAddress, config.OutputStartAddress);

                                        var deviceItemIndex = slot + 1;
                                        SetModulePotentialGroup(config.NewPotentialGroup ? (ulong)1 : 0, deviceItemIndex);

                                        SetModuleSafetyChannels(newModule, config.SafetyChannels);

                                        break;
                                    }
                    }
                    catch (Exception exception)
                    {

                            if (methodBase.ReflectedType != null)
                            {
                                Debug.WriteLine(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller + " Exception: " + exception+ "Slot: "+ slot);
                                _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller + " \n\rException: " + exception.Message + "Slot: " + slot + " \n\rGià Occupato" );
                            }
                            // Slot non valido per questo modulo -> provo il successivo
                        }
                    }

                if (!result)
                {
                    _traceWriter.Write("No free/valid slot found for module " + config.Name);
                }
            }
            return result;
            }

        /// <summary>
        /// Imposta Failsafe_SensorEvaluation e Failsafe_SensorSupply sui canali indicati di un modulo Safety appena innestato.
        /// Percorso: moduleDeviceItem.DeviceItems[0].Channels[channelNumber] (confermato via TIA Openness Explorer
        /// per F-DI 8x24VDC HF; se in futuro un altro modulo Safety avesse struttura diversa, va riverificato).
        /// </summary>
        private void SetModuleSafetyChannels(DeviceItem moduleDeviceItem, List<Basic_Project_Generator.Models.SafetyChannelConfiguration> safetyChannels)
        {
            if (safetyChannels == null || safetyChannels.Count == 0) return;

            DeviceItem channelHolder;
            try
            {
                channelHolder = moduleDeviceItem.DeviceItems[0];
            }
            catch (Exception exception)
            {
                _traceWriter.Write("Impossibile accedere a DeviceItems[0] su " + moduleDeviceItem.Name + " per configurazione Safety: " + exception.Message);
                return;
            }

            foreach (var channelConfig in safetyChannels)
            {
                try
                {
                    var channel = channelHolder.Channels[channelConfig.ChannelNumber];

                    //il problme anasce dal fatto che se disattivo canale non posso più accedere al sensor evalutation
                    if (channelConfig.FailsafeActivated) // necessario perchè nel momento che si disattiva un canale automaticamente gli attributi Failsafe_SensorEvaluation e Failsafe_SensorSupply NON sono più accessibili e genererebbe una eccezione
                    {
                        

                        var ioType = channel.GetAttribute("IoType")?.ToString(); 
                        if (ioType == "Output")  //scrivo parametri canale di uscita solo se il modulo è safe uscite
                        {
                            channel.SetAttribute("Failsafe_ActivatedLightTest", channelConfig.FailsafeActivatedLightTest);
                            channel.SetAttribute("Failsafe_DiagnosisWireBreak", channelConfig.FailsafeDiagnosisWireBreak);
                        }
                        else if (ioType == "Input") //scrivo parametri canale di ingresso solo se il modulo è safe ingressi
                        {
                            channel.SetAttribute("Failsafe_SensorEvaluation", channelConfig.FailsafeSensorEvaluation);
                            channel.SetAttribute("Failsafe_SensorSupply", channelConfig.FailsafeSensorSupply);
                           
                        }
                        
                    }
                    channel.SetAttribute("Failsafe_Activated", channelConfig.FailsafeActivated);

                    _traceWriter.Write("Channel " + channelConfig.ChannelNumber + " su " + moduleDeviceItem.Name +
                        ": Failsafe_SensorEvaluation=" + channelConfig.FailsafeSensorEvaluation +
                        ", Failsafe_SensorSupply=" + channelConfig.FailsafeSensorSupply);
                }
                catch (Exception exception)
                {
                    _traceWriter.Write("Errore impostando Safety su channel " + channelConfig.ChannelNumber + " di " + moduleDeviceItem.Name + ": " + exception.Message, "Probabilmente modulo Safety S71200");
                }
            }
        }

        /// <summary>
        /// Imposta l'indirizzo di start su un DeviceItem appena innestato.
        /// NOTA: nomi di attributo/enum (StartAddress, IoType) da verificare con IntelliSense
        /// o TIA Openness Explorer sul proprio ambiente V21 prima di considerarli definitivi.
        /// </summary>
        private void SetModuleAddresses(DeviceItem deviceItem, int? inputStartAddress, int? outputStartAddress)
{
    if (!inputStartAddress.HasValue && !outputStartAddress.HasValue) return;

    // Per i moduli Safety, l'indirizzo delle Q può risultare non scrivibile via Openness:
    // in quel caso l'unico modo per fissare l'indirizzo dell'uscita è impostare quello dell'Input corrispondente.
    var outputAddressSetSuccessfully = false;
    Siemens.Engineering.HW.Address inputAddressFallback = null;

    foreach (var (owner, address) in GetAllAddressesWithOwner(deviceItem))
    {
        var ioType = address.GetAttribute("IoType")?.ToString();

        if (ioType == "Input")
        {
            inputAddressFallback = address; // tengo traccia dell'ultimo Input trovato, come possibile fallback

            if (inputStartAddress.HasValue)
            {
                try
                {
                    address.SetAttribute("StartAddress", inputStartAddress.Value);
                    _traceWriter.Write("Input start address set to " + inputStartAddress.Value + " on " + deviceItem.Name);
                }
                catch (Exception exception)
                {
                    _traceWriter.Write("Unable to set input address on " + deviceItem.Name + ": " + exception.Message);
                }
            }
        }
        else if (ioType == "Output" && outputStartAddress.HasValue)
        {
            try
            {
                address.SetAttribute("StartAddress", outputStartAddress.Value);
                _traceWriter.Write("Output start address set to " + outputStartAddress.Value + " on " + deviceItem.Name);
                outputAddressSetSuccessfully = true;
            }
            catch (Exception exception)
            {
                _traceWriter.Write("Output non scrivibile su " + deviceItem.Name + " (" + exception.Message + "), provo a impostare l'Input corrispondente (probabile modulo Safety).");
            }
        }
    }

    // Fallback: la scrittura sull'Output è fallita ma l'Excel definisce Q per questo modulo -> imposto l'Input al posto della Q
    if (outputStartAddress.HasValue && !outputAddressSetSuccessfully && inputAddressFallback != null)
    {
        try
        {
            inputAddressFallback.SetAttribute("StartAddress", outputStartAddress.Value);
            _traceWriter.Write("Modulo Safety: Output " + outputStartAddress.Value + " impostato via Input su " + deviceItem.Name);
        }
        catch (Exception exception)
        {
            _traceWriter.Write("Impossibile impostare l'indirizzo (né Output né Input fallback) su " + deviceItem.Name + ": " + exception.Message);
        }
    }
}


        /// <summary>
        /// Imposta il Potential Group relativamente al modulo appena aggiunto
        /// il dato viene prelevato da schema su colonna J (per il momento compilata a mano)
        /// </summary>
        private void SetModulePotentialGroup(System.UInt64 potential,int index)
        {

            try
            {
                Device.DeviceItems[index].SetAttribute("PotentialGroup", potential);
            }
            catch (Exception e)
            {
                _traceWriter.Write("SetModulePotentialGroup" + e.Message);

            }
        }

        /// <summary>
        /// Cerca ricorsivamente tutti gli oggetti Address di un DeviceItem e dei suoi DeviceItems figli,
        /// perché in alcuni moduli gli indirizzi non sono sul DeviceItem di primo livello ma su un figlio annidato.
        /// </summary>
        private static IEnumerable<(DeviceItem Owner, Siemens.Engineering.HW.Address Address)> GetAllAddressesWithOwner(DeviceItem deviceItem)
        {
            foreach (var address in deviceItem.Addresses)
            {

                yield return (deviceItem, address);
            }

            foreach (var childItem in deviceItem.DeviceItems)
            {
                foreach (var result in GetAllAddressesWithOwner(childItem))
                {
                    yield return result;
                }
            }
        }

        /// <summary>
        /// METODO APPOGGIO PER IL RICHIAMO DI SetAttribute con gestione eccezione
        /// </summary>
        /// <summary>
        /// Metodo di appoggio per il richiamo di SetAttribute con gestione eccezione.
        /// Imposta più attributi (nome -> valore) sullo stesso DeviceItem, loggando eventuali errori
        /// (es. attributo inesistente o non scrivibile) senza interrompere gli altri.
        /// Per ora limitato al DeviceItem passato: non scende nei figli.
        /// </summary>
        private void SetDeviceAttributes(DeviceItem deviceItem, Dictionary<string, object> attributeList)
        {
            if (deviceItem == null || attributeList == null || attributeList.Count == 0)
            {
                return;
            }

            //var attributeInfos = deviceItem.GetAttributeInfos(); spostato sotto

            foreach (var kvp in attributeList)
            {
                try
                {
                    // Richiesto ad ogni iterazione (non prima del ciclo): un attributo impostato
                    // nel giro precedente (es. ClockMemoryByte=True) può far comparire nuovi attributi
                    // "condizionati" (es. ClockMemoryByteAddress) che prima non c'erano.
                    var attributeInfos = deviceItem.GetAttributeInfos(); 

                    var attributeInfo = attributeInfos.FirstOrDefault(a => a.Name == kvp.Key);

                    if (attributeInfo == null)
                    {
                        _traceWriter.Write("Attributo '" + kvp.Key + "' non trovato su " + deviceItem.Name);
                        continue;
                    }

                    var targetType = attributeInfo.SupportedTypes.FirstOrDefault();

                    if (targetType == null)
                    {
                        _traceWriter.Write("Attributo '" + kvp.Key + "' non ha SupportedTypes definiti, provo a impostarlo senza conversione.");
                        deviceItem.SetAttribute(kvp.Key, kvp.Value);
                        continue;
                    }

                    var convertedValue = ConvertToAttributeType(kvp.Value, targetType);

                    deviceItem.SetAttribute(kvp.Key, convertedValue);
                    _traceWriter.Write(kvp.Key + " impostato a " + convertedValue + " (" + targetType.Name + ") su " + deviceItem.Name);
                }
                catch (Exception exception)
                {
                    _traceWriter.Write("Errore impostando '" + kvp.Key + "' su " + deviceItem.Name + ": " + exception.Message);
                }
            }
        }

        private static object ConvertToAttributeType(object rawValue, Type targetType)
        {
            if (rawValue == null)
            {
                return null;
            }

            if (targetType.IsEnum)
            {
                if (rawValue is string stringValue)
                {
                    return Enum.Parse(targetType, stringValue, ignoreCase: true);
                }
                return Enum.ToObject(targetType, rawValue);
            }

            return Convert.ChangeType(rawValue, targetType);
        }


#endregion // Device


#region Debug

/// <summary>
/// METODO DI DEBUG: stampa tutti gli attributi disponibili su un DeviceItem,
/// utile per scoprire il nome esatto di un parametro senza aprire TIA Openness Explorer.
/// </summary>
private void DumpAllAttributes(DeviceItem deviceItem, string filter = null)
{
   // _traceWriter.Write("--- Attributi di " + deviceItem.Name + " ---");
    Debug.WriteLine("DumpAllAttributes: " + "--- Attributi di " + deviceItem.Name + " ---");

    foreach (var attributeInfo in deviceItem.GetAttributeInfos())
    {
        if (filter == null || attributeInfo.Name.ToLowerInvariant().Contains(filter.ToLowerInvariant()))
        {
            var supportedTypes = string.Join(", ", attributeInfo.SupportedTypes.Select(t => t.Name));


            try
            {

                var value = deviceItem.GetAttribute(attributeInfo.Name);
                Debug.WriteLine("DumpAllAttributes: " + attributeInfo.Name + " = " + value + "  [SupportedTypes: " + supportedTypes + "]");
                //_traceWriter.Write(attributeInfo.Name + " = " + value + "  [Type: " + attributeInfo.Type + "]");
            }
            catch
            {
                Debug.WriteLine("DumpAllAttributes: " + attributeInfo.Name + " = (non leggibile)  [SupportedTypes: " + supportedTypes + "]");
                //_traceWriter.Write(attributeInfo.Name + " = (non leggibile)  [Type: " + attributeInfo.Type + "]");
            }
        }
    }
}

        /// <summary>
        /// METODO TEMPORANEO DI DEBUG: stampa l'albero di cartelle e Master Copy della libreria aperta,
        /// per verificare nomi reali prima di scrivere codice di piazzamento.
        /// </summary>
        public void DumpLibraryStructure()
        {
            if (CurrentUserGLobalLibrary == null)
            {
                Debug.WriteLine("Nessuna libreria aperta.");
                _traceWriter.Write("Nessuna libreria aperta.");
                return;
            }

            Debug.WriteLine("--- Struttura libreria: " + CurrentUserGLobalLibrary.Name + " ---");
            _traceWriter.Write("--- Struttura libreria: " + CurrentUserGLobalLibrary.Name + " ---");
            DumpMasterCopyFolderRecursive(CurrentUserGLobalLibrary.MasterCopyFolder, "");
        }

        private void DumpMasterCopyFolderRecursive(MasterCopyFolder folder, string indent)
        {
            foreach (var masterCopy in folder.MasterCopies)
            {
                Debug.WriteLine(indent + "[MasterCopy] " + masterCopy.Name);
                _traceWriter.Write(indent + "[MasterCopy] " + masterCopy.Name);
            }

            foreach (var subFolder in folder.Folders)
            {
               Debug.WriteLine(indent + "[Folder] " + subFolder.Name);
                _traceWriter.Write(indent + "[Folder] " + subFolder.Name);
                DumpMasterCopyFolderRecursive(subFolder, indent + "  ");
            }
        }


        /// <summary>
        /// BOZZA NON VERIFICATA. Copia una Master Copy dalla libreria globale aperta alla libreria di progetto,
        /// poi ne piazza un'istanza nella DeviceItemComposition indicata (es. le porte del master IO-Link).
        /// </summary>
        private bool PlaceFromLibrary(string masterCopyName, DeviceItem targetContainer, string instanceName)
        {
            try
            {
                var sourceMasterCopy = FindMasterCopyRecursive(CurrentUserGLobalLibrary.MasterCopyFolder, masterCopyName);
                if (sourceMasterCopy == null)
                {
                    _traceWriter.Write("Master Copy '" + masterCopyName + "' non trovata nella libreria globale.");
                    return false;
                }

                var projectLibrary = CurrentProject.ProjectLibrary; // <-- da verificare
                var projectMasterCopy = projectLibrary.MasterCopyFolder.MasterCopies.CreateFrom(sourceMasterCopy); // <-- da verificare

                var newItem = targetContainer.DeviceItems.CreateFrom(projectMasterCopy); // <-- il punto più incerto
                if (newItem != null)
                {
                    newItem.Name = instanceName;
                    IsModified = true;
                    _traceWriter.Write("Piazzato '" + masterCopyName + "' come '" + instanceName + "' su " + targetContainer.Name);
                    return true;
                }
            }
            catch (Exception exception)
            {
                _traceWriter.Write("Errore piazzando '" + masterCopyName + "' da libreria: " + exception.Message);
            }

            return false;
        }

        private MasterCopy FindMasterCopyRecursive(MasterCopyFolder folder, string name)
        {
            foreach (var masterCopy in folder.MasterCopies)
            {
                if (masterCopy.Name == name) return masterCopy;
            }

            foreach (var subFolder in folder.Folders)
            {
                var found = FindMasterCopyRecursive(subFolder, name);
                if (found != null) return found;
            }

            return null;
        }

        #endregion

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
