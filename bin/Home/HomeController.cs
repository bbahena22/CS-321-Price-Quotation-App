using Microsoft.AspNetCore.Mvc;
using FutureValue.Models;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new FutureValueModel());
    }

    [HttpPost]
    public IActionResult Index(FutureValueModel model)
    {
        if (ModelState.IsValid)
        {
            model.CalculateFutureValue();
        }

        return View(model);
    }
}