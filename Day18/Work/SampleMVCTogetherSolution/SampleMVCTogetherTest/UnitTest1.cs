using NUnit.Framework;
using SampleMVCTogetherApp;
using SampleMVCTogetherApp.Models;
using SampleMVCTogetherApp.Services;

namespace SampleMVCTogetherTest
{
    public class Tests
    {
        IRepo<string, User> _repo;
        [SetUp]
        public void Setup()
        {
            //arrange
            _repo = new UserTempService();
        }

        [Test]
        public void SimpleTest()
        {
            //act
            var result = _repo.Remove("3");
            //assert
            Assert.IsTrue(result);
        }
    }
}