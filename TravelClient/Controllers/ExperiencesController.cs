using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using TravelClient.Models;

namespace CretaceousClient.Controllers
{
  public class ExperiencesController : Controller
  {
    public IActionResult Index()
    {
      var allExperiences = Experience.GetExperiences();
      return View(allExperiences);
    }

    [HttpPost]
    public IActionResult Index(Experience experience)
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
      Experience.Put(Experience);
      return RedirectToAction("Details", id);
    }

    public InictionResult Delete(int id)
    {
      Experience.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
