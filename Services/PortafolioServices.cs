using PortafolioSLE.Api.Configurations;
using PortafolioSLE.Api.Models;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson ;
namespace PortafolioSLE.Api.Services;

public class PortafolioServices
{
     

    private readonly IMongoCollection<Portafolio> _portafolioCollection;

    public PortafolioServices(IOptions<DatabaseSettings> databasesettings)
    {
        var mongoClient = new MongoClient(databasesettings.Value.ConnectionString);
        var mongoDB = mongoClient.GetDatabase(databasesettings.Value.DatabaseName);

        _portafolioCollection = mongoDB.GetCollection<Portafolio>(databasesettings.Value.CollectionName);
    }

   public async Task<List<Portafolio>> GetAsync()=>
   await _portafolioCollection.Find(p => true).ToListAsync();

   public async Task<Portafolio> GetPortafolioId (string id) 
   {
    return await _portafolioCollection.FindAsync(new BsonDocument
            {{"_id", new ObjectId(id)}}).Result.FirstAsync();
   }


   public async Task InsertPortafolio (Portafolio portafolio)
   {
       await _portafolioCollection.InsertOneAsync(portafolio);
   }

   public async Task UpdatePortafolio (Portafolio portafolio)
   {
       var filter = Builders<Portafolio>.Filter.Eq(p => p.Id, portafolio.Id);
       await _portafolioCollection.ReplaceOneAsync(filter, portafolio);
   }

   public async Task DeletePortafolio (string id)
   {
       var filter = Builders<Portafolio>.Filter.Eq(p => p.Id, id);
       await _portafolioCollection.DeleteOneAsync(filter);
   }    
        
        
    
    
    
         
}

