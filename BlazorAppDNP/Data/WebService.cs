using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorAppDNP.Models;

namespace BlazorAppDNP.Data
{
    public class WebService : IAdultData, IUserService
    {
        private string uri = "http://localhost:5003";

        private readonly HttpClient client;
        
        public WebService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdults(string name)
        {
            string finalUri = $"{uri}/AllAdult?";
            
            if (name != null) finalUri += $"name={name}&";

            finalUri = finalUri.Substring(0, finalUri.Length-1);
            Console.WriteLine(finalUri);
            HttpResponseMessage responseMessage = await client.GetAsync(finalUri);
           
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(responseMessage.ReasonPhrase);
            
            
            string message = await responseMessage.Content.ReadAsStringAsync();
            
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return result;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/AllAdult", content);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return adult;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            string finalUri = $"{uri}/AllAdult";
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"Users?username={username}&password={password}");
           
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("Error");
            
            
            string message = await responseMessage.Content.ReadAsStringAsync();
            
            User result = JsonSerializer.Deserialize<User>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return result;
        }

        public async Task RegisterUser(User user)
        {
            string adultAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/User", content);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }
    }
}