using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Models;

namespace TrainingContentCatalog.Web.Wasm.Services
{
  public class ContentManagerHttp : IContentManager
  {
    private HttpClient _httpClient;

    public ContentManagerHttp(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IEnumerable<ContentItem>> All()
    {
      var url = "api/contentmanager";
      return await _httpClient.GetFromJsonAsync<IEnumerable<ContentItem>>(url);
    }

    public async Task<ContentItem> One(string contentItemId)
    {
      var url = "api/contentmanager/" + Uri.EscapeDataString(contentItemId);
      return await _httpClient.GetFromJsonAsync<ContentItem>(url);
    }

    public async Task<string> Append(ContentItem contentItem)
    {
      var url = "api/contentmanager";
      var response = await _httpClient.PostAsJsonAsync(url, contentItem);
      return await response.Content.ReadFromJsonAsync<string>();
    }

    public async Task Replace(ContentItem contentItem)
    {
      var url = "api/contentmanager/" + Uri.EscapeDataString(contentItem.Id);
      await _httpClient.PutAsJsonAsync(url, contentItem);
    }

    public async Task Remove(string contentItemId)
    {
      var url = "api/contentmanager/" + Uri.EscapeDataString(contentItemId);
      await _httpClient.DeleteAsync(url);
    }

    public async Task Activate(string contentItemId)
    {
      var url = "api/contentmanager/activate/" + Uri.EscapeDataString(contentItemId);
      await _httpClient.PostAsync(url, null);
    }

    public async Task Deactivate(string contentItemId)
    {
      var url = "api/contentmanager/deactivate/" + Uri.EscapeDataString(contentItemId);
      await _httpClient.PostAsync(url, null);
    }

    public async Task<IEnumerable<Person>> AllAuthors()
    {
      var url = "api/contentmanager/all_authors";
      return await _httpClient.GetFromJsonAsync<IEnumerable<Person>>(url);
    }

    public async Task<IEnumerable<Organization>> AllPublishers()
    {
      var url = "api/contentmanager/all_publishers";
      return await _httpClient.GetFromJsonAsync<IEnumerable<Organization>>(url);
    }

    public async Task<IEnumerable<string>> AllFormats()
    {
      var url = "api/contentmanager/all_formats";
      return await _httpClient.GetFromJsonAsync<IEnumerable<string>>(url);
    }

    public async Task<IEnumerable<string>> AllTags()
    {
      var url = "api/contentmanager/all_tags";
      return await _httpClient.GetFromJsonAsync<IEnumerable<string>>(url);
    }

  }

}