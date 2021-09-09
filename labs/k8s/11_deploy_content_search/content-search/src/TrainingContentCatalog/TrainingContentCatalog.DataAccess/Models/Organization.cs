using System;

using MongoDB.Bson;

namespace TrainingContentCatalog.DataAccess.Models
{
  public class Organization
  {
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public Uri Url { get; set; }
  }
}