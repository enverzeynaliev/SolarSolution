using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolarSolution.DataLayer.Repositories;
using SolarSolution.Models;
using SolarSolution.Services;

namespace SolarSolution.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStaffRepository _staffRepository;
    private readonly StaffService _staffService;


    public HomeController(ILogger<HomeController> logger, IStaffRepository staffRepository, StaffService staffService)
    {
        _logger = logger;
        _staffRepository = staffRepository;
        _staffService = staffService;
    }

    public IActionResult Index()
    {
        return View(_staffRepository.GetRecentBirthdays());
    }

    public IActionResult AllStaff()
    {
        return View(_staffRepository.GetAllStaff());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult AddStaff()
    {
        return View("newPerson", new Staff());
    }

    [HttpPost]
    public async Task<IActionResult> AddStaff(AddStaffPerson addStaffPerson)
    {
        await _staffService.AddBirthday(addStaffPerson);
        return RedirectToAction("AllStaff");
    }

    [HttpGet]
    public IActionResult DeletePerson(int id)
    {
        _staffService.DeletePerson(id);
        return RedirectToAction("AllStaff");
    }

    [HttpGet]
    public IActionResult EditPerson(int id)
    {
        var staff = _staffRepository.GetStaffById(id);
        return View("newPerson", staff);
    }

    [HttpPost]
    public async Task<IActionResult> StaffBirthdayEditPost(EditStaffPerson editStaffPerson)
    {
        await _staffService.EditStaff(editStaffPerson);
        return RedirectToAction("AllStaff");
    }
}