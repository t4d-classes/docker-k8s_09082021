using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


using AutoMapper;
using MongoDB.Driver;
using MongoDB.Bson;

using TrainingContentCatalog.DataAccess.Models;
using TrainingContentCatalog.Models;

using PersonModel = TrainingContentCatalog.Models.Person;
using PersonDataModel = TrainingContentCatalog.DataAccess.Models.Person;

using OrganizationModel = TrainingContentCatalog.Models.Organization;
using OrganizationDataModel = TrainingContentCatalog.DataAccess.Models.Organization;


namespace TrainingContentCatalog.DataAccess.Services
{
    public class CatalogItems
    {
      private readonly SearchCache _searchCache;

      private readonly string _collectionName = "catalogItems";
      private readonly TrainingCatalogDbContext _dbContext;
      private readonly IMongoCollection<CatalogItem> _trainingContentCollection;
      private readonly IMapper _mapper = ModelMapper.CreateMapper();

      public CatalogItems(
        TrainingCatalogDbContext dbContext,
        SearchCache searchCache)
      {
        _dbContext = dbContext;
        _trainingContentCollection = _dbContext.TrainingCatalogDb
          .GetCollection<CatalogItem>(_collectionName);
        _searchCache = searchCache;
     }

      public async Task<IEnumerable<ContentItem>> Search(string searchText)
      {
        var searchTextLower = searchText.ToLowerInvariant();
        var cachedSearchResults = await _searchCache.GetCachedSearchResults(searchText);

        if (cachedSearchResults is not null)
        {
          return cachedSearchResults;
        }

        var builder = Builders<CatalogItem>.Filter;
        var contains = new BsonRegularExpression(
          new Regex($".*{searchText}.*", RegexOptions.IgnoreCase));

        var searchTextFilter = builder.Regex("title", contains) | 
          builder.Regex("description", contains) |
          builder.Where(item => item.Tags.Any(tag => tag == searchTextLower));

        var activeFilter = builder.Where(item => item.Active);

        var filter = builder.And(searchTextFilter, activeFilter);

        var catalogItemResults = await _trainingContentCollection.Find(filter).ToListAsync();
        var contentItemResults = catalogItemResults
          .Select(c => _mapper.Map<CatalogItem, ContentItem>(c)).ToList();

        await _searchCache.CacheSearchResults(searchText, contentItemResults);

        return contentItemResults;
      }

      public async Task<IEnumerable<ContentItem>> All()
      {
        var results = await _trainingContentCollection.Find(new BsonDocument()).ToListAsync();

        var t = results.ToList();

        return t.Select(c => _mapper.Map<CatalogItem, ContentItem>(c)).ToList();
      }

      private FilterDefinition<CatalogItem> BuildCatalogFilterId(string catalogItemId)
      {
        var catalogItemObjectId = new ObjectId(catalogItemId);
        var builder = Builders<CatalogItem>.Filter;
        var filter = builder.Where(item => item.Id == catalogItemObjectId);
        return filter;
      }

      public async Task<ContentItem> One(string contentItemId)
      {
        var filter = BuildCatalogFilterId(contentItemId);
        var results = await _trainingContentCollection.Find(filter).ToListAsync();
        return results.Select(c => _mapper.Map<CatalogItem, ContentItem>(c)).FirstOrDefault();
      }

      public async Task<string> Append(ContentItem contentItem)
      {
        await _searchCache.ClearCachedSearchResults();

        var catalogItem = _mapper.Map<ContentItem, CatalogItem>(contentItem);
        catalogItem.Id = ObjectId.GenerateNewId();

        await _trainingContentCollection.InsertOneAsync(catalogItem);

        return catalogItem.Id.ToString();
      }

      public async Task Replace(ContentItem contentItem)
      {
        await _searchCache.ClearCachedSearchResults();

        var filter = BuildCatalogFilterId(contentItem.Id);
        await _trainingContentCollection.ReplaceOneAsync(
          filter, _mapper.Map<ContentItem, CatalogItem>(contentItem));
      }

      public async Task Remove(string contentItemId)
      {
        await _searchCache.ClearCachedSearchResults();

        var filter = BuildCatalogFilterId(contentItemId);
        await _trainingContentCollection.DeleteOneAsync(filter);
      }      

      public async Task Activate(string contentItemId)
      {
        await _searchCache.ClearCachedSearchResults();

        var filter = BuildCatalogFilterId(contentItemId);
        var update = Builders<CatalogItem>.Update.Set("active", true);
        await _trainingContentCollection.UpdateOneAsync(filter, update);
      }      

      public async Task Deactivate(string contentItemId)
      {
        await _searchCache.ClearCachedSearchResults();

        var filter = BuildCatalogFilterId(contentItemId);
        var update = Builders<CatalogItem>.Update.Set("active", false);
        await _trainingContentCollection.UpdateOneAsync(filter, update);
      }      
    }
}
