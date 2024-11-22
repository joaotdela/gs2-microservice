using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class CleanEnergy
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double GeneartedKWh { get; set; }
    }
}
