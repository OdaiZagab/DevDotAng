namespace Project001.API.Models{
    public class Admin{
        public int id{set;get;}
        public int  userId{set;get;}
        public int hotelId{set;get;}
        public User user{set;get;}
        public Hotel hotel{set;get;}
        
    }
}