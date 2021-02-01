using JokesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace JokesApp.Providers
{
    public class OfficeJoke : ProviderInterface
    {
        private readonly string URL = "https://official-joke-api.appspot.com/random_ten";

        private readonly HttpClient Client = new HttpClient();

        public async Task<List<Joke>> getJokes(int amount)
        {
            {
                List<Joke> jokes = new List<Joke>();

                while (jokes.Count < amount)
                {
                    jokes.AddRange(await this.getTenJokes());
                }

                return jokes.Take(amount).ToList();
            }
        }

        private async Task<List<Joke>> getTenJokes()
        {
            string response = await this.Client.GetStringAsync(URL);

            List<Payload> payload = JsonConvert.DeserializeObject<List<Payload>>(response);

            List<Joke> jokes = this.castToJoke(payload);

            return jokes;
        }

        private List<Joke> castToJoke(List<Payload> payload)
        {
            List<Joke> jokes = new List<Joke>();

            foreach (Payload value in payload)
            {
                jokes.Add(new Joke() { text = value.setup + ' ' + value.punchline });
            }

            return jokes;
        }

        private class Payload
        {
            public string id { get; set; }

            public string setup { get; set; }

            public string punchline { get; set; }
        }
    }
}
