
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
            this.btn_CreateNewProject = new System.Windows.Forms.Button();
            this.txb_TargetDirectory = new System.Windows.Forms.TextBox();
            this.lbl_TargetDirectory = new System.Windows.Forms.Label();
            this.txb_CurrentProjectName = new System.Windows.Forms.TextBox();
            this.lbl_CurrentProjectName = new System.Windows.Forms.Label();
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.txb_AvailableProjectName = new System.Windows.Forms.TextBox();
            this.btn_CloseProject = new System.Windows.Forms.Button();
            this.btn_SaveProject = new System.Windows.Forms.Button();
            this.btn_LoadProject = new System.Windows.Forms.Button();
            this.btn_OpenProject = new System.Windows.Forms.Button();
            this.grb_AddNewDevice = new System.Windows.Forms.GroupBox();
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
            this.grb_TiaPortal.SuspendLayout();
            this.grb_TiaPortalProject.SuspendLayout();
            this.grb_AddNewDevice.SuspendLayout();
            this.grb_Compile.SuspendLayout();
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
            this.grb_TiaPortal.Location = new System.Drawing.Point(12, 12);
            this.grb_TiaPortal.Name = "grb_TiaPortal";
            this.grb_TiaPortal.Size = new System.Drawing.Size(211, 436);
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
            this.lbl_Processes.Location = new System.Drawing.Point(18, 235);
            this.lbl_Processes.Name = "lbl_Processes";
            this.lbl_Processes.Size = new System.Drawing.Size(56, 13);
            this.lbl_Processes.TabIndex = 6;
            this.lbl_Processes.Text = "Processes";
            // 
            // btn_ConnectTiaPortal
            // 
            this.btn_ConnectTiaPortal.Location = new System.Drawing.Point(18, 289);
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
            this.cob_ProcessIds.Location = new System.Drawing.Point(18, 250);
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
            this.btn_CloseTiaPortal.Location = new System.Drawing.Point(21, 383);
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
            this.rdb_WithoutUI.TabStop = true;
            this.rdb_WithoutUI.Text = "Without user interface";
            this.rdb_WithoutUI.UseVisualStyleBackColor = true;
            // 
            // rdb_WithUI
            // 
            this.rdb_WithUI.AutoSize = true;
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
            this.grb_TiaPortalProject.Controls.Add(this.btn_CreateNewProject);
            this.grb_TiaPortalProject.Controls.Add(this.txb_TargetDirectory);
            this.grb_TiaPortalProject.Controls.Add(this.lbl_TargetDirectory);
            this.grb_TiaPortalProject.Controls.Add(this.txb_CurrentProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.lbl_CurrentProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.lbl_ProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.txb_AvailableProjectName);
            this.grb_TiaPortalProject.Controls.Add(this.btn_CloseProject);
            this.grb_TiaPortalProject.Controls.Add(this.btn_SaveProject);
            this.grb_TiaPortalProject.Controls.Add(this.btn_LoadProject);
            this.grb_TiaPortalProject.Controls.Add(this.btn_OpenProject);
            this.grb_TiaPortalProject.Location = new System.Drawing.Point(229, 12);
            this.grb_TiaPortalProject.Name = "grb_TiaPortalProject";
            this.grb_TiaPortalProject.Size = new System.Drawing.Size(211, 436);
            this.grb_TiaPortalProject.TabIndex = 1;
            this.grb_TiaPortalProject.TabStop = false;
            this.grb_TiaPortalProject.Text = "TIA Portal project";
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
            this.lbl_ProjectName.Location = new System.Drawing.Point(18, 235);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(85, 13);
            this.lbl_ProjectName.TabIndex = 6;
            this.lbl_ProjectName.Text = "Available project";
            // 
            // txb_AvailableProjectName
            // 
            this.txb_AvailableProjectName.Location = new System.Drawing.Point(18, 250);
            this.txb_AvailableProjectName.Name = "txb_AvailableProjectName";
            this.txb_AvailableProjectName.ReadOnly = true;
            this.txb_AvailableProjectName.Size = new System.Drawing.Size(173, 20);
            this.txb_AvailableProjectName.TabIndex = 7;
            this.txb_AvailableProjectName.MouseHover += new System.EventHandler(this.txb_AvailableProjectName_MouseHover);
            // 
            // btn_CloseProject
            // 
            this.btn_CloseProject.Location = new System.Drawing.Point(18, 383);
            this.btn_CloseProject.Name = "btn_CloseProject";
            this.btn_CloseProject.Size = new System.Drawing.Size(173, 33);
            this.btn_CloseProject.TabIndex = 10;
            this.btn_CloseProject.Text = "Close project";
            this.btn_CloseProject.UseVisualStyleBackColor = true;
            this.btn_CloseProject.Click += new System.EventHandler(this.btn_CloseProject_Click);
            // 
            // btn_SaveProject
            // 
            this.btn_SaveProject.Location = new System.Drawing.Point(18, 344);
            this.btn_SaveProject.Name = "btn_SaveProject";
            this.btn_SaveProject.Size = new System.Drawing.Size(173, 33);
            this.btn_SaveProject.TabIndex = 9;
            this.btn_SaveProject.Text = "Save project";
            this.btn_SaveProject.UseVisualStyleBackColor = true;
            this.btn_SaveProject.Click += new System.EventHandler(this.btn_SaveProject_Click);
            // 
            // btn_LoadProject
            // 
            this.btn_LoadProject.Location = new System.Drawing.Point(18, 289);
            this.btn_LoadProject.Name = "btn_LoadProject";
            this.btn_LoadProject.Size = new System.Drawing.Size(173, 33);
            this.btn_LoadProject.TabIndex = 8;
            this.btn_LoadProject.Text = "Load project";
            this.btn_LoadProject.UseVisualStyleBackColor = true;
            this.btn_LoadProject.Click += new System.EventHandler(this.btn_LoadProject_Click);
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
            this.grb_AddNewDevice.Location = new System.Drawing.Point(446, 12);
            this.grb_AddNewDevice.Name = "grb_AddNewDevice";
            this.grb_AddNewDevice.Size = new System.Drawing.Size(211, 436);
            this.grb_AddNewDevice.TabIndex = 2;
            this.grb_AddNewDevice.TabStop = false;
            this.grb_AddNewDevice.Text = "Add new device";
            // 
            // txb_Station
            // 
            this.txb_Station.Location = new System.Drawing.Point(18, 170);
            this.txb_Station.Name = "txb_Station";
            this.txb_Station.Size = new System.Drawing.Size(173, 20);
            this.txb_Station.TabIndex = 6;
            this.txb_Station.MouseHover += new System.EventHandler(this.txb_Station_MouseHover);
            // 
            // lab_Station
            // 
            this.lab_Station.AutoSize = true;
            this.lab_Station.Location = new System.Drawing.Point(18, 155);
            this.lab_Station.Name = "lab_Station";
            this.lab_Station.Size = new System.Drawing.Size(69, 13);
            this.lab_Station.TabIndex = 5;
            this.lab_Station.Text = "Station name";
            // 
            // ckb_IncludeFailsafe
            // 
            this.ckb_IncludeFailsafe.AutoSize = true;
            this.ckb_IncludeFailsafe.Location = new System.Drawing.Point(18, 87);
            this.ckb_IncludeFailsafe.Name = "ckb_IncludeFailsafe";
            this.ckb_IncludeFailsafe.Size = new System.Drawing.Size(100, 17);
            this.ckb_IncludeFailsafe.TabIndex = 2;
            this.ckb_IncludeFailsafe.Text = "Include Failsafe";
            this.ckb_IncludeFailsafe.UseVisualStyleBackColor = true;
            // 
            // lab_TypeIdentifier
            // 
            this.lab_TypeIdentifier.AutoSize = true;
            this.lab_TypeIdentifier.Location = new System.Drawing.Point(18, 275);
            this.lab_TypeIdentifier.Name = "lab_TypeIdentifier";
            this.lab_TypeIdentifier.Size = new System.Drawing.Size(73, 13);
            this.lab_TypeIdentifier.TabIndex = 11;
            this.lab_TypeIdentifier.Text = "Type identifier";
            // 
            // txb_TypeIdentifier
            // 
            this.txb_TypeIdentifier.Location = new System.Drawing.Point(18, 290);
            this.txb_TypeIdentifier.Name = "txb_TypeIdentifier";
            this.txb_TypeIdentifier.ReadOnly = true;
            this.txb_TypeIdentifier.Size = new System.Drawing.Size(173, 20);
            this.txb_TypeIdentifier.TabIndex = 12;
            this.txb_TypeIdentifier.MouseHover += new System.EventHandler(this.txb_TypeIdentifier_MouseHover);
            // 
            // txb_DeviceName
            // 
            this.txb_DeviceName.Location = new System.Drawing.Point(18, 130);
            this.txb_DeviceName.Name = "txb_DeviceName";
            this.txb_DeviceName.Size = new System.Drawing.Size(173, 20);
            this.txb_DeviceName.TabIndex = 4;
            this.txb_DeviceName.MouseHover += new System.EventHandler(this.txb_DeviceName_MouseHover);
            // 
            // lbl_DeviceName
            // 
            this.lbl_DeviceName.AutoSize = true;
            this.lbl_DeviceName.Location = new System.Drawing.Point(18, 115);
            this.lbl_DeviceName.Name = "lbl_DeviceName";
            this.lbl_DeviceName.Size = new System.Drawing.Size(70, 13);
            this.lbl_DeviceName.TabIndex = 3;
            this.lbl_DeviceName.Text = "Device name";
            // 
            // btn_AddNewDevice
            // 
            this.btn_AddNewDevice.Location = new System.Drawing.Point(18, 344);
            this.btn_AddNewDevice.Name = "btn_AddNewDevice";
            this.btn_AddNewDevice.Size = new System.Drawing.Size(173, 33);
            this.btn_AddNewDevice.TabIndex = 13;
            this.btn_AddNewDevice.Text = "Add new device";
            this.btn_AddNewDevice.UseVisualStyleBackColor = true;
            this.btn_AddNewDevice.Click += new System.EventHandler(this.btn_AddNewDevice_Click);
            // 
            // txb_Version
            // 
            this.txb_Version.Location = new System.Drawing.Point(18, 250);
            this.txb_Version.Name = "txb_Version";
            this.txb_Version.Size = new System.Drawing.Size(173, 20);
            this.txb_Version.TabIndex = 10;
            this.txb_Version.Leave += new System.EventHandler(this.txb_Version_Leave);
            this.txb_Version.MouseHover += new System.EventHandler(this.txb_Version_MouseHover);
            // 
            // txb_OrderNr
            // 
            this.txb_OrderNr.Location = new System.Drawing.Point(18, 210);
            this.txb_OrderNr.Name = "txb_OrderNr";
            this.txb_OrderNr.Size = new System.Drawing.Size(173, 20);
            this.txb_OrderNr.TabIndex = 8;
            this.txb_OrderNr.Leave += new System.EventHandler(this.txb_OrderNr_Leave);
            this.txb_OrderNr.MouseHover += new System.EventHandler(this.txb_OrderNr_MouseHover);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(18, 235);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(42, 13);
            this.lbl_Version.TabIndex = 9;
            this.lbl_Version.Text = "Version";
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.Location = new System.Drawing.Point(18, 195);
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
            this.grb_Compile.Location = new System.Drawing.Point(663, 12);
            this.grb_Compile.Name = "grb_Compile";
            this.grb_Compile.Size = new System.Drawing.Size(211, 436);
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
            this.cob_DeviceList.SelectedIndexChanged += new System.EventHandler(this.cob_DeviceList_SelectedIndexChanged);
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
            this.lib_TraceWriterOutput.Size = new System.Drawing.Size(862, 121);
            this.lib_TraceWriterOutput.TabIndex = 4;
            // 
            // BasicProjectGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(887, 588);
            this.Controls.Add(this.lib_TraceWriterOutput);
            this.Controls.Add(this.grb_Compile);
            this.Controls.Add(this.grb_AddNewDevice);
            this.Controls.Add(this.grb_TiaPortalProject);
            this.Controls.Add(this.grb_TiaPortal);
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
    }
}

