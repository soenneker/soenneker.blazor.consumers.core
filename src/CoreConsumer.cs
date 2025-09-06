using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.Consumers.Core.Abstract;

namespace Soenneker.Blazor.Consumers.Core;

///<inheritdoc cref="ICoreConsumer"/>
public class CoreConsumer : ICoreConsumer
{
    protected readonly IApiClient ApiClient;
    protected readonly ILogger<CoreConsumer> Logger;

    protected readonly string PrefixUri;

    protected readonly bool LogRequest = false;
    protected readonly bool LogResponse = false;

    protected CoreConsumer(IApiClient apiClient, ILogger<CoreConsumer> logger, string prefixUri)
    {
        ApiClient = apiClient;
        Logger = logger;
        PrefixUri = prefixUri;
    }
}
