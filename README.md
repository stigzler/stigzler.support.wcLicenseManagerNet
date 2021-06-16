# wcLicenseManagerNet

### a .net Library for the License Manager for Woo Commerce Plugin

## Overview
blah

## Getting Started

```vbnet
' API CONNECT (URL, ConsumerKey, Consumer Secret)
Dim apiInterface As New LicenseManagerApiInterface("https://omnigamez.com", "ck_e267ba742205984464ccc9c566ae6f15fe949609", "cs_3d9e4eb833aabbdabbe694e3767f2ad5e75d89cc")

' ACTIVATE LICENSE
apiInterface.LicenseRequest(LicenseRequestType.Activate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE")

' DEACTIVATE LICENSE
apiInterface.LicenseRequest(LicenseRequestType.Deactivate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE")

' CHECK LICENCE KEY VALID
' Display True or False for Key validity
If apiInterface.LicenseRequest(LicenseRequestType.Validate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE").APIReturnedSuccess Then Debug.WriteLine("Valid")

' LIST ALL LICENSES
Dim apiRequest As LicenseRequestOutcome = apiInterface.LicenseRequest(LicenseRequestType.List)
Debug.WriteLine(String.Join(vbCr, apiRequest.Licences))
```

## Full Use Example
```vbnet
Dim LicenseKey As String = "OGZL-8DYMW-54PWP-THT76-7DG1Z-TEST1"

' CREATE A NEW LICENSE (to be sold)
Dim newLicense As New License With {.LicenseKey = LicenseKey,
                                    .Status = LicenseStatus.Inactive,
                                    .TimesActivated = 0,
                                    .TimesActivatedMax = 2}
apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Create, LicenseKey, newLicense)
Debug.WriteLine("License created: " & apiRequest.APIReturnedSuccess) ' true or false

' RETRIEVE LICENSE AND UPDATE STATUS TO DELIVERED (key delivered to customer via email)
apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Retrieve, LicenseKey)
If apiRequest.APIReturnedSuccess Then
    Dim retrievedLicense As License = apiRequest.Licences.First
    retrievedLicense.Status = LicenseStatus.Delivered
    apiInterface.LicenseRequest(LicenseRequestType.Update, LicenseKey, retrievedLicense)
Else
    Debug.WriteLine(apiRequest.ToString) ' this prints out any errors
End If

' VALIDATE THE LICENCE KEY,  ACTIVATE IF NOT AT MAXIMUM ACTIVATIONS AND SET STATUS TO ACTIVE (app's online activation)
apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Validate, LicenseKey)
If apiRequest.APIReturnedSuccess = True Then
    Debug.WriteLine("License is a valid")

    If apiRequest.Licences.First.RemainingActivations > 0 Then
        apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Activate, LicenseKey)

        If apiRequest.APIReturnedSuccess Then
            Debug.WriteLine("License successfully Activated. Activations: " & apiRequest.Licences.First.TimesActivated & " of " & apiRequest.Licences.First.TimesActivatedMax)
            apiRequest.Licences.First.Status = LicenseStatus.Active
            apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Update, LicenseKey, apiRequest.Licences.First)

            If apiRequest.APIReturnedSuccess Then
                Debug.WriteLine("License status successfully updated to Active")
            Else
                Debug.WriteLine("Error setting status: " & apiRequest.ToString)
            End If
        Else
            Debug.WriteLine("Error activating license: " & apiRequest.ToString)
        End If
    Else
        Debug.WriteLine("No more activations allowed on this License. Activations: " & apiRequest.Licences.First.TimesActivated & " of " & apiRequest.Licences.First.TimesActivatedMax)
    End If
Else
    Debug.WriteLine("Error validating license: " & apiRequest.ToString)
End If

' REDUCE ACTIVATION COUNT (customer deactivates license on one machine)
apiInterface.LicenseRequest(LicenseRequestType.Deactivate, LicenseKey)

' CHECK LICENSE STATUS (periodic app check that license hasn't been set to inactive by licensor)
If apiInterface.LicenseRequest(LicenseRequestType.Retrieve, LicenseKey).Licences.First.Status = LicenseStatus.Inactive Then
    Debug.WriteLine("App disabled due to license being set to inactive by licensor")
End If

```

## Advanced Functions
### Changing Mappings
