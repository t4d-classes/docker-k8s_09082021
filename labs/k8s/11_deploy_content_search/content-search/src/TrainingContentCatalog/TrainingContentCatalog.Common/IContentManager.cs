using System.Threading.Tasks;
using System.Collections.Generic;

using TrainingContentCatalog.Models;

namespace TrainingContentCatalog.Common
{
  public interface IContentManager
  {
    Task<IEnumerable<ContentItem>> All();
    Task<ContentItem> One(string contentItemId);
    Task<string> Append(ContentItem contentItem);
    Task Replace(ContentItem contentItem);
    Task Remove(string contentItemId);
    Task Activate(string contentItemId);
    Task Deactivate(string contentItemId);
    Task<IEnumerable<Person>> AllAuthors();
    Task<IEnumerable<Organization>> AllPublishers();
    Task<IEnumerable<string>> AllFormats();
    Task<IEnumerable<string>> AllTags();
  }
}