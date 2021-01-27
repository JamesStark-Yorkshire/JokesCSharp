using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesApp.Models;

namespace JokesApp.Providers
{
    interface ProviderInterface
    {
        public Task<List<Joke>> getJokes(int amount);
    }
}
