using Microsoft.AspNetCore.Mvc;
using Walk.UI.Models.DTO;

namespace Walk.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessege = await client.GetAsync("https://localhost:7201/api/regions");

                httpResponseMessege.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessege.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>()) ;

            }
            catch (Exception ex)
            {
                // log the exeption
            }

            return View(response);
        }
    }
}
