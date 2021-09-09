
using System.Collections.Generic;
using System.Threading.Tasks;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Models;
using TrainingContentCatalog.DataAccess.Services;

namespace TrainingContentCatalog.Services {

  public class TrainingContentSearchDatabase : ITrainingContentSearch
  {
    private CatalogItems _catalogItems;

    public TrainingContentSearchDatabase(CatalogItems catalogItems)
    {
      _catalogItems = catalogItems;
    }

    public Task<IEnumerable<ContentItem>> Search(string searchText)
    {
      return _catalogItems.Search(searchText);
    }
  }


}