using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using JokesApp.Models;
using System.Text.Json;
using JokesApp.Providers;

namespace JokesApp.Services
{
    public class JokeService
    {
        public async Task<List<Joke>> getJokes(int amount = 10)
        {
            List<Joke> jokes = new List<Joke>();

            ProviderInterface provider = new Icndb();

            jokes = await provider.getJokes(amount);

            return jokes;
        }
    }
}
