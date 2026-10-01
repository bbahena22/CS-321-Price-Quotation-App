using Microsoft.AspNetCore.Mvc;
using PriceQuotation = PriceQModel.Models.PriceQModel;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new PriceQuotation());
    }

    [HttpPost]
    public IActionResult Index(PriceQuotation model)
    {
        if (ModelState.IsValid)
        {
            model.CalculatePriceQ();
        }

        return View(model);
    }
}