# ML Api tool
This is a .NET item template to ease the process of complying with the internal API guidelines in Monstarlab outlined in the (API Manifesto)[].

## NuGet package dependencies
- `Newtonsoft.Json`
- `FluentValidation.AspNetCore`

## How to use
1. Pull repo
2. In your terminal go to ./working/content
3. type `dotnet new install ./` to install the item template
4. To create a new web project create an empty folder, navigate the terminal there and type `dotnet new web`.
5. Apply the template by typing `dotnet new mlapi -P Acme`. The `-P` parameter is your project's name. It will replace a placeholder in various places in the item template.
6. Install dependency `dotnet add package FluentValidation.AspNetCore`
7. Install dependency `dotnet add package Newtonsoft.Json`
8. Configure the webproject to use the included custom exception handler and create initial routes for testing, eg. in ./Program.cs:
```csharp
using Acme.Api.Exceptions;
using Acme.Api.Middleware.Helpers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseCustomExceptionHandler(true);

app.MapGet("/", () => "Hello World!");
app.MapGet("/unauthorized", () => {
    throw new AcmeUnauthorizedAccessApiException("Unauthorized message");
});
app.MapGet("/notfound", () => {
    throw new AcmeNotFoundApiException("Not Found message");
});

app.Run();
```
9. `dotnet build`
10. `dotnet run`
11. Test the endpoints in your browser.
