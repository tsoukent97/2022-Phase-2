using Microsoft.AspNetCore.Mvc;

namespace DogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OtherAPIController : ControllerBase
    {
        private readonly HttpClient _client;


        /// <summary />
        public OtherAPIController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            _client = clientFactory.CreateClient("dog");
        }

        /// <summary>
        /// Gets the raw JSON for Dog-API
        /// </summary>
        /// <returns>A JSON object representing the Dog-API</returns>
        [HttpGet]
        [Route("raw")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetRawRedditHotPosts()
        {
            var res = await _client.GetAsync("/");
            var content = await res.Content.ReadAsStringAsync();

            return Ok(content);
        }
    }
}

