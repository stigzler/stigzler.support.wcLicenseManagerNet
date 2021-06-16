<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class APITester
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(APITester))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GeneratorIdTB = New System.Windows.Forms.TextBox()
        Me.LicenseKeyTB = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ApiResponseLB = New System.Windows.Forms.Label()
        Me.OperationOutcomeLB = New System.Windows.Forms.Label()
        Me.GeneratorOperationGoBT = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GeneratorOperationCB = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ObjectsDGV = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.JsonStringRTB = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LicenseOperationGoBT = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LicenseOperationCB = New System.Windows.Forms.ComboBox()
        Me.ConsumerSecretTB = New System.Windows.Forms.TextBox()
        Me.ConsumerKeyTB = New System.Windows.Forms.TextBox()
        Me.BaseUrlTB = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PropertyGridLB = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PropGridClearBT = New System.Windows.Forms.ToolStripButton()
        Me.PropGridObjectTypeToggleBT = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.ObjectsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GeneratorIdTB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LicenseKeyTB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ApiResponseLB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.OperationOutcomeLB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GeneratorOperationGoBT)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GeneratorOperationCB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LicenseOperationGoBT)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LicenseOperationCB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ConsumerSecretTB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ConsumerKeyTB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BaseUrlTB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PropertyGrid)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PropertyGridLB)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Size = New System.Drawing.Size(946, 582)
        Me.SplitContainer1.SplitterDistance = 473
        Me.SplitContainer1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(367, 226)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GeneratorIdTB
        '
        Me.GeneratorIdTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneratorIdTB.Location = New System.Drawing.Point(136, 168)
        Me.GeneratorIdTB.Name = "GeneratorIdTB"
        Me.GeneratorIdTB.Size = New System.Drawing.Size(321, 23)
        Me.GeneratorIdTB.TabIndex = 24
        '
        'LicenseKeyTB
        '
        Me.LicenseKeyTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LicenseKeyTB.Location = New System.Drawing.Point(136, 105)
        Me.LicenseKeyTB.Name = "LicenseKeyTB"
        Me.LicenseKeyTB.Size = New System.Drawing.Size(321, 23)
        Me.LicenseKeyTB.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(54, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 15)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Generator ID:"
        Me.ToolTip1.SetToolTip(Me.Label10, "Generator ID to use for Generator Operations")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(59, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 15)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "License Key:"
        Me.ToolTip1.SetToolTip(Me.Label11, "License Key to use for License Operations")
        '
        'ApiResponseLB
        '
        Me.ApiResponseLB.AutoSize = True
        Me.ApiResponseLB.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ApiResponseLB.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.ApiResponseLB.Location = New System.Drawing.Point(136, 287)
        Me.ApiResponseLB.Name = "ApiResponseLB"
        Me.ApiResponseLB.Size = New System.Drawing.Size(150, 21)
        Me.ApiResponseLB.TabIndex = 20
        Me.ApiResponseLB.Text = "Awaiting operation"
        Me.ToolTip1.SetToolTip(Me.ApiResponseLB, "The base URL of the endpoint (e.g. Https://Mysite.org)")
        '
        'OperationOutcomeLB
        '
        Me.OperationOutcomeLB.AutoSize = True
        Me.OperationOutcomeLB.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.OperationOutcomeLB.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.OperationOutcomeLB.Location = New System.Drawing.Point(136, 258)
        Me.OperationOutcomeLB.Name = "OperationOutcomeLB"
        Me.OperationOutcomeLB.Size = New System.Drawing.Size(150, 21)
        Me.OperationOutcomeLB.TabIndex = 19
        Me.OperationOutcomeLB.Text = "Awaiting operation"
        Me.ToolTip1.SetToolTip(Me.OperationOutcomeLB, "The base URL of the endpoint (e.g. Https://Mysite.org)")
        '
        'GeneratorOperationGoBT
        '
        Me.GeneratorOperationGoBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneratorOperationGoBT.Location = New System.Drawing.Point(367, 197)
        Me.GeneratorOperationGoBT.Name = "GeneratorOperationGoBT"
        Me.GeneratorOperationGoBT.Size = New System.Drawing.Size(90, 23)
        Me.GeneratorOperationGoBT.TabIndex = 18
        Me.GeneratorOperationGoBT.Text = "Go"
        Me.GeneratorOperationGoBT.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Generator Operation:"
        '
        'GeneratorOperationCB
        '
        Me.GeneratorOperationCB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneratorOperationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GeneratorOperationCB.FormattingEnabled = True
        Me.GeneratorOperationCB.Location = New System.Drawing.Point(136, 197)
        Me.GeneratorOperationCB.Name = "GeneratorOperationCB"
        Me.GeneratorOperationCB.Size = New System.Drawing.Size(225, 23)
        Me.GeneratorOperationCB.TabIndex = 16
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(9, 322)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(459, 255)
        Me.TabControl1.TabIndex = 15
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ObjectsDGV)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(451, 227)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Objects"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ObjectsDGV
        '
        Me.ObjectsDGV.AllowUserToResizeRows = False
        Me.ObjectsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ObjectsDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObjectsDGV.Location = New System.Drawing.Point(3, 3)
        Me.ObjectsDGV.Name = "ObjectsDGV"
        Me.ObjectsDGV.ReadOnly = True
        Me.ObjectsDGV.RowHeadersVisible = False
        Me.ObjectsDGV.RowTemplate.Height = 25
        Me.ObjectsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ObjectsDGV.Size = New System.Drawing.Size(445, 221)
        Me.ObjectsDGV.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.JsonStringRTB)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(10)
        Me.TabPage2.Size = New System.Drawing.Size(451, 227)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Json String"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'JsonStringRTB
        '
        Me.JsonStringRTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.JsonStringRTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JsonStringRTB.Location = New System.Drawing.Point(10, 10)
        Me.JsonStringRTB.Name = "JsonStringRTB"
        Me.JsonStringRTB.Size = New System.Drawing.Size(431, 207)
        Me.JsonStringRTB.TabIndex = 0
        Me.JsonStringRTB.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(49, 290)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "API Response:"
        Me.ToolTip1.SetToolTip(Me.Label7, "Boolean repsonse from the API (True = request successful)")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Operation outcome:"
        Me.ToolTip1.SetToolTip(Me.Label6, "Gives details regarding the outcome of the request/operation")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(136, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 21)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Results"
        Me.ToolTip1.SetToolTip(Me.Label5, "The base URL of the endpoint (e.g. Https://Mysite.org)")
        '
        'LicenseOperationGoBT
        '
        Me.LicenseOperationGoBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LicenseOperationGoBT.Location = New System.Drawing.Point(367, 134)
        Me.LicenseOperationGoBT.Name = "LicenseOperationGoBT"
        Me.LicenseOperationGoBT.Size = New System.Drawing.Size(90, 23)
        Me.LicenseOperationGoBT.TabIndex = 9
        Me.LicenseOperationGoBT.Text = "Go"
        Me.LicenseOperationGoBT.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "License Operation:"
        '
        'LicenseOperationCB
        '
        Me.LicenseOperationCB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LicenseOperationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LicenseOperationCB.FormattingEnabled = True
        Me.LicenseOperationCB.Location = New System.Drawing.Point(136, 134)
        Me.LicenseOperationCB.Name = "LicenseOperationCB"
        Me.LicenseOperationCB.Size = New System.Drawing.Size(225, 23)
        Me.LicenseOperationCB.TabIndex = 7
        '
        'ConsumerSecretTB
        '
        Me.ConsumerSecretTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConsumerSecretTB.Location = New System.Drawing.Point(136, 70)
        Me.ConsumerSecretTB.Name = "ConsumerSecretTB"
        Me.ConsumerSecretTB.Size = New System.Drawing.Size(321, 23)
        Me.ConsumerSecretTB.TabIndex = 6
        '
        'ConsumerKeyTB
        '
        Me.ConsumerKeyTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConsumerKeyTB.Location = New System.Drawing.Point(136, 41)
        Me.ConsumerKeyTB.Name = "ConsumerKeyTB"
        Me.ConsumerKeyTB.Size = New System.Drawing.Size(321, 23)
        Me.ConsumerKeyTB.TabIndex = 5
        '
        'BaseUrlTB
        '
        Me.BaseUrlTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BaseUrlTB.Location = New System.Drawing.Point(136, 12)
        Me.BaseUrlTB.Name = "BaseUrlTB"
        Me.BaseUrlTB.Size = New System.Drawing.Size(321, 23)
        Me.BaseUrlTB.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "API Consumer Secret:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "API Consumer Key:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Base URL:"
        Me.ToolTip1.SetToolTip(Me.Label1, "The base URL of the endpoint (e.g. Https://Mysite.org)")
        '
        'PropertyGrid
        '
        Me.PropertyGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid.Location = New System.Drawing.Point(5, 50)
        Me.PropertyGrid.Name = "PropertyGrid"
        Me.PropertyGrid.Size = New System.Drawing.Size(457, 457)
        Me.PropertyGrid.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoEllipsis = True
        Me.Label9.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(5, 507)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(457, 68)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = resources.GetString("Label9.Text")
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PropertyGridLB
        '
        Me.PropertyGridLB.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PropertyGridLB.Dock = System.Windows.Forms.DockStyle.Top
        Me.PropertyGridLB.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.PropertyGridLB.ForeColor = System.Drawing.Color.Gainsboro
        Me.PropertyGridLB.Image = Global.Test.My.Resources.Resources.license_key
        Me.PropertyGridLB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PropertyGridLB.Location = New System.Drawing.Point(5, 30)
        Me.PropertyGridLB.Name = "PropertyGridLB"
        Me.PropertyGridLB.Size = New System.Drawing.Size(457, 20)
        Me.PropertyGridLB.TabIndex = 2
        Me.PropertyGridLB.Text = "License"
        Me.PropertyGridLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropGridClearBT, Me.PropGridObjectTypeToggleBT})
        Me.ToolStrip1.Location = New System.Drawing.Point(5, 5)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(457, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PropGridClearBT
        '
        Me.PropGridClearBT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PropGridClearBT.Image = Global.Test.My.Resources.Resources.eraser
        Me.PropGridClearBT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PropGridClearBT.Name = "PropGridClearBT"
        Me.PropGridClearBT.Size = New System.Drawing.Size(23, 22)
        Me.PropGridClearBT.Text = "ToolStripButton1"
        Me.PropGridClearBT.ToolTipText = "Clear Object"
        '
        'PropGridObjectTypeToggleBT
        '
        Me.PropGridObjectTypeToggleBT.CheckOnClick = True
        Me.PropGridObjectTypeToggleBT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PropGridObjectTypeToggleBT.Image = Global.Test.My.Resources.Resources.license_key
        Me.PropGridObjectTypeToggleBT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PropGridObjectTypeToggleBT.Name = "PropGridObjectTypeToggleBT"
        Me.PropGridObjectTypeToggleBT.Size = New System.Drawing.Size(23, 22)
        Me.PropGridObjectTypeToggleBT.Text = "ToolStripButton2"
        Me.PropGridObjectTypeToggleBT.ToolTipText = "Toggle between License and Generator"
        '
        'APITester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 582)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "APITester"
        Me.Text = "API Tester"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.ObjectsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PropertyGrid As PropertyGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PropGridClearBT As ToolStripButton
    Friend WithEvents LicenseOperationGoBT As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LicenseOperationCB As ComboBox
    Friend WithEvents ConsumerSecretTB As TextBox
    Friend WithEvents ConsumerKeyTB As TextBox
    Friend WithEvents BaseUrlTB As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ObjectsDGV As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents JsonStringRTB As RichTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ApiResponseLB As Label
    Friend WithEvents OperationOutcomeLB As Label
    Friend WithEvents GeneratorOperationGoBT As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents GeneratorOperationCB As ComboBox
    Friend WithEvents PropGridObjectTypeToggleBT As ToolStripButton
    Friend WithEvents PropertyGridLB As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GeneratorIdTB As TextBox
    Friend WithEvents LicenseKeyTB As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
End Class
