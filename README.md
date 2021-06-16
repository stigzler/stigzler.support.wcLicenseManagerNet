# wcLicense ManagerNet

### a .net Library for the License Manager for Woo Commerce Plugin

## Overview
blah

## Use Examples
### Simple

```cs
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


## Advanced Functions
### Changing Mappings
