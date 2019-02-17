using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsParserSite.Core.Implementation;
using NewsParserSite.Core.Interfaces;

namespace NewsParserSite.Core.Test
{
    [TestClass]
    public class SqlNewsRepositoryTest
    {
        private INewsRepository _repo;

        [TestInitialize]
        public void SetupRepo()
        {
            _repo = new SqlNewsRepository();
        }

        [TestMethod]
        public void GetTopTenWordsInNewsTest()
        {
            var result = _repo.GetTopTenWordsInNews();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var result = _repo.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

    }
}
