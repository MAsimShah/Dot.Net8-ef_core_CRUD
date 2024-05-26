ASP.NET Core
============

[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://www.dotnetfoundation.org/)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt) [![Help Wanted](https://img.shields.io/github/issues/dotnet/aspnetcore/help%20wanted?color=%232EA043&label=help%20wanted&style=flat-square)](https://github.com/dotnet/aspnetcore/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22) [![Good First Issues](https://img.shields.io/github/issues/dotnet/aspnetcore/good%20first%20issue?

ASP.NET Core is an open-source and cross-platform framework for building modern cloud-based internet-connected applications, such as web apps, IoT apps, and mobile backends. ASP.NET Core apps run on [.NET](https://dot.net), a free, cross-platform, and open-source application runtime. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac, and Linux. [Learn more about ASP.NET Core](https://learn.microsoft.com/aspnet/core/).

## Get started

Follow the [Getting Started](https://learn.microsoft.com/aspnet/core/getting-started) instructions.

Also check out the [.NET Homepage](https://www.microsoft.com/net) for released versions of .NET, getting started guides, and learning resources.

# Identity

ASP.NET Core Identity serves as the foundation for constructing ASP.NET Core web applications, encompassing membership, login, and user data functionalities. It empowers developers to seamlessly integrate login capabilities into their applications while offering flexibility in tailoring user-specific data. You can find additional information in the [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/security/authentication/identity).

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
