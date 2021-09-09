using System;

namespace TrainingContentCatalog.Models
{
  public class Person
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Uri Url { get; set; }

    public string FullName {
      get {
        return $"{LastName}, {FirstName}";
      }
    }

    public string DisplayName {
      get {
        return $"{FirstName} {LastName}";
      }
    }
  }
}