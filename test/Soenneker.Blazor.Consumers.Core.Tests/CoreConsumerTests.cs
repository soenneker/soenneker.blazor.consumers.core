using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blazor.Consumers.Core.Tests;

[Collection("Collection")]
public class CoreConsumerTests : FixturedUnitTest
{

    public CoreConsumerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
