using System;
using System.Collections.Generic;

namespace Project001.API.Models{
    public class Hotel{
        public int id{set;get;}
        public string name{set;get;}
        public string phone{set;get;}
        public string location{set;get;}

        public ICollection<Room> rooms{set;get;}
        public ICollection<Floor> floors{set;get;}
        public ICollection<RoomType> roomTypes{set;get;}

    }
}