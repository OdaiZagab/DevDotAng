namespace Project001.API.DTOs{
    public class FloorToReturntDTO{
        public int id{set;get;}
        public int hotelId{set;get;}
        public int number{set;get;}

        public HotelToReturnDTO hotel{set;get;}
        
    }
}