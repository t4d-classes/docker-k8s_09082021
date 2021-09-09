using System;

using MongoDB.Bson;

namespace TrainingContentCatalog.DataAccess.Models
{
  public class Person
  {
    public ObjectId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Uri Url { get; set; }
  }
}