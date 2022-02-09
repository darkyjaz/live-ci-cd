using Xunit;

namespace SimpleApp.Tests {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            Assert.True(1 == 1);

        }

        [Fact]
        public void Test2() {
            Assert.True(0 == 0);

        }
    }
}