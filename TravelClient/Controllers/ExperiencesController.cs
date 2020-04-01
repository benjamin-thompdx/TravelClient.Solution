using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelClient.Controllers
{
  public class ExperiencesController : Controller
  {
    public IActionResult Index()
    {
      var allExperiences = Experience.Get();
      return View(allExperiences);
    }

    [HttpPost]
    public IActionResult Index(Experience experience)
    {
      Experience.Post(experience);
      return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
      ViewBag.LocationId = new SelectList(Location.GetLocations(), "LocationId", "Name");
      return View();
    }

    [HttpPost]
    public IActionResult Create(Experience experience)
    {
      Experience.Post(experience);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var experience = Experience.GetDetails(id);
      return View(experience);
    }

    public IActionResult Edit(int id)
    {
      var experience = Experience.GetDetails(id);
      return View(experience);
    }

    [HttpPost]
    public IActionResult Details(int id, Experience experience)
    {
      experience.ExperienceId = id; 
      Experience.Put(experience);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      var experience = Experience.GetDetails(id);
      return View(id);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Experience.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
