using Barn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Barn.Services;
using Microsoft.Extensions.Configuration;

namespace Barn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAcoountService SpotifyAcoountService ; 
        private readonly IConfiguration Configuration;

        public HomeController(ISpotifyAcoountService spotifyAcoountService, IConfiguration configuration)
        {
            SpotifyAcoountService = spotifyAcoountService;
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {

            try
            {
                var token =await SpotifyAcoountService.GetToken(Configuration["Spotify: ClientId"], Configuration["Spotify: ClientSecret"]);
            }
            catch (Exception ex)
            {

                Debug.Write(ex); 
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
