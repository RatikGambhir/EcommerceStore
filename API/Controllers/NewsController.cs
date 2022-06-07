using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class NewsController : BaseApiController
    {
    public HttpClient HttpClient { get; }
    public IHttpClientFactory ClientFactory { get; set; }
        public NewsController(HttpClient httpClient, IHttpClientFactory clientFactory) {
        ClientFactory = clientFactory;
             HttpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult<NFLNews>> GetExternalNewsArticles() {

            NFLNews result;
               
        
                var client = new HttpClient();

                var response = client.GetAsync("https://site.api.espn.com/apis/site/v2/sports/football/nfl/news").Result;

                var responseAsString = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<NFLNews>(responseAsString);
                
    
                return Ok(result);
    }
}
}