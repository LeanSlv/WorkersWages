set /p mgr=Migration name: 
dotnet ef migrations add %mgr% -p ../WorkersWages.API
PAUSE