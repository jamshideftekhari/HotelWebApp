using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUniversalApp.Model
{
    public class Room
    {
        public int RoomNo { get; set; }
        public int HotelNo { get; set; }
        public string RoomType { get; set; }
        public double RoomPrice { get; set; }

        public Room() {}

        public override string ToString()
        {
            return String.Format("Room Nr: {0}, Hotel Nr: {1}, Romm Type: {2}, Room Price: {3}",RoomNo,HotelNo,RoomType,RoomPrice);
        }
    }
}
