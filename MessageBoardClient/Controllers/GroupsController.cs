using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers;

public class GroupsController : Controller
{
  public IActionResult Index()
  {
    List<Group> groups = Group.GetGroups();
    return View(groups);
  }
}