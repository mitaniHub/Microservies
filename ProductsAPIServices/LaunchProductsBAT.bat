@echo Launch TransactionService

title  TransactionService
dotnet build --configuration "Debug"
set ASPNETCORE_ENVIRONMENT=Development
dotnet run --configuration "Debug" --launch-profile "Project"