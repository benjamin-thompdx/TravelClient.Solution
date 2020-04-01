using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers
{
  public class UsersController : Controller
  {
    public IActionResult Index()
    {
      var allUsers = User.GetUsers();
      return View(allUsers);
    }

    [HttpPost]
    public IActionResult Index(Use user)
    {
      Use.Post(user);
      return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
      User.Post(user);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var user = User.GetDetails(id);
      return View(user);
    }

    public IActionResult Edit(int id)
    {
      var user = User.GetDetails(id);
      return View(user);
    }

    [HttpPost]
    public IActionResult Details(int id, user user)
    {
      user.UserId = id;
      User.Put(user);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id, User user)
    {
      user.UserId = id;
      return View(user);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      user.Delete(id);
      return RedirectToAction("Index");
    }
  }
}