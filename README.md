# wcLicenseManagerNet

### a .net Library for the *License Manager for Woo Commerce* Plugin

# Overview
wcLicenseManagerNet is a .Net Standard library designed for use with the Wordpress/WooCommerce plugin [LicenseManager](https://wordpress.org/plugins/license-manager-for-woocommerce/). It interfaces with the plugin's API via one main method:

```LicenseManagerApiInterface(BaseURL,ConsumerKey,ConsumerSecret)```

This, in turn, has two main methods to manipulate the Licenses and Generators:

```.LicenseRequest(LicenseRequestType,[LicenseKey],[License])```

```.GeneratorRequest(GeneratorRequestType,[GeneratorID],[Generator])```

```LicenseRequestType``` (and its Generator equivalent) includes all the operations available within the API, such as Create, Validate and Activate.

This returns the object `LicenseRequestOutcome` which contains various properties including the outcome of the operation, any WebClient errors and any returned Json string.

It also leverages two data object types, `License` and `Generator` which hold the respective details retrieved from the API and also are used in any Create or Update requests.

# Download
It can be installed from NuGet via the usual means or downloaded and compiled from here. If you use nuget, it might also be advisable to download this Visual Studio Solution to use the [Test Application](#Test-Application) to experiment with the API.

# Getting Started - Code Examples

C# code [HERE](#C-Sharp-Code)

```vbnet
' API CONNECT (URL, ConsumerKey, Consumer Secret)
Dim apiInterface As New LicenseManagerApiInterface("https://mysite.com", "ck_e267ba742205938e986ab56ae6f145fe609", "cs_3d9e4eb833397ab67fd987d76ed5d89cc")

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

# Full Use Case Example
```vbnet
Dim apiInterface As New LicenseManagerApiInterface("https://mysite.com", "ck_e267ba742205938e986ab56ae6f145fe609", "cs_3d9e4eb833397ab67fd987d76ed5d89cc")
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
# Points of note
* `LicenseRequestOutcome.Licenses` always returns a list of License objects, even where only a single object is expected (e.g. Retrieve). Just use the `.first` extension to get the license in these instances.
* Create License doesn't require a new Licence key to conform to any generators. 
* The bare minimum for license creation is a Key and Status.

# Test Application
The full Visual Studio solution is in this repo. If you download it, you'll also find an app called API Tester. This is useful for experimenting with your LicenseManager API and getting used to the various requests.

![Screenshot](/../master/Test/APITester.png?raw=true)

# Advanced Functions
## Changing Mappings
`LicenseManagerApiInterface` has some properties that can be edited in case of future updates to the API that require updated values. These are:

|Property|Type|Function|Examples|API Link
|-|-|-|-|-|
|LicenseEndpointsMap|Dictionary(Of LicenseRequestType,string)|License Endpoints: Constructs endpoint for requests|{LicenseRequestType.List, "/wp-json/lmfwc/v2/licenses/"}|[HERE](https://www.licensemanager.at/docs/rest-api/developer-documentation/list-licenses)
|PropertyToDatabaseMap|Dictionary(Of Type, Dictionary(Of String, String))|Database fields:  maps properties to these|{"LicenseKey", "license_key"}|[HERE](https://www.licensemanager.at/docs/internal-api/database-structure/lmfwc-licenses)

# Links
[Plugin WP Homepage](https://wordpress.org/plugins/license-manager-for-woocommerce/)

[Plugin Homepage + Docs](https://www.licensemanager.at/)

[Plugin Github](https://github.com/drazenbebic/license-manager-for-woocommerce)

# C Sharp Code
Getting started:
```cs
// API CONNECT (URL, ConsumerKey, Consumer Secret)
LicenseManagerApiInterface apiInterface = new LicenseManagerApiInterface("https://mysite.com", "ck_e267ba742205938e986ab56ae6f145fe609", "cs_3d9e4eb833397ab67fd987d76ed5d89cc");

// ACTIVATE LICENSE
apiInterface.LicenseRequest(LicenseRequestType.Activate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE");

// DEACTIVATE LICENSE
apiInterface.LicenseRequest(LicenseRequestType.Deactivate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE");

// CHECK LICENCE KEY VALID
// Display True or False for Key validity
if (apiInterface.LicenseRequest(LicenseRequestType.Validate, "OGZL-8DYMW-54PWP-THT76-7DG1Z-S2XXE").APIReturnedSuccess)
    Debug.WriteLine("Valid");

// LIST ALL LICENSES
LicenseRequestOutcome apiRequest = apiInterface.LicenseRequest(LicenseRequestType.List);
Debug.WriteLine(string.Join(Constants.vbCr, apiRequest.Licences));
```
Full Use Case Example:
```cs
LicenseManagerApiInterface apiInterface = new LicenseManagerApiInterface("https://mysite.com", "ck_e267ba742205938e986ab56ae6f145fe609", "cs_3d9e4eb833397ab67fd987d76ed5d89cc");
string LicenseKey = "OGZL-8DYMW-54PWP-THT76-7DG1Z-TEST1";

    // CREATE A NEW LICENSE (to be sold)
    License newLicense = new License() { LicenseKey = LicenseKey, Status = LicenseStatus.Inactive, TimesActivated = 0, TimesActivatedMax = 2 };
    apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Create, LicenseKey, newLicense);
    Debug.WriteLine("License created: " + apiRequest.APIReturnedSuccess); // true or false

    // RETRIEVE LICENSE AND UPDATE STATUS TO DELIVERED (key delivered to customer via email)
    apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Retrieve, LicenseKey);
    if (apiRequest.APIReturnedSuccess)
    {
        License retrievedLicense = apiRequest.Licences.First;
        retrievedLicense.Status = LicenseStatus.Delivered;
        apiInterface.LicenseRequest(LicenseRequestType.Update, LicenseKey, retrievedLicense);
    }
    else
        Debug.WriteLine(apiRequest.ToString);// this prints out any errors

    // VALIDATE THE LICENCE KEY,  ACTIVATE IF NOT AT MAXIMUM ACTIVATIONS AND SET STATUS TO ACTIVE (app's online activation)
    apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Validate, LicenseKey);
    if (apiRequest.APIReturnedSuccess == true)
    {
        Debug.WriteLine("License is a valid");

        if (apiRequest.Licences.First.RemainingActivations > 0)
        {
            apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Activate, LicenseKey);

            if (apiRequest.APIReturnedSuccess)
            {
                Debug.WriteLine("License successfully Activated. Activations: " + apiRequest.Licences.First.TimesActivated + " of " + apiRequest.Licences.First.TimesActivatedMax);
                apiRequest.Licences.First.Status = LicenseStatus.Active;
                apiRequest = apiInterface.LicenseRequest(LicenseRequestType.Update, LicenseKey, apiRequest.Licences.First);

                if (apiRequest.APIReturnedSuccess)
                    Debug.WriteLine("License status successfully updated to Active");
                else
                    Debug.WriteLine("Error setting status: " + apiRequest.ToString);
            }
            else
                Debug.WriteLine("Error activating license: " + apiRequest.ToString);
        }
        else
            Debug.WriteLine("No more activations allowed on this License. Activations: " + apiRequest.Licences.First.TimesActivated + " of " + apiRequest.Licences.First.TimesActivatedMax);
    }
    else
        Debug.WriteLine("Error validating license: " + apiRequest.ToString);

    // REDUCE ACTIVATION COUNT (customer deactivates license on one machine)
    apiInterface.LicenseRequest(LicenseRequestType.Deactivate, LicenseKey);

    // CHECK LICENSE STATUS (periodic app check that license hasn't been set to inactive by licensor)
    if (apiInterface.LicenseRequest(LicenseRequestType.Retrieve, LicenseKey).Licences.First.Status == LicenseStatus.Inactive)
        Debug.WriteLine("App disabled due to license being set to inactive by licensor");
```
# Post-Script
Thanks go to the bugger who americanised the English word "licence." I've had so much fun retyping this a million times during this project. Stop appropriating language!!
