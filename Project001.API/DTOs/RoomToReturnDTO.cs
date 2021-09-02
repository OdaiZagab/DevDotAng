namespace Project001.API.DTOs{
    public class RoomToReturnDTO{
        public int id{set;get;}
        public int roomTypeId{set;get;}
        public int floorId{set;get;}
        public RoomTypeToReturnDTO roomType{set;get;}
        public FloorToReturntDTO floor{set;get;}
    }
}