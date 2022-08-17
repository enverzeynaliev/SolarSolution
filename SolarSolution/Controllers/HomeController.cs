using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolarSolution.DataLayer.Repositories;
using SolarSolution.Models;

namespace SolarSolution.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStaffRepository _staffRepository;

    public HomeController(ILogger<HomeController> logger, IStaffRepository staffRepository)
    {
        _logger = logger;
        _staffRepository = staffRepository;
    }

    public IActionResult Index()
    {
        return View(_staffRepository.GetRecentBirthdays());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}