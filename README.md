 # Custom Clean Architecture Simple Task

This is a solution template for creating a Single Page App (SPA) with Angular 8 and ASP.NET Core 3 following the principles of Clean Architecture. Create a new project based on this template by clicking the above **Use this template** button or by installing and running the associated NuGet package (see Getting Started for full details). 


## Technologies
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* Angular 8

## Getting Started

The easiest way to get started is to install the [NuGet package](https://www.nuget.org/packages/Clean.Architecture.Solution.Template) and run `dotnet new ca-sln`:

1. Install the latest [.NET Core SDK](https://dotnet.microsoft.com/download)
2. Run `dotnet new --install Clean.Architecture.Solution.Template` to install the project template
3. Run `dotnet new ca-sln` to create a new project
4. Navigate to `src/WebUI` and run `dotnet run` to launch the project

### Change Connection String in application.json file
### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

- `--project src/Infrastructure` (optional if in this folder)
- `--startup-project src/WebUI`
- `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\WebUI`

## Support

If you are having problems, please let us know by [raising a new issue](https://github.com/jasontaylordev/Clean_Architecture_Task/issues/new/choose).

## License

This project is licensed with the [MIT license](LICENSE).
