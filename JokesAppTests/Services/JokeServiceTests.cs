using Microsoft.VisualStudio.TestTools.UnitTesting;
using JokesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokesApp.Services.Tests
{
    [TestClass()]
    public class JokeServiceTests
    {
        private JokeService service = new JokeService();
        
        [TestMethod()]
        public void getJokesTest()
        {
            int amount = new Random().Next(1, 20);
            
            Task<List<Models.Joke>> jokes = this.service.getJokes(amount);

            Assert.AreEqual(jokes.Result.Count, amount);
        }
    }
}