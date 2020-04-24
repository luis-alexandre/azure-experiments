using Newtonsoft.Json;

namespace CosmosDB.Model
{
    public class EntityBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
