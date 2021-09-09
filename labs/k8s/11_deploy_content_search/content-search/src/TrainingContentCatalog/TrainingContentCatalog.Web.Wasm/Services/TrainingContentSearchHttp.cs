using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Models;

namespace TrainingContentCatalog.Web.Wasm.Services {

  public class TrainingContentSearchHttp : ITrainingContentSearch
  {
    private HttpClient _httpClient;

    public TrainingContentSearchHttp(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IEnumerable<ContentItem>> Search(string searchText)
    {
      var url = $"api/TrainingContentSearch/{Uri.EscapeDataString(searchText)}";
      return await _httpClient.GetFromJsonAsync<IEnumerable<ContentItem>>(url);
    }
  }


}