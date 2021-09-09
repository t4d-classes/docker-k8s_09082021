using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Models;
using TrainingContentCatalog.Services;

namespace TrainingContentCatalog.Web.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TrainingContentSearchController: ControllerBase
  {
    private readonly ITrainingContentSearch _trainingContentSearch;

    public TrainingContentSearchController(ITrainingContentSearch trainingContentSearch)
    {
      _trainingContentSearch = trainingContentSearch;
    }

    [HttpGet("{searchTerm}")]
    public async Task<IEnumerable<ContentItem>> Get(string searchTerm)
    {
      return await _trainingContentSearch.Search(searchTerm);
    }

  }
}