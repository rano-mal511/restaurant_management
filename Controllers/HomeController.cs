using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using restaurant_management.Data;
using restaurant_management.Models;
using restaurant_management.ViewModels;

namespace restaurant_management.Controllers;

public class HomeController : Controller
{
    private readonly RestaurantDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(RestaurantDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var viewModel = new HomeViewModel
        {
            Restaurants = _context.Restaurants.ToList(),
            Tables = _context.Tables.ToList(),
            MenuItems = _context.MenuItems.ToList(),
            Reservations = _context.Reservations.ToList()
        };

        return View(viewModel);
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
