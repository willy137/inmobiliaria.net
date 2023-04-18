using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [Authorize]
    public IActionResult Index()
    {
        try{
            var claims =User.Claims;
            string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            ViewBag.Rol=Rol;
            return View();
        }catch(Exception ex){
            throw;
        }

    }
    [Authorize]
    public IActionResult Privacy()
    {
            var claims =User.Claims;
            string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            ViewBag.Rol=Rol;
        return View();
    }

    public IActionResult Restringido()
    {
            var claims =User.Claims;
            string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            ViewBag.Rol=Rol;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
