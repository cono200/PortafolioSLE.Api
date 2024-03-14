using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PortafolioSLE.Api.Models
{
    public class Portafolio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("NombreProyecto")]
        public string NombreProyecto { get; set; } = string.Empty;

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [BsonElement("Imagen")]
        public string Imagen { get; set; } = string.Empty;

        [BsonElement("Url")]
        public string Url { get; set; } = string.Empty;

        [BsonElement("NombreLenguaje")]
         public string NombreLenguaje { get; set; } = string.Empty;
         
         [BsonElement("Edad")]
          public int Edad { get; set; } = 0;

    }
}
