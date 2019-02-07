using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HotelUniversalApp.Annotations;
using HotelUniversalApp.Model;

namespace HotelUniversalApp.ViewModel
{
    class HotelViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Hotel> _hotels;
        private ObservableCollection<Room> _rooms;

        public ObservableCollection<Hotel> Hotels
        {
            set
            {
                _hotels = value;
                OnPropertyChanged();
            }
            get { return _hotels; }
        }

        public ObservableCollection<Room> Rooms
        {
            set
            {
                _rooms = value;
                OnPropertyChanged();
            }
            get { return _rooms; }
        }

        public string ConnectionString = @"Data Source=EASJ3218;Initial Catalog=HotelDbtest2018;Integrated Security=TRUE;";
        //public string ConnectionString = @"Data Source=jaefserver.database.windows.net;Initial Catalog=HotelDataBaseF2018; Integrated Security = False; User ID =jaef; Password = JAM2003eft ";
       // public string ConnectionString = @"Data Source=jaefserver.database.windows.net;Initial Catalog=HotelDataBaseF2018; Integrated Security = False; User ID =ApplicationUser; Password = YourStrongPassword1 ";

        public HotelViewModel()
        {
            Hotels = new ObservableCollection<Hotel>();
            RetriveData(Hotels, ConnectionString);
            Rooms = new ObservableCollection<Room>();
            RetriveData(Rooms, ConnectionString);
        }

        private void RetriveData(ObservableCollection<Hotel> hotels, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT*FROM Hotel";
                      //  cmd.CommandText = "SELECT Hotel.Hotel_No, Hotel.Name, Hotel.Address, Room.Types, Room.Price From Hotel inner join Room on Hotel.Hotel_No =1";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var hotel = new Hotel();
                                hotel.Hotel_No = reader.GetInt32(0);
                                hotel.Address = reader.GetString(1);
                                hotel.Name = reader.GetString(2);
                       //         hotel.HotelRoom.RoomType = reader.GetString(3);
                       //         hotel.HotelRoom.RoomPrice = reader.GetDouble(4);

                                hotels.Add(hotel);
                            }
                        }
                    }
                }
            }
        }

        private void RetriveData(ObservableCollection<Room> rooms, string connectionString)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT*FROM Room";
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var room = new Room();
                                    room.RoomNo = reader.GetInt32(0);
                                    room.HotelNo = reader.GetInt32(1);
                                    room.RoomType = reader.GetString(2);
                                    room.RoomPrice = reader.GetDouble(3);

                                    rooms.Add(room);
                                }
                            }
                        }
                    }
                }

            }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
