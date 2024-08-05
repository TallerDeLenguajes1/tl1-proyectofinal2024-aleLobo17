using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using personaje;


namespace CrearApi
{
    public class ApiClima
    {
        private static string apiKey = "y0cyg5atu3260ortirka20r0nq81odxligzevzv3";
        private static List<string> placeIds = new List<string>
        {
            "london", "tokyo", "paris", "berlin", "sydney"
        };

        private static string GetRandomPlaceId()
        {
            var random = new Random();
            int i = random.Next(placeIds.Count);
            return placeIds[i];
        }
        //https://www.meteosource.com/api/v1/free/point?place_id=berlin&sections=all&timezone=UTC&language=en&units=metric&key=y0cyg5atu3260ortirka20r0nq81odxligzevzv3

        public static async Task<string> TraerInfoClima()
        {
            try
            {
                using HttpClient client = new HttpClient();
                string placeId = GetRandomPlaceId();
                string url = $"https://www.meteosource.com/api/v1/free/point?place_id={placeId}&sections=all&timezone=UTC&language=en&units=metric&key={apiKey}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var data = JObject.Parse(responseBody);
                return data["current"]["summary"].ToString();  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el clima: {ex.Message}");
                return "Error";
            }
        }

        public static void controlarClimaConPersonaje(Personaje character, string weather)
        {
            int bonus = 0;

            switch (character.Datos.Tipo)
            {
                case "Hielo":
                    if (weather.Contains("Clear") || weather.Contains("Snow") || weather.Contains("Partly clear"))
                    {
                        bonus = 1;
                    }
                    if (weather.Contains("Sunny") || weather.Contains("Mostly sunny") || weather.Contains("Partly sunny"))
                    {
                        bonus = 2;
                    }
                    break;
                case "Trueno":
                    if (weather.Contains("Rain") || weather.Contains("Rain shower") || weather.Contains("Thunderstorm"))
                    {
                        bonus = 1;
                    }
                    if (weather.Contains("Sunny") || weather.Contains("Mostly sunny") || weather.Contains("Partly sunny"))
                    {
                        bonus = 2;
                    }
                    break;
                case "Viento":
                    if (weather.Contains("Wind") || weather.Contains("Windy") || weather.Contains("Cloudy") || weather.Contains("Overcast") || weather.Contains("Mostly Cloudy"))
                    {
                        bonus = 1;
                    }
                    if (weather.Contains("Rain") || weather.Contains("Rain shower") || weather.Contains("Thunderstorm"))
                    {
                        bonus = 2;
                    }
                    break;
                case "Fuego":
                    if (weather.Contains("Sunny") || weather.Contains("Mostly sunny") || weather.Contains("Partly sunny"))
                    {
                        bonus = 1;
                    }
                    if (weather.Contains("Rain") || weather.Contains("Rain shower") || weather.Contains("Thunderstorm"))
                    {
                        bonus = 2;
                    }
                    break;
                case "Tierra":
                    if (weather.Contains("Earthquake") || weather.Contains("Partly sunny"))
                    {
                        bonus = 1;
                    }
                    if (weather.Contains("Rain") || weather.Contains("Rain shower") || weather.Contains("Thunderstorm"))
                    {
                        bonus = 2;
                    }
                    break;
                case "Agua":
                    if (weather.Contains("Rain") || weather.Contains("Rain shower") || weather.Contains("Thunderstorm"))
                    {
                        bonus = 1;
                    }
                    if (weather.Contains("Sunny") || weather.Contains("Mostly sunny") || weather.Contains("Partly sunny"))
                    {
                        bonus = 1;
                    }
                    break;
            }

             switch (bonus)
            {
                case 0:
                    Console.WriteLine($"{character.Datos.Name} no obtiene bonificación del clima.");
                    break;
                case 1:
                    Console.WriteLine($"{character.Datos.Name} tiene +5 de fuerza y +5 de armadura aumentadas debido al clima.");
                    character.Caracteristicas.Fuerza += 4;
                    character.Caracteristicas.Armadura += 5;
                    break;
                case 2:
                    Console.WriteLine($"{character.Datos.Name} tiene -3 de fuerza y -3 de armadura mermadas debido al clima.");
                    character.Caracteristicas.Fuerza -= 2;
                    character.Caracteristicas.Armadura -= 3;
                    break;
            }
        }
    }
}
