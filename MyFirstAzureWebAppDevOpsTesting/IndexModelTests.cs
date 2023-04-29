using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyFirstAzureWebApp.Pages.Tests
{
    [TestClass()]
    public class IndexModelTests
    {
        private readonly IndexModel _indexModel;

        public IndexModelTests()
        {
            _indexModel = new IndexModel(null, null);
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(12, _indexModel.Add(6, 6));
        }
    }
}