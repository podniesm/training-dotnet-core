using Library;
using Xunit;

namespace LibraryTest
{
    public class TestLibrary
    {
        [Fact]
        public void ThingGetsObjectValFromNumber()
        {
            Assert.Equal(42, new Thing().Get(42));
        }
    }
}
