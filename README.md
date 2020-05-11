# Overview

This is a template (boilerplate) API project with ASP.NET Core.

# Setup

This project is by default configured with Sqlite. Nevertheless you may feel free to make the changes necessary to use another Database management system.

Add the API/appsettings.json file with a configuration similar to the following:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Data source=mydb.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

# Running Project

```
cd API
dotnet watch run
```

# Additional Notes
TODO
