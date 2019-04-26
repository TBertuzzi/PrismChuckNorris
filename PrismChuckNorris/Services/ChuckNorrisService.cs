using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PrismChuckNorris.Models;
using PrismChuckNorris.Services.Base;

namespace PrismChuckNorris.Services
{
    public class ChuckNorrisService : BaseHttpClient,IChuckNorrisService
    {
   
        public async Task<IEnumerable<string>> GetCategories()
        {
            try
            {
                var response = await this.GetAsync<List<string>>("categories");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Value;
                }
                else
                {
                    throw new Exception(
                           $"HttpStatusCode: {response.StatusCode.ToString()} Message: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Joke> GetRandomJoke()
        {

            try
            {
                var response = await this.GetAsync<Joke>("random");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Value;
                }
                else
                {
                    throw new Exception(
                           $"HttpStatusCode: {response.StatusCode.ToString()} Message: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
