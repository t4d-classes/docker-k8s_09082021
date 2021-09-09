using System;
using System.Collections.Generic;

using MongoDB.Bson;

namespace TrainingContentCatalog.DataAccess.Models
{
  public class CatalogItem
  {
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public Person Author { get; set; }
    public Organization Publisher { get; set; }
    public string Format { get; set; }
    public Uri Url { get; set; }
    public string Description { get; set; }
    public DateTime PublishDate { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public bool Active { get; set; }
  }
}
