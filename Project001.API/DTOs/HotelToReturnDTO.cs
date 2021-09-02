using System.Collections.Generic;

namespace Project001.API.DTOs{
    public class HotelToReturnDTO{
        public int id{set;get;}
        public string name{set;get;}
        public string phone{set;get;}
        public string location{set;get;}
        public List<RoomToReturnDTO> rooms{set;get;}
        public List<FloorToReturntDTO> floors{set;get;}
        public List<RoomTypeToReturnDTO> roomTypes{set;get;}
    }
}