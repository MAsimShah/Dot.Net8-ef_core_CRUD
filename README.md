# Identity

ASP.NET Core Identity is the membership system for building ASP.NET Core web applications, including membership, login, and user data. ASP.NET Core Identity allows you to add login features to your application and makes it easy to customize data about the logged in user. You can find additional information in the [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/security/authentication/identity).

## Description

The following contains a description of each sub-directory in the `Identity` directory.

* `Core`: Contains the main abstractions and types for providing support for Identity in ASP.NET Core applications.
* `EntityFrameworkCore`: Contains implementations for Identity stores based on EntityFrameworkCore.
* `Extensions.Core`: Contains the abstractions and types for general Identity concerns.
* `Extensions.Stores`: Contains abstractions and types for Identity storage providers.
* `samples`: Contains a collection of sample apps.
* `Specification.Tests`: Contains a test suite for ASP.NET Core Identity store implementations.
* `test`: Contains the unit and functional tests for Microsoft.Extensions.Identity and Microsoft.AspNetCore.Identity components.
* `testassets`: Contains a webapp used for functional testing.
* `UI`: Contains compiled Razor UI components for use in ASP.NET Core Identity.
