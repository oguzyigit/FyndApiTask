using FyndApiTask.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FyndApiTask.Service
{
    public class HotelService : IHotelService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<HotelService> _logger;

        public HotelService(IWebHostEnvironment hostingEnvironment, ILogger<HotelService> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }
        public List<Root> GetByHotelIdAndArrivedDate(int hotelId, DateTime arrivalDate)
        {
            string projectRootPath = _hostingEnvironment.ContentRootPath;
            string path = Path.Combine(projectRootPath, @"Data\hotelsrates.json");

            if (!System.IO.File.Exists(path))
            {
                _logger.LogError("json path does not exist", path);
            }

            string allText = System.IO.File.ReadAllText(path);

            List<Root> jsonObject = JsonConvert.DeserializeObject<List<Root>>(allText);
            Root filteredHotel = new Root();

            if (hotelId > 0)
            {
                var root = jsonObject.Where(a => a.Hotel.HotelId == hotelId).SingleOrDefault();
                if (arrivalDate > DateTime.MinValue)
                {
                    var hotelRates = root.HotelRates.Where(b => b.TargetDay.Date == arrivalDate.Date);
                    jsonObject = new List<Root> { new Root { Hotel = root.Hotel, HotelRates = hotelRates.ToList() } };
                }
                else
                {
                    jsonObject = new List<Root> { new Root { Hotel = root.Hotel, HotelRates = root.HotelRates } };
                }
            }
            else
            {
                if (arrivalDate > DateTime.MinValue)
                {
                    List<Root> buffList = new List<Root>();
                    for (int i = 0; i < jsonObject.Count; i++)
                    {
                        Root r = new Root { Hotel = jsonObject[i].Hotel, HotelRates = jsonObject[i].HotelRates.Where(a => a.TargetDay.Date == arrivalDate).ToList() };
                        buffList.Add(r);
                    }

                    jsonObject = buffList;
                }

            }

            return jsonObject;
        }
    }
}
