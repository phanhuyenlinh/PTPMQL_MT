using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string MaSinhVien, string HoTen)
    {
        string strResult = MaSinhVien + "-" + HoTen;
        ViewBag.Info = strResult;
        return View();
    }
}