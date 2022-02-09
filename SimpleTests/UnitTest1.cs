using Xunit;

namespace SimpleApp.Test {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            Assert.True(1 == 0);
        }

        [Fact]
        public void Test2() {
            Assert.True(1 == 1);
        }
    }
}