dotnet restore
dotnet build
dotnet test .\test\Webenable.Logging.JavaScript.Tests
dotnet pack .\src\Webenable.Logging.JavaScript -c Release -o .\artifacts