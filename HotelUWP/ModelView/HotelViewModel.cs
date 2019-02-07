using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HotelUWP.Annotations;
using HotelUWP.Model;

namespace HotelUWP.ModelView
{
    class HotelViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Hotel> Hotels { get; set; }
        public string ConnectionString = @"Data Source=EASJ3218;Initial Catalog=HotelDbtest2018;Integrated Security=True;";

        public HotelViewModel()
        {
            Hotels = new ObservableCollection<Hotel>();
            RetriveData(Hotels, ConnectionString);
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
                        cmd.CommandText = "";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var hotel = new Hotel();
                                hotel.Hotel_No = reader.GetInt32(0);
                                hotel.Address = reader.GetString(1);
                                hotel.Name = reader.GetString(2);
                                
                                hotels.Add(hotel);
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
