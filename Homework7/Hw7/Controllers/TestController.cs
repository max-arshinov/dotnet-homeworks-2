using Hw7.Models.ForTests;
using Microsoft.AspNetCore.Mvc;

namespace Hw7.Controllers;

public class TestController : Controller
{
    [HttpGet]
    public IActionResult Test()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Test(TestModel model)
    {
        return View(model);
    }
}