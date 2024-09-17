using Microsoft.AspNetCore.Mvc;
using DEMOMVC.Models;
namespace DEMOMVC.Controllers{
    public class PersonController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }
        [HttpPost]
                public IActionResult Index (Person ps)
        {
            string strResult = "Xin chao" + ps.PersonId + "_" + ps.FullName + "_" + ps.Address; 
            ViewBag.inforPerson = strResult;
            return View();
        }

    }
}