cd ../
dotnet ef migrations add $1 -p ./Todo.DataAccess/Todo.DataAccess.csproj --startup-project ./Todo.Api/Todo.Presentation.csproj