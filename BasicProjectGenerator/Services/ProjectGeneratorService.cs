using Basic_Project_Generator.Interfaces;
using Basic_Project_Generator.Models;
using Basic_Project_Generator.Models.Configuration;
using Basic_Project_Generator.UserInterfaces;
//using Siemens.Engineering.HW;
using Siemens.Engineering.Library;
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

        private readonly SymbolicTableImportService _symbolicTableImportService;
        #endregion // fields

        #region ctor

        public ProjectGeneratorService(TraceWriter traceWriter, ApiWrapper apiWrapper)
        {
            _traceWriter = traceWriter;
            _apiWrapper = apiWrapper;
            _symbolicTableImportService = new SymbolicTableImportService(_traceWriter);

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

        public string SelectedLibrary
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

        public ModuleModel ModuleModel 
        { get; set; } = new ModuleModel();

        public XDocument ModuleCatalogXml
        { get; set; }

        public bool ModuleCatalogLoaded
        { get; set; }

        public Module NewModule
        { get; set; }

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
        /// Open a file dialog and retrieve all *.ap* files to select a project file
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        private bool SelectLibrary([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;
            SelectedLibrary = string.Empty;
            var fileSearch = new OpenFileDialog
            {
                Filter = "TIA Portal V21 Library|*.al21",
                RestoreDirectory = true
            };
            if (DialogResult.OK == fileSearch.ShowDialog())
            {
                SelectedLibrary = fileSearch.FileName;
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


        /// <summary>
        /// Open User Global Library 
        /// </summary>
        /// <param name="caller"></param>
        public bool OpenLibrary([CallerMemberName] string caller = "")
        {

            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = false;
            if (SelectLibrary())
            {
                if (_apiWrapper.DoOpenLibrary(SelectedLibrary))
                {
                    result = true;
                }
            }
            return result;

           

        }

        /// <summary>
        /// Close a project
        /// </summary>
        /// <param name="caller"></param>

        #endregion // TIA Portal Project

        /// <summary>
        ///implementato 31/08/2026
        ///per ora creato tutto dentro apiwrapper.cs nella parte di addnewdevice,
        ///ma in futuro si potrebbe creare un metodo separato per creare la subnet e l'io system,
        ///in modo da poterlo richiamare anche in altri contesti
        /// </summary>
        #region Subnet and IoSystem

        /// <summary>
        /// Add a new subnet to project
        /// </summary>
        /// <param name="caller"></param>
        public void AddNewSubnetAndConnectToPlc(Models.DeviceItem plcDeviceItem,String subnetName= "System:Subnet.Ethernet", String subnetDescription= "PN/IE_1", [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            if(string.IsNullOrEmpty(subnetName))
            {
                _traceWriter.Write("Subnet name is empty. Cannot create subnet.");
                return;
            }
            if(string.IsNullOrEmpty(subnetDescription))
            {
                _traceWriter.Write("Subnet description is empty. Cannot create subnet.");
                return;
            }
            

            _apiWrapper.DoCreateSubnetAndConnectToPlc(subnetName, subnetDescription, plcDeviceItem,caller);
        }

        /// <summary>
        /// Add a new IoSystem to project
        /// </summary>
        /// <param name="caller"></param>
        public void AddNewIoSystem(String ioSystemName, Models.DeviceItem plcDeviceItem, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            if (string.IsNullOrEmpty(ioSystemName))
            {
                _traceWriter.Write("ioSystemName name is empty. Cannot create ioSystemName.");
                return;
            }
            if (string.IsNullOrEmpty(ioSystemName))
            {
                _traceWriter.Write("ioSystemName description is empty. Cannot create ioSystemName.");
                return;
            }


            _apiWrapper.DoFindPlcAndCreateIOSystem(ioSystemName, plcDeviceItem);
        }




        #endregion

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
        public void AddNewDevice(DeviceConfiguration config, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            _apiWrapper.DoAddNewDevice(config);
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


        public bool LoadModuleCatalog([CallerMemberName] string caller = "")
        {
            ModuleCatalogLoaded = false;
            ModuleCatalogXml = XDocument.Load("Assets\\ModuleCatalog.xml");
            ModuleModel.LoadModuleCatalog(ModuleCatalogXml);
            ModuleCatalogLoaded = true;
            return ModuleCatalogLoaded;
        }

        public List<IOLinkMasterModule> LoadIOLinkMasterCatalog([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = new List<IOLinkMasterModule>();
            var doc = XDocument.Load("Assets\\IOLink_StartupSettings.xml");

            foreach (var element in doc.Root.Elements("IOLinkMasterModule"))
            {
                result.Add(new IOLinkMasterModule
                {
                    MasterCopyName = element.Element("Code")?.Value,
                    Code = element.Element("MasterCopyName")?.Value,
                    BaseInputStartAddress = int.Parse(element.Element("BaseInputStartAddress")?.Value ?? "0"),
                    BaseOutputStartAddress = int.Parse(element.Element("BaseOutputStartAddress")?.Value ?? "0"),
                    AddressStep = int.Parse(element.Element("AddressStep")?.Value ?? "0"),
                    BaseIpLastOctet = int.Parse(element.Element("BaseIpLastOctet")?.Value ?? "0"),
                    BaseDeviceNumber = int.Parse(element.Element("BaseDeviceNumber")?.Value ?? "0"),
                    IpDeviceStep = int.Parse(element.Element("IpDeviceStep")?.Value ?? "0")
                });
            }

            return result;
        }

        public List<IOLinkSlaveModule> LoadIOLinkSlaveCatalog([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var result = new List<IOLinkSlaveModule>();
            var doc = XDocument.Load("Assets\\IOLink_StartupSettings.xml");

            foreach (var element in doc.Root.Elements("IOLinkExpModule").Concat(doc.Root.Elements("IOLinkSensorModule")))
            {
                result.Add(new IOLinkSlaveModule
                {
                    MasterCopyName = element.Element("Code")?.Value,
                    Code = element.Element("MasterCopyName")?.Value
                });
            }

            return result;
        }


        public (int MasterAddedCount, int TotalSlaveAddedCount) AddIOLinkMastersFromImport(List<ImportedSymbolItem> importedItems, Models.DeviceItem plcDeviceItem, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var masterAddedCount = 0;
            var totalSlaveAddedCount = 0;
            var masterCatalog = LoadIOLinkMasterCatalog();
            var occurrenceCounters = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var item in importedItems.Where(i => i.IsIOLinkMaster)) //questo filtra tutti moduli selezionati che non siano master io link
            {
                var template = masterCatalog.FirstOrDefault(m => string.Equals(m.MasterCopyName, item.IOLinkMasterCode, StringComparison.OrdinalIgnoreCase));
                if (template == null)
                {
                    _traceWriter.Write("Nessuna voce di catalogo trovata per master IO-Link '" + item.IOLinkMasterCode + "'.");
                    continue;
                }

                var occurrenceIndex = occurrenceCounters.TryGetValue(template.MasterCopyName, out var count) ? count : 0;
                occurrenceCounters[template.MasterCopyName] = occurrenceIndex + 1;

                var runtimeConfig = new IOLinkMasterModule
                {
                    MasterCopyName = template.MasterCopyName,
                    Code = item.Name, // sigla, es. "321A1"
                    BaseInputStartAddress = template.BaseInputStartAddress,
                    BaseOutputStartAddress = template.BaseOutputStartAddress,
                    AddressStep = template.AddressStep,
                    BaseIpLastOctet = template.BaseIpLastOctet,
                    BaseDeviceNumber = template.BaseDeviceNumber,
                    IpDeviceStep = template.IpDeviceStep
                };

                foreach (var port in item.IOLinkPorts)
                {
                    runtimeConfig.AddSlave(new IOLinkSlaveModule
                    {
                        MasterCopyName = port.Code,        // chiave libreria, es. "AL2401"/"TP3232"
                        Code = port.InstanceName,          // nome istanza composto
                        PortNumber = port.PortNumber
                    });
                }

                var(isAdded, slaveCount) = _apiWrapper.DoAddIOLinkMasterFromPlc(runtimeConfig, occurrenceIndex, plcDeviceItem, caller);

                if (isAdded)
                {
                    masterAddedCount ++;
                    totalSlaveAddedCount += slaveCount;
                }
            }//fine for master

            return (masterAddedCount, totalSlaveAddedCount);
            
        }



        public bool AddNewModule(ModuleConfiguration config, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            return _apiWrapper.DoAddNewModule(config);
        }

        public (Dictionary<string, object> dictAttribute, Dictionary<string, object> dictIpAddress) LoadPlcStartupSettings([CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            var attributeDict = new Dictionary<string, object>();
            var ipAddressDict = new Dictionary<string, object>();

            var doc = XDocument.Load("Assets\\PlcStartupSettings.xml");

            //ricerca di tutti gli attributi del PLC e dei valori associati, se sono numeri o booleani li converte in int o bool
            foreach (var element in doc.Root.Elements("Attribute"))
            {
                var name = element.Element("Name")?.Value;
                var rawValue = element.Element("Value")?.Value;

                if (string.IsNullOrWhiteSpace(name) || rawValue == null) continue;

                if (int.TryParse(rawValue, out var intValue))
                {
                    attributeDict[name] = intValue;
                }
                else if (bool.TryParse(rawValue, out var boolValue))
                {
                    attributeDict[name] = boolValue;
                }
                else
                {
                    attributeDict[name] = rawValue;
                }
            }

            // Parsing degli IpAddresses
            // Si accede al nodo <IpAddresses> e poi a tutti gli elementi <IpAddress> contenuti
            var ipElements = doc.Root.Element("IpAddresses")?.Elements("IpAddress");

            if (ipElements != null)
            {
                foreach (var ipElement in ipElements)
                {
                    var interfaceName = ipElement.Element("Name")?.Value;

                    var octet1 = ipElement.Element("Firstoctet")?.Value;
                    var octet2 = ipElement.Element("Secondoctet")?.Value;
                    var octet3 = ipElement.Element("Thirdoctet")?.Value;
                    var octet4 = ipElement.Element("Fourthoctet")?.Value;

                    // Salta se manca il nome dell'interfaccia o uno degli ottetti
                    if (string.IsNullOrWhiteSpace(interfaceName) ||
                        octet1 == null || octet2 == null || octet3 == null || octet4 == null)
                    {
                        continue;
                    }

                    // Unisce gli ottetti formattando la stringa "X.X.X.X"
                    var ipString = $"{octet1}.{octet2}.{octet3}.{octet4}";

                    ipAddressDict[interfaceName] = ipString;
                }
            }


            return (attributeDict,ipAddressDict);
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

        #region TableImport
  
        public List<ImportedSymbolItem> ImportSymbolicTable(string filePath, [CallerMemberName] string caller = "")
        {
            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);

            LoadDeviceCatalog();
            LoadModuleCatalog();

            var ioLinkMasterCatalog = LoadIOLinkMasterCatalog();
            return _symbolicTableImportService.Import(filePath, DeviceModel.DeviceCatalog, ModuleModel.ModuleCatalog, ioLinkMasterCatalog);
        }
        #endregion

        #region Debug

        public bool DebugTest(Models.DeviceItem deviceItem, [CallerMemberName] string caller = "")
        {

            var methodBase = MethodBase.GetCurrentMethod();
            if (methodBase.ReflectedType != null) _traceWriter.Write(methodBase.ReflectedType.Name + "." + methodBase.Name + " called from " + caller);
           
            var result = false;
            
                if (_apiWrapper.DoTestDebug(deviceItem, caller))
                {
                    result = true;
                }
            
            return result;

        }


        
        #endregion


        #endregion // methods
    }
}
