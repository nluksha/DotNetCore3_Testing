using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using SimpleApp.Controllers;
using SimpleApp.Models;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        class FakeDataSource: IDataSource
        {
            public IEnumerable<Product> Products { get; set; }
            public FakeDataSource(Product[] data) => Products = data;
        }


        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            var products = new[] {
                new Product { Name = "P1", Price = 100M },
                new Product { Name = "P2", Price = 200M },
                new Product { Name = "P3", Price = 300M }
            };
            IDataSource dataSource = new FakeDataSource(products);
            var controller = new HomeController() { DataSource = dataSource };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            var conparer = Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price);
            Assert.Equal(products, model, conparer);
        }
    }
}
