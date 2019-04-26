using System;
using System.Net.Http;
using System.Net.Http.Headers;
using PrismChuckNorris.Helpers;

namespace PrismChuckNorris.Services.Base
{
    public class BaseHttpClient : HttpClient
    {
        public BaseHttpClient()
        {
            this.BaseAddress = new Uri(Constantes.ApiBaseUrl);
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
