using System.Threading.Tasks;
using System.Collections.Generic;

using TrainingContentCatalog.Models;

namespace TrainingContentCatalog.Common
{
  public interface ITrainingContentSearch
  {
    Task<IEnumerable<ContentItem>> Search(string searchText);
  }
}