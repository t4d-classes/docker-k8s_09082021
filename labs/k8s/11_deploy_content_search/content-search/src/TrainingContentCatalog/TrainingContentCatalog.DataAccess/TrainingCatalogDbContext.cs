using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;


namespace TrainingContentCatalog.DataAccess
{
  public class TrainingCatalogDbContext
  {
    private string _connectionString;
    private IMongoClient _mongoClient;

    public IMongoDatabase TrainingCatalogDb { get; init; }

    public TrainingCatalogDbContext(string connectionString, string databaseName)
    {
      var conventionPack = new ConventionPack {new CamelCaseElementNameConvention()}; 
      ConventionRegistry.Register("camelCase", conventionPack, t => true);
      
      _connectionString = connectionString;
      _mongoClient = new MongoClient(_connectionString);

      TrainingCatalogDb = _mongoClient.GetDatabase(databaseName);
    }
  }

}