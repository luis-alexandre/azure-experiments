using Newtonsoft.Json;

namespace CosmosDB.Model
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public Device[] Devices { get; set; }
        
        public Address Address { get; set; }
        
        public string Gender { get; set; }
        
        public bool IsRegistered { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
