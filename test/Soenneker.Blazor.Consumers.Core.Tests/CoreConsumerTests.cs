using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Consumers.Core.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class CoreConsumerTests : HostedUnitTest
{

    public CoreConsumerTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
