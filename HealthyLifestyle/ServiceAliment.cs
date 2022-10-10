using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace HealthyLifestyle
{
    public static class ServiceAliment
    {
        static HttpClient _client;
        static JsonSerializerOptions _serializerOptions;

        public static List<Aliment> Items { get; private set; }


 
    public static async Task<List<Aliment>> getDataAsync()
        {

            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            Items = new List<Aliment>();

            try
            {
                HttpResponseMessage response = await _client.GetAsync(new Uri("https://mocki.io/v1/33f14989-3c29-4ba8-ac5e-8c74775100c8"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Aliment>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
