using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string Name)
    {
        return View();
    }

    [HttpPost("submitform")]
    public IActionResult SubmitForm(string Name)
    {
        HttpContext.Session.SetString("Name", Name);
        HttpContext.Session.SetInt32("Num", 22);
        return RedirectToAction("Main");
    }

    public IActionResult Main()
    {
        return View();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet("plus1")]
    public IActionResult Plus1()
    {
        int? Num = HttpContext.Session.GetInt32("Num");
        Num += 1;
        HttpContext.Session.SetInt32("Num", (int)Num);
        return RedirectToAction("Main");
    }
    [HttpGet("minus1")]
    public IActionResult Minus1()
    {
        int? Num = HttpContext.Session.GetInt32("Num");
        Num -= 1;
        HttpContext.Session.SetInt32("Num", (int)Num);
        return RedirectToAction("Main");
    }
    [HttpGet("times2")]
    public IActionResult Times2()
    {
        int? Num = HttpContext.Session.GetInt32("Num");
        Num = Num * 2;
        HttpContext.Session.SetInt32("Num", (int)Num);
        return RedirectToAction("Main");
    }
    [HttpGet("plusrandom")]
    public IActionResult PlusRandom()
    {
        Random rand = new Random();
        int? Num = HttpContext.Session.GetInt32("Num");
        Num = Num + rand.Next(0, 11);
        HttpContext.Session.SetInt32("Num", (int)Num);
        return RedirectToAction("Main");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
