using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using JokesApp.Models;
using System.Text.Json;

namespace JokesApp.Providers
{
    public class Icndb : ProviderInterface
    {
        private readonly string URL = "http://api.icndb.com/jokes/";

        private readonly HttpClient Client = new HttpClient();

        public async Task<List<Joke>> getJokes(int amount)
        {
            string response = await this.Client.GetStringAsync(URL + "random/" + amount);

            Payload payload = JsonSerializer.Deserialize<Payload>(response);

            List<Joke> jokes = this.CastToJoke(payload);

            return jokes;
        }

        private List<Joke> CastToJoke(Payload payload)
        {
            List<Joke> jokes = new List<Joke>();

            foreach (Payload.Item value in payload.value)
            {
                jokes.Add(new Joke() { text = value.joke });
            }

            return jokes;
        }

        private class Payload
        {
            public string type { get; set; }
            public List<Item> value { get; set; }

            public class Item
            {
                public string joke { get; set; }
            }
        }
    }
}
