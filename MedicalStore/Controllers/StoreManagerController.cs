using Microsoft.AspNetCore.Mvc;

namespace MedicalStore.Controllers
{
    public class StoreManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
