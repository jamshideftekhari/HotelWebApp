using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HotelUniversalApp.Model
{
    public class Hotel
    {
        public int Hotel_No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
//        public Room HotelRoom { get; set; }

        public Hotel()
        {
           // HotelRoom = new Room();
        }

        public override string ToString()
        {
            return String.Format("Id: {0}, Hotel Name: {1}, Hotel Address: {2}", Hotel_No, Name, Address);
          //  return String.Format("Id: {0}, Hotel Name: {1}, Hotel Address: {2}, Room Type: {3} Room Price: {4}", Hotel_No, Name, Address, HotelRoom.RoomType, HotelRoom.RoomPrice);

        }
    }
    
}
