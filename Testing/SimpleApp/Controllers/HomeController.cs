using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource DataSource { get; set; } = new ProductDataSource();

        public ViewResult Index()
        {
            return View(DataSource.Products);
        }
    }
}
