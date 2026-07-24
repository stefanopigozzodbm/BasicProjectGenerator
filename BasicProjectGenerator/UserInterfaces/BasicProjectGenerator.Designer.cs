
namespace Basic_Project_Generator.UserInterfaces
{
    partial class BasicProjectGenerator
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
            this.components = new System.ComponentModel.Container();
            this.grb_TiaPortal = new System.Windows.Forms.GroupBox();
            this.txb_CurrentProcessId = new System.Windows.Forms.TextBox();
            this.lbl_CurrentProcessId = new System.Windows.Forms.Label();
            this.lbl_Processes = new System.Windows.Forms.Label();
            this.btn_ConnectTiaPortal = new System.Windows.Forms.Button();
            this.cob_ProcessIds = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CloseTiaPortal = new System.Windows.Forms.Button();
            this.btn_OpenTiaPortal = new System.Windows.Forms.Button();
            this.rdb_WithoutUI = new System.Windows.Forms.RadioButton();
            this.rdb_WithUI = new System.Windows.Forms.RadioButton();
            this.grb_TiaPortalProject = new System.Windows.Forms.GroupBox();
            this.btn_LoadProject = new System.Windows.Forms.Button();
            this.btn_CreateNewProject = new System.Windows.Forms.Button();
            this.txb_TargetDirectory = new System.Windows.Forms.TextBox();
            this.lbl_TargetDirectory = new System.Windows.Forms.Label();
            this.txb_CurrentProjectName = new System.Windows.Forms.TextBox();
            this.lbl_CurrentProjectName = new System.Windows.Forms.Label();
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.txb_AvailableProjectName = new System.Windows.Forms.TextBox();
            this.btn_CloseProject = new System.Windows.Forms.Button();
            this.btn_SaveProject = new System.Windows.Forms.Button();
            this.btn_OpenProject = new System.Windows.Forms.Button();
            this.grb_AddNewDevice = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_PlcIpAddress = new System.Windows.Forms.TextBox();
            this.txb_Station = new System.Windows.Forms.TextBox();
            this.lab_Station = new System.Windows.Forms.Label();
            this.ckb_IncludeFailsafe = new System.Windows.Forms.CheckBox();
            this.lab_TypeIdentifier = new System.Windows.Forms.Label();
            this.txb_TypeIdentifier = new System.Windows.Forms.TextBox();
            this.txb_DeviceName = new System.Windows.Forms.TextBox();
            this.lbl_DeviceName = new System.Windows.Forms.Label();
            this.btn_AddNewDevice = new System.Windows.Forms.Button();
            this.txb_Version = new System.Windows.Forms.TextBox();
            this.txb_OrderNr = new System.Windows.Forms.TextBox();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.cob_DeviceTemplates = new System.Windows.Forms.ComboBox();
            this.lbl_DeviceTemplates = new System.Windows.Forms.Label();
            this.grb_Compile = new System.Windows.Forms.GroupBox();
            this.lab_DeviceToCompile = new System.Windows.Forms.Label();
            this.btn_CompileDevice = new System.Windows.Forms.Button();
            this.cob_DeviceList = new System.Windows.Forms.ComboBox();
            this.lib_DeviceList = new System.Windows.Forms.ListBox();
            this.lab_DeviceList = new System.Windows.Forms.Label();
            this.lib_TraceWriterOutput = new System.Windows.Forms.ListBox();
            this.GeneratorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grb_AddModule = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_ModuleName = new System.Windows.Forms.TextBox();
            this.btn_AddModule = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cob_ModuleTemplates = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ImportSymbolicTable = new System.Windows.Forms.Button();
            this.clb_ImportedItems = new System.Windows.Forms.CheckedListBox();
            this.btn_AddImportedModules = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.HW_Siemens = new System.Windows.Forms.TabPage();
            this.HW_Other = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.Tag = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.grb_TiaPortal.SuspendLayout();
            this.grb_TiaPortalProject.SuspendLayout();
            this.grb_AddNewDevice.SuspendLayout();
            this.grb_Compile.SuspendLayout();
            this.grb_AddModule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.HW_Siemens.SuspendLayout();
            this.HW_Other.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_TiaPortal
            // 
            this.grb_TiaPortal.Controls.Add(this.txb_CurrentProcessId);
            this.grb_TiaPortal.Controls.Add(this.lbl_CurrentProcessId);
            this.grb_TiaPortal.Controls.Add(this.lbl_Processes);
            this.grb_TiaPortal.Controls.Add(this.btn_ConnectTiaPortal);
            this.grb_TiaPortal.Controls.Add(this.cob_ProcessIds);
            this.grb_TiaPortal.Controls.Add(this.label1);
            this.grb_TiaPortal.Controls.Add(this.btn_CloseTiaPortal);
            this.grb_TiaPortal.Controls.Add(this.btn_OpenTiaPortal);
            this.grb_TiaPortal.Controls.Add(this.rdb_WithoutUI);
            this.grb_TiaPortal.Controls.Add(this.rdb_WithUI);
            this.grb_TiaPortal.Location = new System.Drawing.Point(6, 6);
            this.grb_TiaPortal.Name = "grb_TiaPortal";
            this.grb_TiaPortal.Size = new System.Drawing.Size(211, 395);
            this.grb_TiaPortal.TabIndex = 0;
            this.grb_TiaPortal.TabStop = false;
            this.grb_TiaPortal.Text = "TIA Portal";
            // 
            // txb_CurrentProcessId
            // 
            this.txb_CurrentProcessId.Location = new System.Drawing.Point(18, 130);
            this.txb_CurrentProcessId.Name = "txb_CurrentProcessId";
            this.txb_CurrentProcessId.ReadOnly = true;
            this.txb_CurrentProcessId.Size = new System.Drawing.Size(173, 20);
            this.txb_CurrentProcessId.TabIndex = 4;
            this.txb_CurrentProcessId.MouseHover += new System.EventHandler(this.txb_CurrentProcessId_MouseHover);
            // 
            // lbl_CurrentProcessId
            // 
            this.lbl_CurrentProcessId.AutoSize = true;
            this.lbl_CurrentProcessId.Location = new System.Drawing.Point(18, 115);
            this.lbl_CurrentProcessId.Name = "lbl_CurrentProcessId";
            this.lbl_CurrentProcessId.Size = new System.Drawing.Size(59, 13);
            this.lbl_CurrentProcessId.TabIndex = 3;
            this.lbl_CurrentProcessId.Text = "Process ID";
            // 
            // lbl_Processes
            // 
            this.lbl_Processes.AutoSize = true;
            this.lbl_Processes.Location = new System.Drawing.Point(18, 202);
            this.lbl_Processes.Name = "lbl_Processes";
            this.lbl_Processes.Size = new System.Drawing.Size(56, 13);
            this.lbl_Processes.TabIndex = 6;
            this.lbl_Processes.Text = "Processes";
            // 
            // btn_ConnectTiaPortal
            // 
            this.btn_ConnectTiaPortal.Location = new System.Drawing.Point(18, 256);
            this.btn_ConnectTiaPortal.Name = "btn_ConnectTiaPortal";
            this.btn_ConnectTiaPortal.Size = new System.Drawing.Size(173, 33);
            this.btn_ConnectTiaPortal.TabIndex = 8;
            this.btn_ConnectTiaPortal.Text = "Connect TIA Portal";
            this.btn_ConnectTiaPortal.UseVisualStyleBackColor = true;
            this.btn_ConnectTiaPortal.Click += new System.EventHandler(this.btn_ConnectTiaPortal_Click);
            // 
            // cob_ProcessIds
            // 
            this.cob_ProcessIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_ProcessIds.FormattingEnabled = true;
            this.cob_ProcessIds.Location = new System.Drawing.Point(18, 217);
            this.cob_ProcessIds.Name = "cob_ProcessIds";
            this.cob_ProcessIds.Size = new System.Drawing.Size(173, 21);
            this.cob_ProcessIds.TabIndex = 7;
            this.cob_ProcessIds.SelectedIndexChanged += new System.EventHandler(this.Cob_ProcessIds_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // btn_CloseTiaPortal
            // 
            this.btn_CloseTiaPortal.Location = new System.Drawing.Point(21, 350);
            this.btn_CloseTiaPortal.Name = "btn_CloseTiaPortal";
            this.btn_CloseTiaPortal.Size = new System.Drawing.Size(170, 33);
            this.btn_CloseTiaPortal.TabIndex = 9;
            this.btn_CloseTiaPortal.Text = "Close TIA Portal";
            this.btn_CloseTiaPortal.UseVisualStyleBackColor = true;
            this.btn_CloseTiaPortal.Click += new System.EventHandler(this.btn_CloseTiaPortal_Click);
            // 
            // btn_OpenTiaPortal
            // 
            this.btn_OpenTiaPortal.Location = new System.Drawing.Point(18, 71);
            this.btn_OpenTiaPortal.Name = "btn_OpenTiaPortal";
            this.btn_OpenTiaPortal.Size = new System.Drawing.Size(173, 33);
            this.btn_OpenTiaPortal.TabIndex = 2;
            this.btn_OpenTiaPortal.Text = "Open TIA Portal";
            this.btn_OpenTiaPortal.UseVisualStyleBackColor = true;
            this.btn_OpenTiaPortal.Click += new System.EventHandler(this.btn_OpenTiaPortal_Click);
            // 
            // rdb_WithoutUI
            // 
            this.rdb_WithoutUI.AutoSize = true;
            this.rdb_WithoutUI.Location = new System.Drawing.Point(18, 48);
            this.rdb_WithoutUI.Name = "rdb_WithoutUI";
            this.rdb_WithoutUI.Size = new System.Drawing.Size(129, 17);
            this.rdb_WithoutUI.TabIndex = 1;
            this.rdb_WithoutUI.Text = "Without user interface";
            this.rdb_WithoutUI.UseVisualStyleBackColor = true;
            // 
            // rdb_WithUI
            // 
            this.rdb_WithUI.AutoSize = true;
            this.rdb_WithUI.Checked = true;
            this.rdb_WithUI.Location = new System.Drawing.Point(18, 25);
            this.rdb_WithUI.Name = "rdb_WithUI";
            this.rdb_WithUI.Size = new System.Drawing.Size(114, 17);
            this.rdb_WithUI.TabIndex = 0;
            this.rdb_WithUI.TabStop = true;
            this.rdb_WithUI.Text = "With user interface";
            this.rdb_WithUI.UseVisualStyleBackColor = true;
            // 
            // grb_TiaPortalProject
            // 
            this.grb_TiaPortalProject.Controls.Add(this.btn_LoadProject);
            this.grb_TiaPortalProject.Controls.Add(this.btn_CreateNewProject);
            this.grb_TiaPortalProject.Controls.Add(this.txb_TargetDirectory);
            this.grb_TiaPortalProject.Controls.Add(this.lbl_TargetDirectory);
            this.grb_TiaPortalProject.Controls.Add(this.txb_CurrentProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.lbl_CurrentProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.lbl_ProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.txb_AvailableProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.btn_CloseProject);
            this.grb_TiaPortalProject.Controls.Add(this.btn_SaveProject);
            this.grb_TiaPortalProject.Controls.Add(this.btn_OpenProject);
            this.grb_TiaPortalProject.Location = new System.Drawing.Point(221, 6);
            this.grb_TiaPortalProject.Name = "grb_TiaPortalProject";
            this.grb_TiaPortalProject.Size = new System.Drawing.Size(211, 395);
            this.grb_TiaPortalProject.TabIndex = 1;
            this.grb_TiaPortalProject.TabStop = false;
            this.grb_TiaPortalProject.Text = "TIA Portal project";
            // 
            // btn_LoadProject
            // 
            this.btn_LoadProject.Location = new System.Drawing.Point(18, 257);
            this.btn_LoadProject.Name = "btn_LoadProject";
            this.btn_LoadProject.Size = new System.Drawing.Size(173, 33);
            this.btn_LoadProject.TabIndex = 8;
            this.btn_LoadProject.Text = "Load project";
            this.btn_LoadProject.UseVisualStyleBackColor = true;
            this.btn_LoadProject.Click += new System.EventHandler(this.btn_LoadProject_Click);
            // 
            // btn_CreateNewProject
            // 
            this.btn_CreateNewProject.Location = new System.Drawing.Point(18, 32);
            this.btn_CreateNewProject.Name = "btn_CreateNewProject";
            this.btn_CreateNewProject.Size = new System.Drawing.Size(173, 33);
            this.btn_CreateNewProject.TabIndex = 0;
            this.btn_CreateNewProject.Text = "Create new project";
            this.btn_CreateNewProject.UseVisualStyleBackColor = true;
            this.btn_CreateNewProject.Click += new System.EventHandler(this.btn_CreateNewProject_Click);
            // 
            // txb_TargetDirectory
            // 
            this.txb_TargetDirectory.Location = new System.Drawing.Point(18, 170);
            this.txb_TargetDirectory.Name = "txb_TargetDirectory";
            this.txb_TargetDirectory.ReadOnly = true;
            this.txb_TargetDirectory.Size = new System.Drawing.Size(173, 20);
            this.txb_TargetDirectory.TabIndex = 5;
            this.txb_TargetDirectory.MouseHover += new System.EventHandler(this.txb_TargetDirectory_MouseHover);
            // 
            // lbl_TargetDirectory
            // 
            this.lbl_TargetDirectory.AutoSize = true;
            this.lbl_TargetDirectory.Location = new System.Drawing.Point(18, 155);
            this.lbl_TargetDirectory.Name = "lbl_TargetDirectory";
            this.lbl_TargetDirectory.Size = new System.Drawing.Size(81, 13);
            this.lbl_TargetDirectory.TabIndex = 4;
            this.lbl_TargetDirectory.Text = "Target directory";
            // 
            // txb_CurrentProjectName
            // 
            this.txb_CurrentProjectName.Location = new System.Drawing.Point(18, 130);
            this.txb_CurrentProjectName.Name = "txb_CurrentProjectName";
            this.txb_CurrentProjectName.ReadOnly = true;
            this.txb_CurrentProjectName.Size = new System.Drawing.Size(173, 20);
            this.txb_CurrentProjectName.TabIndex = 3;
            this.txb_CurrentProjectName.MouseHover += new System.EventHandler(this.txb_CurrentProjectName_MouseHover);
            // 
            // lbl_CurrentProjectName
            // 
            this.lbl_CurrentProjectName.AutoSize = true;
            this.lbl_CurrentProjectName.Location = new System.Drawing.Point(18, 115);
            this.lbl_CurrentProjectName.Name = "lbl_CurrentProjectName";
            this.lbl_CurrentProjectName.Size = new System.Drawing.Size(69, 13);
            this.lbl_CurrentProjectName.TabIndex = 2;
            this.lbl_CurrentProjectName.Text = "Project name";
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.AutoSize = true;
            this.lbl_ProjectName.Location = new System.Drawing.Point(18, 202);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(85, 13);
            this.lbl_ProjectName.TabIndex = 6;
            this.lbl_ProjectName.Text = "Available project";
            // 
            // txb_AvailableProjectName
            // 
            this.txb_AvailableProjectName.Location = new System.Drawing.Point(18, 217);
            this.txb_AvailableProjectName.Name = "txb_AvailableProjectName";
            this.txb_AvailableProjectName.ReadOnly = true;
            this.txb_AvailableProjectName.Size = new System.Drawing.Size(173, 20);
            this.txb_AvailableProjectName.TabIndex = 7;
            this.txb_AvailableProjectName.MouseHover += new System.EventHandler(this.txb_AvailableProjectName_MouseHover);
            // 
            // btn_CloseProject
            // 
            this.btn_CloseProject.Location = new System.Drawing.Point(18, 350);
            this.btn_CloseProject.Name = "btn_CloseProject";
            this.btn_CloseProject.Size = new System.Drawing.Size(173, 33);
            this.btn_CloseProject.TabIndex = 10;
            this.btn_CloseProject.Text = "Close project";
            this.btn_CloseProject.UseVisualStyleBackColor = true;
            this.btn_CloseProject.Click += new System.EventHandler(this.btn_CloseProject_Click);
            // 
            // btn_SaveProject
            // 
            this.btn_SaveProject.Location = new System.Drawing.Point(18, 311);
            this.btn_SaveProject.Name = "btn_SaveProject";
            this.btn_SaveProject.Size = new System.Drawing.Size(173, 33);
            this.btn_SaveProject.TabIndex = 9;
            this.btn_SaveProject.Text = "Save project";
            this.btn_SaveProject.UseVisualStyleBackColor = true;
            this.btn_SaveProject.Click += new System.EventHandler(this.btn_SaveProject_Click);
            // 
            // btn_OpenProject
            // 
            this.btn_OpenProject.Location = new System.Drawing.Point(18, 71);
            this.btn_OpenProject.Name = "btn_OpenProject";
            this.btn_OpenProject.Size = new System.Drawing.Size(173, 33);
            this.btn_OpenProject.TabIndex = 1;
            this.btn_OpenProject.Text = "Open project";
            this.btn_OpenProject.UseVisualStyleBackColor = true;
            this.btn_OpenProject.Click += new System.EventHandler(this.btn_OpenProject_Click);
            // 
            // grb_AddNewDevice
            // 
            this.grb_AddNewDevice.Controls.Add(this.label4);
            this.grb_AddNewDevice.Controls.Add(this.tb_PlcIpAddress);
            this.grb_AddNewDevice.Controls.Add(this.txb_Station);
            this.grb_AddNewDevice.Controls.Add(this.lab_Station);
            this.grb_AddNewDevice.Controls.Add(this.ckb_IncludeFailsafe);
            this.grb_AddNewDevice.Controls.Add(this.lab_TypeIdentifier);
            this.grb_AddNewDevice.Controls.Add(this.txb_TypeIdentifier);
            this.grb_AddNewDevice.Controls.Add(this.txb_DeviceName);
            this.grb_AddNewDevice.Controls.Add(this.lbl_DeviceName);
            this.grb_AddNewDevice.Controls.Add(this.btn_AddNewDevice);
            this.grb_AddNewDevice.Controls.Add(this.txb_Version);
            this.grb_AddNewDevice.Controls.Add(this.txb_OrderNr);
            this.grb_AddNewDevice.Controls.Add(this.lbl_Version);
            this.grb_AddNewDevice.Controls.Add(this.lbl_OrderNr);
            this.grb_AddNewDevice.Controls.Add(this.cob_DeviceTemplates);
            this.grb_AddNewDevice.Controls.Add(this.lbl_DeviceTemplates);
            this.grb_AddNewDevice.Location = new System.Drawing.Point(438, 6);
            this.grb_AddNewDevice.Name = "grb_AddNewDevice";
            this.grb_AddNewDevice.Size = new System.Drawing.Size(211, 395);
            this.grb_AddNewDevice.TabIndex = 2;
            this.grb_AddNewDevice.TabStop = false;
            this.grb_AddNewDevice.Text = "Add new device";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "IP Address";
            // 
            // tb_PlcIpAddress
            // 
            this.tb_PlcIpAddress.Location = new System.Drawing.Point(18, 316);
            this.tb_PlcIpAddress.Name = "tb_PlcIpAddress";
            this.tb_PlcIpAddress.Size = new System.Drawing.Size(173, 20);
            this.tb_PlcIpAddress.TabIndex = 14;
            this.tb_PlcIpAddress.Text = "10.0.0.1";
            // 
            // txb_Station
            // 
            this.txb_Station.Location = new System.Drawing.Point(18, 157);
            this.txb_Station.Name = "txb_Station";
            this.txb_Station.Size = new System.Drawing.Size(173, 20);
            this.txb_Station.TabIndex = 6;
            this.txb_Station.MouseHover += new System.EventHandler(this.txb_Station_MouseHover);
            // 
            // lab_Station
            // 
            this.lab_Station.AutoSize = true;
            this.lab_Station.Location = new System.Drawing.Point(18, 142);
            this.lab_Station.Name = "lab_Station";
            this.lab_Station.Size = new System.Drawing.Size(69, 13);
            this.lab_Station.TabIndex = 5;
            this.lab_Station.Text = "Station name";
            // 
            // ckb_IncludeFailsafe
            // 
            this.ckb_IncludeFailsafe.AutoSize = true;
            this.ckb_IncludeFailsafe.Location = new System.Drawing.Point(18, 74);
            this.ckb_IncludeFailsafe.Name = "ckb_IncludeFailsafe";
            this.ckb_IncludeFailsafe.Size = new System.Drawing.Size(100, 17);
            this.ckb_IncludeFailsafe.TabIndex = 2;
            this.ckb_IncludeFailsafe.Text = "Include Failsafe";
            this.ckb_IncludeFailsafe.UseVisualStyleBackColor = true;
            // 
            // lab_TypeIdentifier
            // 
            this.lab_TypeIdentifier.AutoSize = true;
            this.lab_TypeIdentifier.Location = new System.Drawing.Point(18, 262);
            this.lab_TypeIdentifier.Name = "lab_TypeIdentifier";
            this.lab_TypeIdentifier.Size = new System.Drawing.Size(73, 13);
            this.lab_TypeIdentifier.TabIndex = 11;
            this.lab_TypeIdentifier.Text = "Type identifier";
            // 
            // txb_TypeIdentifier
            // 
            this.txb_TypeIdentifier.Location = new System.Drawing.Point(18, 277);
            this.txb_TypeIdentifier.Name = "txb_TypeIdentifier";
            this.txb_TypeIdentifier.ReadOnly = true;
            this.txb_TypeIdentifier.Size = new System.Drawing.Size(173, 20);
            this.txb_TypeIdentifier.TabIndex = 12;
            this.txb_TypeIdentifier.MouseHover += new System.EventHandler(this.txb_TypeIdentifier_MouseHover);
            // 
            // txb_DeviceName
            // 
            this.txb_DeviceName.Location = new System.Drawing.Point(18, 117);
            this.txb_DeviceName.Name = "txb_DeviceName";
            this.txb_DeviceName.Size = new System.Drawing.Size(173, 20);
            this.txb_DeviceName.TabIndex = 4;
            this.txb_DeviceName.MouseHover += new System.EventHandler(this.txb_DeviceName_MouseHover);
            // 
            // lbl_DeviceName
            // 
            this.lbl_DeviceName.AutoSize = true;
            this.lbl_DeviceName.Location = new System.Drawing.Point(18, 102);
            this.lbl_DeviceName.Name = "lbl_DeviceName";
            this.lbl_DeviceName.Size = new System.Drawing.Size(70, 13);
            this.lbl_DeviceName.TabIndex = 3;
            this.lbl_DeviceName.Text = "Device name";
            // 
            // btn_AddNewDevice
            // 
            this.btn_AddNewDevice.BackColor = System.Drawing.Color.LightBlue;
            this.btn_AddNewDevice.Location = new System.Drawing.Point(21, 350);
            this.btn_AddNewDevice.Name = "btn_AddNewDevice";
            this.btn_AddNewDevice.Size = new System.Drawing.Size(173, 33);
            this.btn_AddNewDevice.TabIndex = 13;
            this.btn_AddNewDevice.Text = "Add new device";
            this.btn_AddNewDevice.UseVisualStyleBackColor = true;
            this.btn_AddNewDevice.Click += new System.EventHandler(this.btn_AddNewDevice_Click);
            // 
            // txb_Version
            // 
            this.txb_Version.Location = new System.Drawing.Point(18, 237);
            this.txb_Version.Name = "txb_Version";
            this.txb_Version.Size = new System.Drawing.Size(173, 20);
            this.txb_Version.TabIndex = 10;
            this.txb_Version.Leave += new System.EventHandler(this.txb_Version_Leave);
            this.txb_Version.MouseHover += new System.EventHandler(this.txb_Version_MouseHover);
            // 
            // txb_OrderNr
            // 
            this.txb_OrderNr.Location = new System.Drawing.Point(18, 197);
            this.txb_OrderNr.Name = "txb_OrderNr";
            this.txb_OrderNr.Size = new System.Drawing.Size(173, 20);
            this.txb_OrderNr.TabIndex = 8;
            this.txb_OrderNr.Leave += new System.EventHandler(this.txb_OrderNr_Leave);
            this.txb_OrderNr.MouseHover += new System.EventHandler(this.txb_OrderNr_MouseHover);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(18, 222);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(42, 13);
            this.lbl_Version.TabIndex = 9;
            this.lbl_Version.Text = "Version";
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.Location = new System.Drawing.Point(18, 182);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(71, 13);
            this.lbl_OrderNr.TabIndex = 7;
            this.lbl_OrderNr.Text = "Order number";
            // 
            // cob_DeviceTemplates
            // 
            this.cob_DeviceTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_DeviceTemplates.FormattingEnabled = true;
            this.cob_DeviceTemplates.Location = new System.Drawing.Point(18, 44);
            this.cob_DeviceTemplates.Name = "cob_DeviceTemplates";
            this.cob_DeviceTemplates.Size = new System.Drawing.Size(173, 21);
            this.cob_DeviceTemplates.TabIndex = 1;
            this.cob_DeviceTemplates.SelectedIndexChanged += new System.EventHandler(this.cob_DeviceTemplates_SelectedIndexChanged);
            // 
            // lbl_DeviceTemplates
            // 
            this.lbl_DeviceTemplates.AutoSize = true;
            this.lbl_DeviceTemplates.Location = new System.Drawing.Point(15, 27);
            this.lbl_DeviceTemplates.Name = "lbl_DeviceTemplates";
            this.lbl_DeviceTemplates.Size = new System.Drawing.Size(89, 13);
            this.lbl_DeviceTemplates.TabIndex = 0;
            this.lbl_DeviceTemplates.Text = "Device templates";
            // 
            // grb_Compile
            // 
            this.grb_Compile.Controls.Add(this.lab_DeviceToCompile);
            this.grb_Compile.Controls.Add(this.btn_CompileDevice);
            this.grb_Compile.Controls.Add(this.cob_DeviceList);
            this.grb_Compile.Controls.Add(this.lib_DeviceList);
            this.grb_Compile.Controls.Add(this.lab_DeviceList);
            this.grb_Compile.Location = new System.Drawing.Point(854, 6);
            this.grb_Compile.Name = "grb_Compile";
            this.grb_Compile.Size = new System.Drawing.Size(211, 384);
            this.grb_Compile.TabIndex = 3;
            this.grb_Compile.TabStop = false;
            this.grb_Compile.Text = "Compile";
            // 
            // lab_DeviceToCompile
            // 
            this.lab_DeviceToCompile.AutoSize = true;
            this.lab_DeviceToCompile.Location = new System.Drawing.Point(15, 235);
            this.lab_DeviceToCompile.Name = "lab_DeviceToCompile";
            this.lab_DeviceToCompile.Size = new System.Drawing.Size(92, 13);
            this.lab_DeviceToCompile.TabIndex = 2;
            this.lab_DeviceToCompile.Text = "Device to compile";
            // 
            // btn_CompileDevice
            // 
            this.btn_CompileDevice.Location = new System.Drawing.Point(18, 289);
            this.btn_CompileDevice.Name = "btn_CompileDevice";
            this.btn_CompileDevice.Size = new System.Drawing.Size(173, 33);
            this.btn_CompileDevice.TabIndex = 4;
            this.btn_CompileDevice.Text = "Compile device";
            this.btn_CompileDevice.UseVisualStyleBackColor = true;
            this.btn_CompileDevice.Click += new System.EventHandler(this.btn_CompileDevice_Click);
            // 
            // cob_DeviceList
            // 
            this.cob_DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_DeviceList.FormattingEnabled = true;
            this.cob_DeviceList.Location = new System.Drawing.Point(18, 250);
            this.cob_DeviceList.Name = "cob_DeviceList";
            this.cob_DeviceList.Size = new System.Drawing.Size(173, 21);
            this.cob_DeviceList.TabIndex = 3;
            // 
            // lib_DeviceList
            // 
            this.lib_DeviceList.FormattingEnabled = true;
            this.lib_DeviceList.HorizontalExtent = 200;
            this.lib_DeviceList.HorizontalScrollbar = true;
            this.lib_DeviceList.Location = new System.Drawing.Point(18, 43);
            this.lib_DeviceList.Name = "lib_DeviceList";
            this.lib_DeviceList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lib_DeviceList.Size = new System.Drawing.Size(173, 186);
            this.lib_DeviceList.TabIndex = 1;
            // 
            // lab_DeviceList
            // 
            this.lab_DeviceList.AutoSize = true;
            this.lab_DeviceList.Location = new System.Drawing.Point(15, 27);
            this.lab_DeviceList.Name = "lab_DeviceList";
            this.lab_DeviceList.Size = new System.Drawing.Size(56, 13);
            this.lab_DeviceList.TabIndex = 0;
            this.lab_DeviceList.Text = "Device list";
            // 
            // lib_TraceWriterOutput
            // 
            this.lib_TraceWriterOutput.FormattingEnabled = true;
            this.lib_TraceWriterOutput.HorizontalScrollbar = true;
            this.lib_TraceWriterOutput.Location = new System.Drawing.Point(12, 454);
            this.lib_TraceWriterOutput.Name = "lib_TraceWriterOutput";
            this.lib_TraceWriterOutput.Size = new System.Drawing.Size(1079, 251);
            this.lib_TraceWriterOutput.TabIndex = 4;
            // 
            // grb_AddModule
            // 
            this.grb_AddModule.Controls.Add(this.label3);
            this.grb_AddModule.Controls.Add(this.txb_ModuleName);
            this.grb_AddModule.Controls.Add(this.btn_AddModule);
            this.grb_AddModule.Controls.Add(this.label2);
            this.grb_AddModule.Controls.Add(this.cob_ModuleTemplates);
            this.grb_AddModule.Location = new System.Drawing.Point(655, 6);
            this.grb_AddModule.Name = "grb_AddModule";
            this.grb_AddModule.Size = new System.Drawing.Size(193, 168);
            this.grb_AddModule.TabIndex = 5;
            this.grb_AddModule.TabStop = false;
            this.grb_AddModule.Text = "Add PLC Module (Manual)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Module Name";
            // 
            // txb_ModuleName
            // 
            this.txb_ModuleName.Location = new System.Drawing.Point(6, 84);
            this.txb_ModuleName.Name = "txb_ModuleName";
            this.txb_ModuleName.Size = new System.Drawing.Size(181, 20);
            this.txb_ModuleName.TabIndex = 5;
            // 
            // btn_AddModule
            // 
            this.btn_AddModule.Location = new System.Drawing.Point(6, 114);
            this.btn_AddModule.Name = "btn_AddModule";
            this.btn_AddModule.Size = new System.Drawing.Size(177, 33);
            this.btn_AddModule.TabIndex = 4;
            this.btn_AddModule.Text = "Add module";
            this.btn_AddModule.UseVisualStyleBackColor = true;
            this.btn_AddModule.Click += new System.EventHandler(this.btn_AddModule_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Module Template";
            // 
            // cob_ModuleTemplates
            // 
            this.cob_ModuleTemplates.FormattingEnabled = true;
            this.cob_ModuleTemplates.Location = new System.Drawing.Point(6, 39);
            this.cob_ModuleTemplates.Name = "cob_ModuleTemplates";
            this.cob_ModuleTemplates.Size = new System.Drawing.Size(181, 21);
            this.cob_ModuleTemplates.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ImportSymbolicTable);
            this.groupBox1.Controls.Add(this.clb_ImportedItems);
            this.groupBox1.Controls.Add(this.btn_AddImportedModules);
            this.groupBox1.Location = new System.Drawing.Point(655, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 221);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add HW Conf from Excel";
            // 
            // btn_ImportSymbolicTable
            // 
            this.btn_ImportSymbolicTable.Location = new System.Drawing.Point(6, 29);
            this.btn_ImportSymbolicTable.Name = "btn_ImportSymbolicTable";
            this.btn_ImportSymbolicTable.Size = new System.Drawing.Size(177, 33);
            this.btn_ImportSymbolicTable.TabIndex = 2;
            this.btn_ImportSymbolicTable.Text = "Excel Import";
            this.btn_ImportSymbolicTable.UseVisualStyleBackColor = true;
            this.btn_ImportSymbolicTable.Click += new System.EventHandler(this.btn_ImportSymbolicTable_Click);
            // 
            // clb_ImportedItems
            // 
            this.clb_ImportedItems.FormattingEnabled = true;
            this.clb_ImportedItems.HorizontalScrollbar = true;
            this.clb_ImportedItems.Location = new System.Drawing.Point(6, 69);
            this.clb_ImportedItems.Name = "clb_ImportedItems";
            this.clb_ImportedItems.Size = new System.Drawing.Size(177, 94);
            this.clb_ImportedItems.TabIndex = 1;
            this.clb_ImportedItems.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_ImportedItems_ItemCheck);
            // 
            // btn_AddImportedModules
            // 
            this.btn_AddImportedModules.Location = new System.Drawing.Point(6, 176);
            this.btn_AddImportedModules.Name = "btn_AddImportedModules";
            this.btn_AddImportedModules.Size = new System.Drawing.Size(177, 33);
            this.btn_AddImportedModules.TabIndex = 0;
            this.btn_AddImportedModules.Text = "Add Selected Module";
            this.btn_AddImportedModules.UseVisualStyleBackColor = true;
            this.btn_AddImportedModules.Click += new System.EventHandler(this.btn_AddImportedModules_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.HW_Siemens);
            this.tabControl1.Controls.Add(this.HW_Other);
            this.tabControl1.Controls.Add(this.Tag);
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1084, 436);
            this.tabControl1.TabIndex = 8;
            // 
            // HW_Siemens
            // 
            this.HW_Siemens.Controls.Add(this.grb_TiaPortalProject);
            this.HW_Siemens.Controls.Add(this.groupBox1);
            this.HW_Siemens.Controls.Add(this.grb_Compile);
            this.HW_Siemens.Controls.Add(this.grb_TiaPortal);
            this.HW_Siemens.Controls.Add(this.grb_AddNewDevice);
            this.HW_Siemens.Controls.Add(this.grb_AddModule);
            this.HW_Siemens.Location = new System.Drawing.Point(4, 22);
            this.HW_Siemens.Name = "HW_Siemens";
            this.HW_Siemens.Padding = new System.Windows.Forms.Padding(3);
            this.HW_Siemens.Size = new System.Drawing.Size(1076, 410);
            this.HW_Siemens.TabIndex = 0;
            this.HW_Siemens.Text = "HW_Siemens";
            this.HW_Siemens.UseVisualStyleBackColor = true;
            // 
            // HW_Other
            // 
            this.HW_Other.Controls.Add(this.comboBox2);
            this.HW_Other.Controls.Add(this.button2);
            this.HW_Other.Controls.Add(this.button1);
            this.HW_Other.Location = new System.Drawing.Point(4, 22);
            this.HW_Other.Name = "HW_Other";
            this.HW_Other.Padding = new System.Windows.Forms.Padding(3);
            this.HW_Other.Size = new System.Drawing.Size(1076, 410);
            this.HW_Other.TabIndex = 1;
            this.HW_Other.Text = "HW_Other";
            this.HW_Other.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tag
            // 
            this.Tag.Location = new System.Drawing.Point(4, 22);
            this.Tag.Name = "Tag";
            this.Tag.Padding = new System.Windows.Forms.Padding(3);
            this.Tag.Size = new System.Drawing.Size(1076, 410);
            this.Tag.TabIndex = 2;
            this.Tag.Text = "Tag";
            this.Tag.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "TEST/DEBUG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(253, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(173, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // BasicProjectGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1099, 716);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lib_TraceWriterOutput);
            this.MinimumSize = new System.Drawing.Size(250, 300);
            this.Name = "BasicProjectGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Project Generator";
            this.Load += new System.EventHandler(this.BasicProjectGenerator_Load);
            this.grb_TiaPortal.ResumeLayout(false);
            this.grb_TiaPortal.PerformLayout();
            this.grb_TiaPortalProject.ResumeLayout(false);
            this.grb_TiaPortalProject.PerformLayout();
            this.grb_AddNewDevice.ResumeLayout(false);
            this.grb_AddNewDevice.PerformLayout();
            this.grb_Compile.ResumeLayout(false);
            this.grb_Compile.PerformLayout();
            this.grb_AddModule.ResumeLayout(false);
            this.grb_AddModule.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.HW_Siemens.ResumeLayout(false);
            this.HW_Other.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_TiaPortal;
        private System.Windows.Forms.Button btn_CloseTiaPortal;
        private System.Windows.Forms.Button btn_OpenTiaPortal;
        private System.Windows.Forms.RadioButton rdb_WithoutUI;
        private System.Windows.Forms.RadioButton rdb_WithUI;
        private System.Windows.Forms.GroupBox grb_TiaPortalProject;
        private System.Windows.Forms.GroupBox grb_AddNewDevice;
        private System.Windows.Forms.GroupBox grb_Compile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Processes;
        private System.Windows.Forms.Button btn_ConnectTiaPortal;
        private System.Windows.Forms.ComboBox cob_ProcessIds;
        private System.Windows.Forms.Label lbl_CurrentProcessId;
        private System.Windows.Forms.ListBox lib_TraceWriterOutput;
        private System.Windows.Forms.TextBox txb_CurrentProcessId;
        private System.Windows.Forms.TextBox txb_CurrentProjectName;
        private System.Windows.Forms.Label lbl_CurrentProjectName;
        private System.Windows.Forms.Label lbl_ProjectName;
        private System.Windows.Forms.TextBox txb_AvailableProjectName;
        private System.Windows.Forms.Button btn_CloseProject;
        private System.Windows.Forms.Button btn_SaveProject;
        private System.Windows.Forms.Button btn_LoadProject;
        private System.Windows.Forms.Button btn_OpenProject;
        private System.Windows.Forms.ComboBox cob_DeviceTemplates;
        private System.Windows.Forms.Label lbl_DeviceTemplates;
        private System.Windows.Forms.TextBox txb_DeviceName;
        private System.Windows.Forms.Label lbl_DeviceName;
        private System.Windows.Forms.Button btn_AddNewDevice;
        private System.Windows.Forms.TextBox txb_Version;
        private System.Windows.Forms.TextBox txb_OrderNr;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label lbl_OrderNr;
        private System.Windows.Forms.Label lab_DeviceList;
        private System.Windows.Forms.Button btn_CreateNewProject;
        private System.Windows.Forms.TextBox txb_TargetDirectory;
        private System.Windows.Forms.Label lbl_TargetDirectory;
        private System.Windows.Forms.ToolTip GeneratorToolTip;
        private System.Windows.Forms.Label lab_TypeIdentifier;
        private System.Windows.Forms.TextBox txb_TypeIdentifier;
        private System.Windows.Forms.ListBox lib_DeviceList;
        private System.Windows.Forms.CheckBox ckb_IncludeFailsafe;
        private System.Windows.Forms.TextBox txb_Station;
        private System.Windows.Forms.Label lab_Station;
        private System.Windows.Forms.ComboBox cob_DeviceList;
        private System.Windows.Forms.Button btn_CompileDevice;
        private System.Windows.Forms.Label lab_DeviceToCompile;
        private System.Windows.Forms.GroupBox grb_AddModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cob_ModuleTemplates;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_AddModule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_ModuleName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ImportSymbolicTable;
        private System.Windows.Forms.CheckedListBox clb_ImportedItems;
        private System.Windows.Forms.Button btn_AddImportedModules;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_PlcIpAddress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage HW_Siemens;
        private System.Windows.Forms.TabPage HW_Other;
        private System.Windows.Forms.TabPage Tag;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

