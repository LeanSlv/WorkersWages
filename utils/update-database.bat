cd ../
dotnet restore
dotnet tool restore
cd utils/
dotnet ef database update -p ../WorkersWages.API
PAUSE