using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Implements;

namespace SA.OnlineStore.Bussines.Components.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        [TestMethod()]
        public void GetProduct_InValidId_null()
        {
            var reMoq = new Moq.Mock<IRepository<Product>>();
            ProductService ps = new ProductService(reMoq.Object);

            var actual = ps.GetProduct(-1);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void GetProduct_validId_returnProduct()
        {
            var reMoq = new Moq.Mock<IRepository<Product>>();
            reMoq.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return new Product()
                {
                    Id = id
                };
            });
            ProductService ps = new ProductService(reMoq.Object);
            var actual = ps.GetProduct(7);
            Assert.AreEqual(7, actual.Id);
            reMoq.Verify(r => r.GetById(It.IsAny<int>()), Times.Once);
        } 
    }
}