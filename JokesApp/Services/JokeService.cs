using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesApp.Models;
using JokesApp.Providers;

namespace JokesApp.Services
{
    public class JokeService
    {
        private readonly ProviderInterface[] Providers = {
            new Icndb(),
            new Sv443(),
            new OfficeJoke()
        };

        public async Task<List<Joke>> getJokes(int amount = 10)
        {
            List<Joke> jokes = new List<Joke>();

            List<Task<List<Joke>>> tasks = new List<Task<List<Joke>>> {};

            // Fetch joke from all providers
            foreach (ProviderInterface provider in this.Providers)
            {
                tasks.Add(provider.getJokes(amount));
            }

            while (tasks.Count > 0 && jokes.Count < amount)
            {
                // Once a task completed
                Task<List<Joke>> finishedTask = await Task.WhenAny(tasks);

                jokes.AddRange(finishedTask.Result);

                tasks.Remove(finishedTask);
            }

            return jokes;
        }
    }
}
