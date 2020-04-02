using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;


namespace TravelClient.Controllers
{
  public class MyUsersController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Index(MyUser myUser)
    {
      MyUser.Post(myUser);
      return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(MyUser myUser)
    {
      MyUser.Post(myUser);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var myUser = MyUser.GetDetails(id);
      return View(myUser);
    }

    public IActionResult Edit(int id)
    {
      var myUser = MyUser.GetDetails(id);
      return View(myUser);
    }

    [HttpPost]
    public IActionResult Details(int id, MyUser myUser)
    {
      myUser.MyUserId = id;
      MyUser.Put(myUser);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id, MyUser myUser)
    {
      myUser.MyUserId = id;
      return View(myUser);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      MyUser.Delete(id);
      return RedirectToAction("Index");
    }
  }
}