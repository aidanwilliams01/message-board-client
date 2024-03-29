using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardClient.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Text { get; set; }
    public string Group { get; set; }
    public DateTime MessageDateTime { get; set; } = DateTime.Now;
    public string UserName { get; set; }

    public static List<Message> GetMessages(string group, string earlierDateTime, string laterDateTime)
    {
      var apiCallTask = ApiHelper.GetAll(group, earlierDateTime, laterDateTime);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messageList;
    }

    public static Message GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

      return message;
    }

    public static void Post(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      ApiHelper.Post(jsonMessage);
    }

    public static void Put(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      ApiHelper.Put(message.MessageId, message.UserName, jsonMessage);
    }

    public static void Delete(int id, string userName)
    {
      ApiHelper.Delete(id, userName);
    }
  }
}