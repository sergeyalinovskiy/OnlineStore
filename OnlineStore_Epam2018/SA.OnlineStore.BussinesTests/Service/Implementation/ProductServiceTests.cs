using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SA.OnlineStore.Common.Cache;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Implements;
using SA.OnlineStore.DataAccess.Service;
using System.Collections.Generic;

namespace SA.OnlineStore.Bussines.Components.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        [TestMethod()]
        public void GetProduct_InValidId_null()
        {
            var reMoq = new Moq.Mock<IProductRepository>();
            var cache = new Mock<IStoreCache>();

            ProductService ps = new ProductService(reMoq.Object, cache.Object);

            var actual = ps.GetProduct(-1);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void GetProduct_validId_returnProduct()
        {
            var reMoq = new Moq.Mock<IProductRepository>();
            var cache = new Mock<IStoreCache>();
            reMoq.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return new Product()
                {
                    Id = id
                };
            });
            ProductService ps = new ProductService(reMoq.Object, cache.Object);
            var actual = ps.GetProduct(7);
            Assert.AreEqual(7, actual.Id);
            reMoq.Verify(r => r.GetById(It.IsAny<int>()), Times.Once);
        } 

        [TestMethod]
        public void CreateProduct_validValue_returnProduct()
        {
            var reMoq = new Moq.Mock<IProductRepository>();
            var cache = new Mock<IStoreCache>();
            ProductService ps = new ProductService(reMoq.Object, cache.Object);

            Product product = new Product()
            {
                Id = 0,
                Name = "Name",
                Category = new Category()
                {
                    CategoryId = 14
                },
                Season = new Season()
                {
                    SeasonId = 2
                },
                Picture = "picture_default.jpg",
                Description = "wqe",
                Count = 10,
                Price = 10
            };
            var actual = ps.SaveProduct(product);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CreateProduct_inValidValue_returnFalse()
        {
            var reMoq = new Moq.Mock<IProductRepository>();
            var cache = new Mock<IStoreCache>();
            ProductService ps = new ProductService(reMoq.Object, cache.Object);

            Product product = null;
            var actual = ps.SaveProduct(product);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void EditProduct_InValidValue_returnFalse()
        {
            var reMoq = new Moq.Mock<IProductRepository>();
            var cache = new Mock<IStoreCache>();
            ProductService ps = new ProductService(reMoq.Object, cache.Object);
            Product product = new Product();
            ps.EditProduct(product);
            Assert.AreEqual(product, product);
        }

        [TestMethod]
        public void EditProduct_ValidValue_returnTrue()
        {
            var reMoq = new Moq.Mock<IProductRepository>();
            var cache = new Mock<IStoreCache>();
            ProductService ps = new ProductService(reMoq.Object, cache.Object);
            reMoq.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return new Product()
                {
                    Id = 0,
                    Name = "Name",
                    Category = new Category()
                    {
                        CategoryId = 14
                    },
                    Season = new Season()
                    {
                        SeasonId = 2
                    },
                    Picture = "picture_default.jpg",
                    Description = "wqe",
                    Count = 10,
                    Price = 10
                };
            });

            var product= ps.GetProduct(10);
            product.Category.CategoryId = 14;
            ps.EditProduct(product);

            var editProduct = ps.GetProduct(10);

            Assert.AreNotEqual(product, editProduct);
        }

        [TestMethod]
        public void SearchingProductLIst_ValidValue_productList()
        {
            var reMoq = new Moq.Mock<IProductRepository>();
            var cache = new Mock<IStoreCache>();
            ProductService ps = new ProductService(reMoq.Object, cache.Object);
            reMoq.Setup(r => r.SearchProducts(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns((string name,int category,int minValue,int maxValue) =>
            {
                return new List<Product>()
                {
                     new Product()
                     {
                        Name = name,
                        Category = new Category()
                        {
                            CategoryId = category
                        }
                     }
                };
            });
            var actual = ps.SearchProducts("", 0, 1, 2);
            Assert.AreNotEqual(null, actual);
        }
    }
}