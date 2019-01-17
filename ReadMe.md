# Design Time Services Loader

Demonstrates adding design-time services for EF Core and Handlebars via reflection.

## Description

**DesignTimeServicesLoader.Net47** is a .NET class library with a `ServicesLoader` class and a `AddTimeServices` that accepts a path to a .NET Standard class library with a class that implements `IDesignTimeServices`, as well as a `IServiceCollection` which is passes to the `ConfigureDesignTimeServices` of the `IDesignTimeServices` class.

> Note: It is imperative that the `IDesignTimeServices` class reside in a .NET Standard library, versus a .NET Core class library, so that a .NET Framework can load types from it.

