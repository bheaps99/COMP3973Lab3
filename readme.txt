dotnet restore
dotnet build
dotnet watch run

dotnet tool install -g dotnet-aspnet-codegenerator

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet tool update -g dotnet-aspnet-codegenerator

dotnet aspnet-codegenerator view myView Empty -udl -outDir Views/Home

dotnet aspnet-codegenerator controller -name ExampleController -actions -api -outDir Controllers