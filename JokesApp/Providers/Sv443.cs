using JokesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace JokesApp.Providers
{
    public class Sv443 : ProviderInterface
    {
        private readonly string URL = "https://v2.jokeapi.dev/joke";

        private readonly HttpClient Client = new HttpClient();

        public async Task<List<Joke>> getJokes(int amount)
        {
            {
                string response = await this.Client.GetStringAsync(URL + "/Any" + "?type=single&amount=" + amount);

                Payload payload = JsonConvert.DeserializeObject<Payload>(response);

                List<Joke> jokes = this.castToJoke(payload);

                return jokes;
            }
        }

        private List<Joke> castToJoke(Payload payload)
        {
            List<Joke> jokes = new List<Joke>();

            foreach (Payload.Item value in payload.jokes)
            {
                jokes.Add(new Joke() { text = value.joke });
            }

            return jokes;
        }

        private class Payload
        {
            public string error { get; set; }

            public string amount { get; set; }

            public List<Item> jokes { get; set; }

            public class Item
            {
                public string joke { get; set; }
            }
        }
    }
}
