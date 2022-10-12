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
    public static class ServiceParc
    {
        static HttpClient _client;
        static JsonSerializerOptions _serializerOptions;

        public static List<Parc> listaParcuri { get; private set; }


 
    public static async Task<List<Parc>> preiaParcuri()
        {

            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            listaParcuri = new List<Parc>();

            try
            {
                HttpResponseMessage response = await _client.GetAsync(new Uri("https://mocki.io/v1/f53fb2d9-4df8-4be0-83e0-dbeb3ede1fc7"));
                if (response.IsSuccessStatusCode)
                {
                    string continut = await response.Content.ReadAsStringAsync();
                    listaParcuri = JsonSerializer.Deserialize<List<Parc>>(continut, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return listaParcuri;
        }
    }
}
