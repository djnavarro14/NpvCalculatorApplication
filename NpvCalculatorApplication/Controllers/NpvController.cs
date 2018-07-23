using NpvCalculatorApplication.Models;
using System.Web.Mvc;

namespace NpvCalculatorApplication.Controllers
{
    public class NpvController : Controller
    {
        public ActionResult Index()
        {
            return View(new NpvObjectModel());
        }
    }
}