using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace OldMutual.Scheme.Pages;

public class Index_Tests : SchemeWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
