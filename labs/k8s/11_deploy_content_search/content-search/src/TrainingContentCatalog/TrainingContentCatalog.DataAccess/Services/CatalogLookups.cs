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
  public class CatalogLookups
  {
    private readonly string _collectionName = "catalogItems";
    private readonly TrainingCatalogDbContext _dbContext;
    private readonly IMongoCollection<CatalogItem> _trainingContentCollection;
    private readonly IMapper _mapper = ModelMapper.CreateMapper();

    public CatalogLookups(TrainingCatalogDbContext dbContext)
    {
      _dbContext = dbContext;
      _trainingContentCollection = _dbContext.TrainingCatalogDb
        .GetCollection<CatalogItem>(_collectionName);
    }

    public async Task<IEnumerable<PersonModel>> AllAuthors()
    {
      var results = await _trainingContentCollection
        .Distinct(c => c.Author, new BsonDocument())
        .ToListAsync();

      return results
        .Select(author => _mapper.Map<PersonDataModel, PersonModel>(author));
    }

    public async Task ReplaceAuthor(PersonModel author)
    {
      var authorObjectId = new ObjectId(author.Id);
      var filter = Builders<CatalogItem>.Filter.Where(item => item.Author.Id == authorObjectId);
      var updateAuthor = Builders<CatalogItem>.Update.Set(
        "author", _mapper.Map<PersonModel, PersonDataModel>(author));
      await _trainingContentCollection.UpdateManyAsync(filter, updateAuthor);
    }

    public async Task<IEnumerable<OrganizationModel>> AllPublishers()
    {
      var results = await _trainingContentCollection
        .Distinct(c => c.Publisher, new BsonDocument())
        .ToListAsync();

      return results
        .Select(c => _mapper.Map<OrganizationDataModel, OrganizationModel>(c));
    }

    public async Task ReplacePublisher(OrganizationModel publisher)
    {
      var publisherObjectId = new ObjectId(publisher.Id);
      var filter = Builders<CatalogItem>.Filter.Where(item => item.Publisher.Id == publisherObjectId);
      var updatePublisher = Builders<CatalogItem>.Update.Set(
        "publisher", _mapper.Map<OrganizationModel, OrganizationDataModel>(publisher));
      await _trainingContentCollection.UpdateManyAsync(filter, updatePublisher);
    }

    public async Task<IEnumerable<string>> AllFormats()
    {
      return await _trainingContentCollection
        .Distinct(c => c.Format, new BsonDocument())
        .ToListAsync();
    }

    public async Task<IEnumerable<string>> AllTags()
    {
      var results = await _trainingContentCollection
        .Find(new BsonDocument()).ToListAsync();

      return results
        .SelectMany(contentItem => contentItem.Tags)
        .Distinct()
        .OrderBy(t => t);
    }   
  }
}