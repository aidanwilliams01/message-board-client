using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers;

public class MessagesController : Controller
{
  [Route("[controller]/Index/{group}")]
  public IActionResult Index(string group)
  {
    List<Message> messages = Message.GetMessages(group);
    ViewBag.Group = group;
    return View(messages);
  }

  // [Route("[controller]/Details/{id}")]
  public IActionResult Details(int id)
  {
    Message message = Message.GetDetails(id);
    return View(message);
  }

  // [Route("[controller]")]
  public ActionResult Create(string group)
  {
    ViewBag.Group = group;
    // DateTime theDate = DateTime.Now;
    // theDate.ToString("yyyy-MM-dd H:mm:ss");
    // ViewBag.DateTime = theDate;
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