using Moq;
using NUnit.Framework;
using PassingInputAssignmentApp.Controllers;
using PassingInputAssignmentApp.Models;
using PassingInputAssignmentApp.Services;

namespace TestProject1
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void RetrieveProduct()
        {
            //arrange
            Mock<ProductRepo> mockRepo = new Mock<ProductRepo>();
            mockRepo.Setup(x => x.Get(101)).Returns(new Product() { Id = 101, Name = "Poopoo", Category = "Food", Price = 10.2, Quantity = 2, Pic = "bb", Description = "blahhhhahhahaha" });
            ProductService service = new ProductService(mockRepo.Object);
            Product product=new Product() { Id = 101 };

            //act
            var resultProduct = service.ProductCheck(product);

            //assert
            Assert.IsNotNull(resultProduct);
        }

        [Test]
        public void CreateProduct()
        {
            Product newProduct = new Product { Id = 102, Name = "newbook", Category = "Book", Price = 10.2, Quantity = 2, Pic = "bb", Description = "blahhhhahhahaha" };
            //arrange
            Mock<ProductRepo> mockRepo = new Mock<ProductRepo>();
            mockRepo.Setup(x => x.Add(newProduct)).Returns(new Product() { Id = 101, Name = "Poopoo", Category = "Food", Price = 10.2, Quantity = 2, Pic = "bb", Description = "blahhhhahhahaha" });
            ProductService service = new ProductService(mockRepo.Object);
            Product product = new Product() { Id = 101 };

            //act
            var resultProduct = service.ProductCheck(product);

            //assert
            Assert.IsNotNull(resultProduct);
        }
    }
}