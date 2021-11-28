using System.Text.Json.Serialization;

namespace WebAppiDNP.Models
{
    public class User
    {
        
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("age")]
        public string Age { get; set; }
        [JsonPropertyName("securityLevel")] 
        public int SecurityLevel { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("firstName")]
        public string UserFirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string UserLastName { get; set; }
    }
}