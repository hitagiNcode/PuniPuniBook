using Microsoft.AspNetCore.Mvc;

namespace PuniPuniBook.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
