# NugetPackager

#### Scripts for generating a NuGet packages for this solution

### Procedure

1 Create a `.nuspec` file from the GambitSDK Project
  * If you have nuget.exe in your `PATH` go to the root of the GambitSDK project and run `nuget spec`
else run the command relative to this directory

  * Edit the .nuspec file as XML with the required information 

2 run `build.bat`

3 run `push-to-nuget.bat`
  * If you don't want to enter the API key each time you run `push-to-nuget` open a terminal and go to **this** directory and run `nuget setApiKey Your-API-Key`
