using BornaCvitanicPortfolioWebapp.Models.GithubAPI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BornaCvitanicPortfolioWebapp.Controllers
{
    public class GithubAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Repository> repos;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "bornacvitanic-portfolio-webapp");
                using (var response = await httpClient.GetAsync("https://api.github.com/users/bornacvitanic/repos"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    repos = JsonConvert.DeserializeObject<List<Repository>>(apiResponse);
                }
            }
            return View(repos);
        }
    }
}
