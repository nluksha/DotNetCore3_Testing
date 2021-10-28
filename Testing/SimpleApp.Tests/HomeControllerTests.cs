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
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            var controller = new HomeController();
            var products = new[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M }
            };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            var conparer = Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price);
            Assert.Equal(products, model, conparer);
        }
    }
}
