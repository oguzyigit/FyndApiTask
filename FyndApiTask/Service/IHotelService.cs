using FyndApiTask.Model;
using System;
using System.Collections.Generic;

namespace FyndApiTask.Service
{
    public interface IHotelService
    {
        List<Root> GetByHotelIdAndArrivedDate(int hotelId, DateTime arrivalDate);
    }
}
