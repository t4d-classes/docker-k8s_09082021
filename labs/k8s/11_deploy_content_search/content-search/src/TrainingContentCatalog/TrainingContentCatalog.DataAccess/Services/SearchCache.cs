using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using StackExchange.Redis;

using TrainingContentCatalog.Models;

namespace TrainingContentCatalog.DataAccess.Services
{

  public class SearchCache : IDisposable
  {
    private bool disposed = false;
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly string _searchTextKeyPrefix = "search_text";

    public SearchCache(string url)
    {
      _connectionMultiplexer = ConnectionMultiplexer.Connect(url);
    }

    private string searchResultsCacheKey(string searchText)
    {
      var searchTextLower = searchText.ToLowerInvariant();
      return $"{_searchTextKeyPrefix}_{searchTextLower}";
    }

    public async Task<IEnumerable<ContentItem>> GetCachedSearchResults(string searchText)
    {
      var db = _connectionMultiplexer.GetDatabase();
      var cachedSearchResults = await db.StringGetAsync(searchResultsCacheKey(searchText));

      if (!cachedSearchResults.IsNullOrEmpty)
      {
        Console.WriteLine("using cached results for " + searchText);
        return JsonSerializer.Deserialize<List<ContentItem>>(cachedSearchResults);
      }
      else
      {
        return null;
      }
    }

    public async Task CacheSearchResults(string searchText, IEnumerable<ContentItem> searchResults)
    {
      var db = _connectionMultiplexer.GetDatabase();
      await db.StringSetAsync(
        searchResultsCacheKey(searchText),
        JsonSerializer.Serialize(searchResults));
    }

    public async Task ClearCachedSearchResults()
    {
      Console.WriteLine("clearing cache");
      var db = _connectionMultiplexer.GetDatabase();
      foreach (var endpoint in _connectionMultiplexer.GetEndPoints())
      {
        var server = _connectionMultiplexer.GetServer(endpoint);
        await foreach (var key in server.KeysAsync(pattern: _searchTextKeyPrefix + "_*"))
        {
          Console.WriteLine("deleting key " + key);
          await db.KeyDeleteAsync(key);
        }
      }
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _connectionMultiplexer.Dispose();
        }
        disposed = true;
      }
    }

    ~SearchCache()
    {
      Dispose(disposing: false);
    }
  }

}