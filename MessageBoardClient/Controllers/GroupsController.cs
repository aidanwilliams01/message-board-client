using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers;

public class GroupsController : Controller
{
  // clicking on a group should lead to the message index for that group
  public IActionResult Index()
  {
    List<Group> groups = Group.GetGroups();
    return View(groups);
  }
}