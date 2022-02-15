using Moq;
using NUnit.Framework;
using SampleMVCTogetherApp.Models;
using SampleMVCTogetherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVCTogetherTest
{
    public class UserActionTest
    {
        [Test]
        public void SimpleTest()
        {
            //arrange
            //IRepo<string, User> repo=new UserRepo();

            //LoginService service = new LoginService(repo);
            //User user=new User() { Username="abc",Password="123"};
            ////act
            //var resultuser = service.LoginCheck(user);
            ////assert
            //Assert.Equals(user.Username, resultuser.Username);




            //arrage
            Mock<UserRepo> mockRepo = new Mock<UserRepo>();
            mockRepo.Setup(x => x.Get("test")).Returns(new User() { Username = "test", Password = "lp123" });
            LoginService service = new LoginService(mockRepo.Object);
            User user = new User() { Username = "test", Password = "lp123" };
            //act
            var resultuser = service.LoginCheck(user);
            //assert
            Assert.IsNotNull(resultuser);

        }
    }
}
