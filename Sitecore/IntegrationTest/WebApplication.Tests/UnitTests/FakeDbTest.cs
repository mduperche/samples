using Sitecore.FakeDb;
using Xunit;

namespace WebApplication.Tests.UnitTests
{ 
    public class FakeDbTest
    {
        [Fact]
        public void HowToCreateSimpleItem()
        {
            using (var db = new Db
            {
                new DbItem("Home") { { "Title", "Welcome!" } }
            })
            {
                Sitecore.Data.Items.Item home = db.GetItem("/sitecore/content/home");
                Xunit.Assert.Equal("Welcome!", home["Title"]);
            }
        }
    }
}
