using Newtonsoft.Json;

namespace TechFlurry.BusinessSite.Models
{
    public class ContactMessageModel
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Service { get; set; }
        public string Message { get; set; }
    }
}
