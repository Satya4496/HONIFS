./build-image.ps1 -ProjectPath "../../src/HONIFS.DbMigrator/HONIFS.DbMigrator.csproj" -ImageName honifs/dbmigrator
./build-image.ps1 -ProjectPath "../../src/HONIFS.HttpApi.Host/HONIFS.HttpApi.Host.csproj" -ImageName honifs/httpapihost
./build-image.ps1 -ProjectPath "../../angular" -ImageName honifs/angular -ProjectType "angular"
