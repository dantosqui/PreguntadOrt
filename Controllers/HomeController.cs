using Microsoft.AspNetCore.Mvc;

namespace PreguntadOrt.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
