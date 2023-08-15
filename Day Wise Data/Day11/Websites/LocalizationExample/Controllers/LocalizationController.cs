using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace LocalizationExample.Controllers
{
    public class LocalizationController : Controller
    {
        //private readonly IStringLocalizer<LocalizationController> _localizer;
        private readonly IHtmlLocalizer<LocalizationController> _localizer;

        //public LocalizationController(IStringLocalizer<LocalizationController> localizer)
        public LocalizationController(IHtmlLocalizer<LocalizationController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewBag.Greeting = _localizer["Greeting"];
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}

