using System.Text.Json.Serialization;

namespace Project001.API.DTOs{
    public class RoomTypeToReturnDTO{

        public int id{set;get;}
        public string type{set;get;}
        public int hotelId{set;get;}
        public HotelToReturnDTO hotel{set;get;}
    }
}