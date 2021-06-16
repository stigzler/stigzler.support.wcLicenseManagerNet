Imports stigzler.support.wcLicenseManagerNet

Public Class APITester
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

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    '    ' API CONNECT (URL, ConsumerKey, Consumer Secret)
    '    Dim apiInterface As New LicenseManagerApiInterface("https://omnigamez.com", "ck_e267ba742205984464ccc9c566ae6f15fe949609", "cs_3d9e4eb833aabbdabbe694e3767f2ad5e75d89cc")

    '    ' ACTIVATE LICENSE
    '    apiInterface.LicenseRequest(LicenseRequestType.Activate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE")

    '    ' DEACTIVATE LICENSE
    '    apiInterface.LicenseRequest(LicenseRequestType.Deactivate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE")

    '    ' CHECK LICENCE KEY VALID
    '    ' Display True or False for Key validity
    '    If apiInterface.LicenseRequest(LicenseRequestType.Validate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE").APIReturnedSuccess Then Debug.WriteLine("Valid")

    '    ' LIST ALL LICENSES
    '    Dim apiRequest As LicenseRequestOutcome = apiInterface.LicenseRequest(LicenseRequestType.List)
    '    Debug.WriteLine(String.Join(vbCr, apiRequest.Licences))

    '    Dim a As New LicenseManagerApiInterface("", "", "")
    '    a.LicenseRequest(LicenseRequestType.Deactivate, "",).Licences.

    '    '======================================================================================================
    '    ' REAL WORLD EXAMPLE
    '    Dim LicenseKey As String = "OGZL-8DYMW-54PWP-THT76-7DG1Z-TEST1"

    '    ' CREATE A NEW LICENSE (to be sold)
    '    Dim newLicense As New License With {.LicenseKey = LicenseKey,
    '                                        .Status = LicenseStatus.Inactive,
    '                                        .TimesActivated = 0,
    '                                        .TimesActivatedMax = 2}
    '    apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Create, LicenseKey, newLicense)
    '    Debug.WriteLine("License created: " & apiRequest.APIReturnedSuccess) ' true or false

    '    ' RETRIEVE LICENSE AND UPDATE STATUS TO DELIVERED (key delivered to customer via email)
    '    apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Retrieve, LicenseKey)
    '    If apiRequest.APIReturnedSuccess Then
    '        Dim retrievedLicense As License = apiRequest.Licences.First
    '        retrievedLicense.Status = LicenseStatus.Delivered
    '        apiInterface.LicenseRequest(LicenseRequestType.Update, LicenseKey, retrievedLicense)
    '    Else
    '        Debug.WriteLine(apiRequest.ToString) ' this prints out any errors
    '    End If

    '    ' VALIDATE THE LICENCE KEY,  ACTIVATE IF NOT AT MAXIMUM ACTIVATIONS AND SET STATUS TO ACTIVE (app's online activation)
    '    apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Validate, LicenseKey)
    '    If apiRequest.APIReturnedSuccess = True Then
    '        Debug.WriteLine("License is a valid")

    '        If apiRequest.Licences.First.RemainingActivations > 0 Then
    '            apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Activate, LicenseKey)

    '            If apiRequest.APIReturnedSuccess Then
    '                Debug.WriteLine("License successfully Activated. Activations: " & apiRequest.Licences.First.TimesActivated & " of " & apiRequest.Licences.First.TimesActivatedMax)
    '                apiRequest.Licences.First.Status = LicenseStatus.Active
    '                apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Update, LicenseKey, apiRequest.Licences.First)

    '                If apiRequest.APIReturnedSuccess Then
    '                    Debug.WriteLine("License status successfully updated to Active")
    '                Else
    '                    Debug.WriteLine("Error setting status: " & apiRequest.ToString)
    '                End If
    '            Else
    '                Debug.WriteLine("Error activating license: " & apiRequest.ToString)
    '            End If
    '        Else
    '            Debug.WriteLine("No more activations allowed on this License. Activations: " & apiRequest.Licences.First.TimesActivated & " of " & apiRequest.Licences.First.TimesActivatedMax)
    '        End If
    '    Else
    '        Debug.WriteLine("Error validating license: " & apiRequest.ToString)
    '    End If

    '    ' REDUCE ACTIVATION COUNT (customer deactivates license on one machine)
    '    apiInterface.LicenseRequest(LicenseRequestType.Deactivate, LicenseKey)

    '    ' CHECK LICENSE STATUS (periodic app check that license hasn't been set to inactive by licensor)
    '    If apiInterface.LicenseRequest(LicenseRequestType.Retrieve, LicenseKey).Licences.First.Status = LicenseStatus.Inactive Then
    '        Debug.WriteLine("App disabled due to license being set to inactive by licensor")
    '    End If

    'End Sub

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
        ApiResponseLB.Text = response.APIReturnedSuccess.ToString
        JsonStringRTB.Text = response.APIJsonString
        PropGridObjectTypeToggleBT.Checked = False ' linked event switches to license in prop grid - done here to prevent it overwriting with blank
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
            If LicenseOperationCB.SelectedValue <> LicenseRequestType.Validate Then
                LicenseKeyTB.Text = DirectCast(ObjectsDGV.SelectedRows(0).DataBoundItem, License).LicenseKey
            End If

        ElseIf TypeOf (ObjectsDGV.SelectedRows(0).DataBoundItem) Is generator Then
            PropertyGrid.SelectedObject = ObjectsDGV.SelectedRows(0).DataBoundItem
            GeneratorIdTB.Text = DirectCast(ObjectsDGV.SelectedRows(0).DataBoundItem, Generator).ID
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
        ElseIf TypeOf (PropertyGrid.SelectedObject) Is Exception Then
            With PropertyGridLB
                .Text = "Exception"
                .Image = My.Resources.exclamation_red
            End With
        End If
    End Sub

    Private Sub GeneratorOperationGoBT_Click(sender As Object, e As EventArgs) Handles GeneratorOperationGoBT.Click
        Cursor = Cursors.WaitCursor

        Dim apiInterface As New LicenseManagerApiInterface(BaseUrlTB.Text, ConsumerKeyTB.Text, ConsumerSecretTB.Text)
        With apiInterface
            .WebClientTimeout = 5000
        End With
        Dim response As GeneratorRequestOutcome = Nothing

        Select Case GeneratorOperationCB.SelectedItem
            Case GeneratorRequestType.List
                response = apiInterface.GeneratorRequest(GeneratorOperationCB.SelectedItem)

            Case GeneratorRequestType.Retrieve
                response = apiInterface.GeneratorRequest(GeneratorOperationCB.SelectedItem, GeneratorIdTB.Text)

            Case GeneratorRequestType.Update, GeneratorRequestType.Create
                If TypeOf (PropertyGrid.SelectedObject) IsNot Generator Then
                    MsgBox("Please send a Generator with this operation via the Property Grid to the right (which is not currently a Generator).")
                    Return
                End If
                response = apiInterface.GeneratorRequest(GeneratorOperationCB.SelectedItem, GeneratorIdTB.Text, PropertyGrid.SelectedObject) ' this will be the license object in the property grid

        End Select

        OperationOutcomeLB.Text = response.ProcessOutcome.ToString
        ApiResponseLB.Text = response.APIReturnedSuccess.ToString
        JsonStringRTB.Text = response.APIJsonString
        PropGridObjectTypeToggleBT.Checked = True ' linked event switches to generator in prop grid - done here to prevent it overwriting with blank
        ObjectsDGV.DataSource = response.Generators

        For Each col As DataGridViewColumn In ObjectsDGV.Columns
            If col.Name <> "Name" Then
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

        If response.Generators IsNot Nothing AndAlso response.Generators.Count > 0 Then ObjectsDGV.Rows(0).Selected = True

        Cursor = Cursors.Default

        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)

    End Sub
End Class
