# Swagger

[![Build Status](https://dev.azure.com/expensely-au/Expensely/_apis/build/status/Libraries/Swagger/Release?branchName=main)](https://dev.azure.com/expensely-au/Expensely/_build/latest?definitionId=62&branchName=main)

| View       | Badge                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|:-----------|:------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Prerelease | [![Expensely.Swagger package in expensely-au@Prerelease feed in Azure Artifacts](https://feeds.dev.azure.com/expensely-au/_apis/public/Packaging/Feeds/4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1@0b477f7e-e363-4441-97f7-bf3189253564/Packages/c03f551a-262e-4836-9eb6-06ed9abf7ec2/Badge)](https://dev.azure.com/expensely-au/Expensely/_packaging?_a=package&feed=4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1%400b477f7e-e363-4441-97f7-bf3189253564&package=c03f551a-262e-4836-9eb6-06ed9abf7ec2&preferRelease=true) |
| Release    | [![Expensely.Swagger package in expensely-au@Release feed in Azure Artifacts](https://feeds.dev.azure.com/expensely-au/_apis/public/Packaging/Feeds/4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1@f9bccf78-9a6f-4e24-bcd7-b5f77186974c/Packages/c03f551a-262e-4836-9eb6-06ed9abf7ec2/Badge)](https://dev.azure.com/expensely-au/Expensely/_packaging?_a=package&feed=4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1%40f9bccf78-9a6f-4e24-bcd7-b5f77186974c&package=c03f551a-262e-4836-9eb6-06ed9abf7ec2&preferRelease=true)    |


## How to Use
### Configuration
Add swagger
``` csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSwagger();
    ...
}
```
Use swagger
``` csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
{
    ...
    app.UseSwagger(provider);
    ...
}
```

## Development
### Build, Package & Release
#### Locally
```
// Step 1: Authenticate
dotnet build --configuration release 

// Step 2: Pack
dotnet pack --configuration release 

// Step 3: Publish
dotnet nuget push "Expensely.Swagger.*.nupkg" -Source "github"
```
