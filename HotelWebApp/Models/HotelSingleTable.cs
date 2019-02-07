using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelWebApp.Models
{
    public class HotelSingleTable
    {
        public int Hotel_No { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_Address { get; set; }
        public int Room_No { get; set; }
        public string Room_Type { get; set; }
        public double Room_Price { get; set; }
        public string Guest_Name { get; set; }
        public string Guest_Address { get; set; }
        public DateTime Booking_Date_From { get; set; }
        public DateTime Booking_Date_to { get; set; }
    }

    // class DB context

    public class HotelSingleDbCotext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

    }
}