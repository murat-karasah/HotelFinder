﻿using HotelFinderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderDataAccess.Abstract
{
   public interface IHotelRepository
    {
        List<Hotel> GetAllHotel();
        Hotel GetHotelById(int id);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
    }
}