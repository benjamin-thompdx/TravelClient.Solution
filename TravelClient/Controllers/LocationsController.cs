using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers
{
  public class LocationsController : Controllers
  {
    public IActionResult Index()
    {
      var allLocations = Location.GetLocations();
      return View(allLocations);
    }

    [HttpPost]
    public IActionResult Index(Location location)
    {
      Location.Post(location)
      return RedirectToAction("Index");
    }
  }
}