using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using assignment_chefs_n_dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_chefs_n_dishes.Controllers
{
  public class HomeController : Controller
  {
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
      _logger = logger;
      _context = context;
    }


    public IActionResult Index()
    {
      return RedirectToAction("Chefs");
    }

    [HttpGet("/chefs")]
    public IActionResult Chefs()
    {
      return View();
    }
    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
      return View();
    }
    [HttpGet("/chefs/new")]
    public IActionResult NewChef()
    {
      return View();
    }
    [HttpGet("/dishes/new")]
    public IActionResult NewDish()
    {
      return View();
    }

    /////////////////

    [HttpPost("chefs/create")]
    public IActionResult AddChef(Chef newChef)
    {
      if (ModelState.IsValid)
      {
        _context.Chefs.Add(newChef);
        _context.SaveChanges();

        ViewBag.AllChefs = _context.Chefs.OrderBy(a => a.FirstName).ToList();
        ViewBag.AllDishes = _context.Dishes.OrderBy(a => a.Name).ToList();
        return RedirectToAction("Chefs");
      }
      else
      {
        ViewBag.AllChefs = _context.Chefs.OrderBy(a => a.FirstName).ToList();
        ViewBag.AllDishes = _context.Dishes.OrderBy(a => a.Name).ToList();
        return View("NewChef");
      }
    }
    [HttpPost("dishes/create")]
    public IActionResult AddDish(Dish newDish)
    {
      if (ModelState.IsValid)
      {
        _context.Dishes.Add(newDish);
        _context.SaveChanges();

        ViewBag.AllChefs = _context.Chefs.OrderBy(a => a.FirstName).ToList();
        ViewBag.AllDishes = _context.Dishes.OrderBy(a => a.Name).ToList();
        return RedirectToAction("Dishes");
      }
      else
      {
        ViewBag.AllChefs = _context.Chefs.OrderBy(a => a.FirstName).ToList();
        ViewBag.AllDishes = _context.Dishes.OrderBy(a => a.Name).ToList();
        return View("NewDish");
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
