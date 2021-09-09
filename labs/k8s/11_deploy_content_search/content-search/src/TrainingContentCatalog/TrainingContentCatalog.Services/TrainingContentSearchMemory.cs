using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Models;

namespace TrainingContentCatalog.Services
{
  public class TrainingContentSearchMemory : ITrainingContentSearch
  {
    public Task<IEnumerable<ContentItem>> Search(string searchText)
    {
      List<ContentItem> trainingContentResults = new() {
        new() {
          Id = "61170214f6019600075616d1",
          Title = "New Features in C# 9.0",
          Author = new Person {
            Id = "6124138c2e5e07b0fea6b1c8",
            FirstName = "Eric",
            LastName = "Greene",
            Url = new Uri("https://www.linkedin.com/in/erict4dio/")
          },
          Publisher = new Organization() {
            Id = "6123e8080c54f57ae94f1a03", 
            Name = "WintellectNOW",
            Url = new Uri("https://www.wintellectnow.com"),
          },
          Format = "video",
          Url = new Uri("https://www.wintellectnow.com/Videos/Watch?videoId=new-features-in-c-9.0"),
          Description = "C# 9.0 is chock full of new features to make programming easier and code more concise, from record types to init-only setters. Get up to speed quickly on these and other enhancements that make C# 9.0 the best C# ever!",
          PublishDate = new DateTime(2021, 8, 2),
          Tags = new string[] {
            "C#",
            ".NET",
            "Programming",
          },
        },
        new() {
          Id = "611702b4f6019600075616d3",
          Title = "CI/CD with Azure Pipelines and Artifacts, Part 1",
          Author = new Person {
            Id = "6124138c2e5e07b0fea6b1c8",
            FirstName = "Eric",
            LastName = "Greene",
            Url = new Uri("https://www.linkedin.com/in/erict4dio/")
          },
          Publisher = new Organization() {
            Id = "6123e8080c54f57ae94f1a03", 
            Name = "WintellectNOW",
            Url = new Uri("https://www.wintellectnow.com"),
          },
          Format = "video",
          Url = new Uri("https://www.wintellectnow.com/Videos/Watch?videoId=ci-cd-with-azure-pipelines-and-artifacts-part-1"),
          Description = "In Part 1 of this mini-series within a series, learn how to configure a Web App project in Azure DevOps to support artifacts and deploy it to an Azure Static Web App from a Git repo.",
          PublishDate = new DateTime(2021, 5, 31),
          Tags = new string[] {
            "Azure",
            "Azure DevOps",
            "React",
            "NPM",
            "Node.js",
            "Azure Artifacts",
            "Azure Pipelines",
            "Azure Static Web App",
            "Programming",
            "DevOps"
          },
        },
      };

      return Task.FromResult<IEnumerable<ContentItem>>(
        trainingContentResults.Where(tcr =>
          tcr.Title.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) ||
          tcr.Description.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) ||
          tcr.Tags.Any(t => t.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
        ).ToList());
    }
  }
}
