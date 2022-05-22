# Product Management
A single service api for product management

# .Net SDK
- Download and istall the .NET SDK
  > https://dotnet.microsoft.com/download

# Configuration
- You should configure <code>appsettings.json</code> for your credential;
- PMDbConnection for MSSQL Connection string
- JwtAuthentication->SecretKey for your JWT Secret key
- RedisConfiguration for caching on redis server
- Serilog for logging in MSSQL

# Visual Studio
- Simply open the solution file <code>ProductManagement.sln</code> 
  > and wait for project restore. 
  > then build/run.
 
# Migration
- Run migration to gain access to the seeded data
- For Package Manager Console Visual Studio 
  > Update-Database
 
# Launch
- To launch the project
  > dotnet run --project ProductManagement.API (on the CLI or Package Manager Console)