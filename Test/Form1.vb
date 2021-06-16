Imports stigzler.support.wcLicenseManagerNet

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetupForm()


    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.BaseUrl = BaseUrlTB.Text
        My.Settings.ConsumerKey = ConsumerKeyTB.Text
        My.Settings.ConsumerSecret = ConsumerSecretTB.Text
    End Sub

    Private Sub SetupForm()

        'ComboBoxes
        LicenseOperationCB.DataSource = [Enum].GetValues(GetType(LicenseRequestType))
        GeneratorOperationCB.DataSource = [Enum].GetValues(GetType(GeneratorRequestType))

        'Load Settings
        BaseUrlTB.Text = My.Settings.BaseUrl
        ConsumerKeyTB.Text = My.Settings.ConsumerKey
        ConsumerSecretTB.Text = My.Settings.ConsumerSecret

    End Sub

    Private Sub LicenseOperationGoBT_Click(sender As Object, e As EventArgs) Handles LicenseOperationGoBT.Click

        Cursor = Cursors.WaitCursor

        Dim apiInterface As New LicenseManagerApiInterface(BaseUrlTB.Text, ConsumerKeyTB.Text, ConsumerSecretTB.Text)
        With apiInterface
            .WebClientTimeout = 5000
        End With
        Dim response As LicenseRequestOutcome = Nothing

        Select Case LicenseOperationCB.SelectedItem
            Case LicenseRequestType.List
                response = apiInterface.LicenseRequest(LicenseOperationCB.SelectedItem)

            Case LicenseRequestType.Activate, LicenseRequestType.Deactivate, LicenseRequestType.Retrieve, LicenseRequestType.Validate
                response = apiInterface.LicenseRequest(LicenseOperationCB.SelectedItem, LicenseKeyTB.Text)

            Case LicenseRequestType.Update, LicenseRequestType.Create
                If TypeOf (PropertyGrid.SelectedObject) IsNot License Then
                    MsgBox("Please send a License with this operation via the Property Grid to the right (which is not currently a License).")
                    Return
                End If
                response = apiInterface.LicenseRequest(LicenseOperationCB.SelectedItem, LicenseKeyTB.Text, PropertyGrid.SelectedObject) ' this will be the license object in the property grid

        End Select

        OperationOutcomeLB.Text = response.ProcessOutcome.ToString
        ApiResponseLB.Text = response.APISuccessResponse.ToString
        JsonStringRTB.Text = response.APIReturnedJsonString
        ObjectsDGV.DataSource = response.Licences

        For Each col As DataGridViewColumn In ObjectsDGV.Columns
            If col.Name <> "LicenseKey" Then
                col.Visible = False
            Else
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Next


        If response.ProcessOutcome = ProcessOutcome.WebClientError Then
            PropertyGrid.SelectedObject = response.WebClientException
            TabControl1.SelectedTab = TabControl1.TabPages(1)
        Else
            TabControl1.SelectedTab = TabControl1.TabPages(0)
        End If

        If response.Licences IsNot Nothing AndAlso response.Licences.Count > 0 Then ObjectsDGV.Rows(0).Selected = True

        Cursor = Cursors.Default

        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)

    End Sub

    Private Sub ObjectsDGV_SelectionChanged(sender As Object, e As EventArgs) Handles ObjectsDGV.SelectionChanged

        If ObjectsDGV.SelectedRows.Count < 1 Then Return

        If TypeOf (ObjectsDGV.SelectedRows(0).DataBoundItem) Is License Then
            PropertyGrid.SelectedObject = ObjectsDGV.SelectedRows(0).DataBoundItem
            PropGridObjectTypeToggleBT.Checked = False
            If LicenseOperationCB.SelectedValue <> LicenseRequestType.Validate Then
                LicenseKeyTB.Text = DirectCast(ObjectsDGV.SelectedRows(0).DataBoundItem, License).LicenseKey
            End If

        Else


        End If


    End Sub

    Private Sub PropGridObjectTypeToggleBT_CheckStateChanged(sender As Object, e As EventArgs) Handles PropGridObjectTypeToggleBT.CheckStateChanged

        If PropGridObjectTypeToggleBT.Checked Then
            PropGridObjectTypeToggleBT.Image = My.Resources.equalizer
            PropertyGrid.SelectedObject = New Generator
        Else
            PropGridObjectTypeToggleBT.Image = My.Resources.license_key
            PropertyGrid.SelectedObject = New License
        End If

    End Sub

    Private Sub PropGridClearBT_Click(sender As Object, e As EventArgs) Handles PropGridClearBT.Click

        If PropGridObjectTypeToggleBT.Checked Then
            PropertyGrid.SelectedObject = New Generator
        Else
            PropertyGrid.SelectedObject = New License
        End If

    End Sub

    Private Sub PropertyGrid_SelectedObjectsChanged(sender As Object, e As EventArgs) Handles PropertyGrid.SelectedObjectsChanged
        If TypeOf (PropertyGrid.SelectedObject) Is License Then
            With PropertyGridLB
                .Text = "License"
                .Image = My.Resources.license_key
            End With
        ElseIf TypeOf (PropertyGrid.SelectedObject) Is Generator Then
            With PropertyGridLB
                .Text = "Generator"
                .Image = My.Resources.equalizer
            End With
        ElseIf TypeOf (PropertyGrid.SelectedObject) Is exception Then
            With PropertyGridLB
                .Text = "Exception"
                .Image = My.Resources.exclamation_red
            End With
        End If
    End Sub
End Class
