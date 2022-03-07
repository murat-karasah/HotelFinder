using HotelFinderBusiness.Abstract;
using HotelFinderEntities;
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
        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotelService.CreateHotel(hotel);
                return Ok();
            }
            return BadRequest(ModelState);//400 +error mesaji
        }

        [HttpPut]
        public IActionResult UpdateHotel(Hotel hotel)
        {
            if (hotelService.GetHotelById(hotel.Id)!=null)
            {
                hotelService.UpdateHotel(hotel);
                return Ok();
            }
            return BadRequest(ModelState);//400 +error mesaji
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if (hotelService.GetHotelById(id)!=null)
            {
                hotelService.DeleteHotel(id);
                return Ok();
            }
            return BadRequest(ModelState);//400 +error mesaji
        }

    }
}
