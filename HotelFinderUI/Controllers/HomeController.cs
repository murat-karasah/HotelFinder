using HotelFinderUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            List<HotelDto> hList = new List<HotelDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/api/");
                var responseTalk = client.GetAsync("Hotels");
                
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var hotels = readTask.Result;
                    hList = JsonConvert.DeserializeObject<List<HotelDto>>(hotels);
                }
            }
            if (hList!=null)
            {
                return View(hList);
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            HotelDto hotel = new HotelDto();
            using (var client = new HttpClient() )
            {

                client.BaseAddress = new Uri("https://localhost:44318/api/");
                var responseTalk = client.GetAsync("Hotels"+"/"+id);
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var hotels = readTask.Result;
                    hotel = JsonConvert.DeserializeObject<HotelDto>(hotels);
                }
            }
            if (hotel != null)
            {
                return View(hotel);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44318/api/");
            var result = client.DeleteAsync("Hotels" + "/" + id).Result;
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            HotelDto hotel = new HotelDto();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/api/");
                var responseTalk = client.GetAsync("Hotels" + "/" + id);
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var hotels = readTask.Result;
                    hotel = JsonConvert.DeserializeObject<HotelDto>(hotels);
                }
            }
            if (hotel != null)
            {
                return View(hotel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(HotelDto hotelim)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44318/api/");
            var stringContent = new StringContent(JsonConvert.SerializeObject(hotelim), Encoding.UTF8, "application/json");
            var result = client.PutAsync("Hotels", stringContent);
            result.Wait();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelDto hotel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44318/api/");
            var stringContent = new StringContent(JsonConvert.SerializeObject(hotel), Encoding.UTF8, "application/json");
            var result = client.PostAsync("Hotels", stringContent);
            result.Wait();
            return RedirectToAction("Index","Home");
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
