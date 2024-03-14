using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers;

// add authentication with identity?

public class MessagesController : Controller
{
  [Route("[controller]/Index/{group}")]
  public IActionResult Index(string group, string earlierDateTime, string laterDateTime)
  {
    List<Message> messages = Message.GetMessages(group, earlierDateTime, laterDateTime);
    ViewBag.Group = group;
    return View(messages);
  }

  public IActionResult Details(int id)
  {
    Message message = Message.GetDetails(id);
    return View(message);
  }

  public ActionResult Create(string group)
  {
    ViewBag.Group = group;
    return View();
  }

  [HttpPost]
  public ActionResult Create(Message message)
  {
    Message.Post(message);
    return RedirectToAction("Index", "Messages", new { group = $"{message.Group}" }, null);
  }

  public ActionResult Edit(int id)
  {
    Message message = Message.GetDetails(id);
    return View(message);
  }

  [HttpPost]
  public ActionResult Edit(Message message)
  {
    Message.Put(message);
    return RedirectToAction("Details", new { id = message.MessageId});
  }

  public ActionResult Delete(int id)
  {
    Message message = Message.GetDetails(id);
    return View(message);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    string messageUserName = Message.GetDetails(id).UserName;
    string messageGroup = Message.GetDetails(id).Group;
    Message.Delete(id, messageUserName);
    return RedirectToAction("Index", "Messages", new { group = $"{messageGroup}" }, null);
  }
}