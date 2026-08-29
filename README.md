[![](https://img.shields.io/nuget/v/soenneker.blazor.consumers.core.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.consumers.core/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.consumers.core/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.consumers.core/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.consumers.core.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.consumers.core/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.consumers.core/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.consumers.core/actions/workflows/codeql.yml)

# Soenneker.Blazor.Consumers.Core

The minimal base class for building a custom Blazor API consumer around `IApiClient`, a logger, and a resource URI prefix.

This package does not provide CRUD methods or a DI registrar. Use `Soenneker.Blazor.Consumers.Base` for generic CRUD operations or `Soenneker.Blazor.Consumer` when one response type applies across a consumer.

## Installation

```bash
dotnet add package Soenneker.Blazor.Consumers.Core
```

## Define a low-level consumer

```csharp
using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.Consumers.Core;

public sealed class HealthConsumer : CoreConsumer
{
    public HealthConsumer(
        IApiClient apiClient,
        ILogger<CoreConsumer> logger)
        : base(apiClient, logger, "health")
    {
    }

    public async ValueTask<bool> IsHealthy(
        CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await ApiClient.Get(
            PrefixUri,
            allowAnonymous: true,
            cancellationToken: cancellationToken);

        return response.IsSuccessStatusCode;
    }
}
```

```csharp
using Soenneker.Blazor.ApiClient.Registrars;

builder.Services.AddApiClientAsScoped();
builder.Services.AddScoped<HealthConsumer>();
```

Initialize the scoped `IApiClient` with the application's API base address before sending a request. The core constructor rejects null dependencies and blank prefixes, and removes trailing `/` characters from the prefix. Derived consumers own the `HttpResponseMessage` values returned by `ApiClient` and must dispose them.
