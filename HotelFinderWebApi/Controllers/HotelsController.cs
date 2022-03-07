using HotelFinderBusiness.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService hotelService;
        public HotelsController(IHotelService _hotelService)
        {
            hotelService = _hotelService;
        }

        [HttpGet]
        public IActionResult GetAllHotel()
        {
            var hotels = hotelService.GetAllHotel();
            return Ok(hotels);
        }

      

    }
}
