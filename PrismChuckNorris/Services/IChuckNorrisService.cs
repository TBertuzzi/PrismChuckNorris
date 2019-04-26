using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrismChuckNorris.Models;

namespace PrismChuckNorris.Services
{
    public interface IChuckNorrisService
    {
        Task<IEnumerable<string>> GetCategories();
        Task<Joke> GetRandomJoke();
        Task<Joke> GetJokeByCategory(string category);
    }
}
