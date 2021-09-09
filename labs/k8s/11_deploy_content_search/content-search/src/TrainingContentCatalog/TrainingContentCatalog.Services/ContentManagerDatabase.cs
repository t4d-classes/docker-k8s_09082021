using System.Collections.Generic;
using System.Threading.Tasks;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Models;
using TrainingContentCatalog.DataAccess.Services;

namespace TrainingContentCatalog.Services
{
  public class ContentManagerDatabase : IContentManager
  {
    private CatalogItems _catalogItems;
    private CatalogLookups _catalogLookups;

    public ContentManagerDatabase(
      CatalogItems catalogItems,
      CatalogLookups catalogLookups
    )
    {
      _catalogItems = catalogItems;
      _catalogLookups = catalogLookups;
    }

    public Task<IEnumerable<ContentItem>> All()
    {
      return _catalogItems.All();
    }

    public Task<ContentItem> One(string contentItemId)
    {
      return _catalogItems.One(contentItemId);
    }

    public Task<string> Append(ContentItem contentItem)
    {
      return _catalogItems.Append(contentItem);
    }

    public Task Replace(ContentItem contentItem)
    {
      return _catalogItems.Replace(contentItem);
    }

    public Task Remove(string contentItemId)
    {
      return _catalogItems.Remove(contentItemId);
    }

    public Task Activate(string contentItemId)
    {
      return _catalogItems.Activate(contentItemId);
    }

    public Task Deactivate(string contentItemId)
    {
      return _catalogItems.Deactivate(contentItemId);
    }

    public Task<IEnumerable<Organization>> AllPublishers()
    {
      return _catalogLookups.AllPublishers();
    }

    public Task<IEnumerable<Person>> AllAuthors()
    {
      return _catalogLookups.AllAuthors();
    }

    public Task<IEnumerable<string>> AllFormats()
    {
      return _catalogLookups.AllFormats();
    }

    public Task<IEnumerable<string>> AllTags()
    {
      return _catalogLookups.AllTags();
    }

  }


}