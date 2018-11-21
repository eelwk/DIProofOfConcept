using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class ClassLibrary_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockPrimary = new Mock<IPrimaryInterface>();

            mockPrimary.Setup(p => p.ThisIsAMethod("test", "test")).Returns("test");

            var testClass = new TestClass(mockPrimary.Object);
            string result = testClass.TestMethod("test", "test");

            Assert.AreEqual(result, "test");
        }
    }
}
