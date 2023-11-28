using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LivrosAPI.Models
{
    public class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Titulo { get; set; }
        public virtual Editora? Editora { get; set; }
        public virtual Autor? Autor { get; set; }
    }

    public class Autor
    {
        public string? Nome { get; set; }

    }
    public class Editora
    {
        public string? Empresa { get; set; }
    }
}
