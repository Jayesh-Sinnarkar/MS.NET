using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        //Default/Index/100/1/2/3

        //Default/Index/100?a=1&b=2&c=3
        //Default/Index/100?a=1&c=3
        //Default/Index/100?c=3


        public IActionResult Index(int? id, int? a, int? b, int c=0)
        {
            //if(id==null)
            //    return NotFound();
            ViewBag.id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

            return View();
        }
        public IActionResult XYZ()
        {
            return View("SomeOtherName");
        }
    }
}
