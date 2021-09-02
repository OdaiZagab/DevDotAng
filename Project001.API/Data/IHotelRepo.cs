using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project001.API.DTOs;

namespace Project001.API.Data{
    public interface IHotelRepo{

        public Task<HotelToReturnDTO> addHotel(HotelToInsertDTO hotelToInsertDTO);
        public Task<HotelToReturnDTO> getHotel(int id);
        public Task<IEnumerable<HotelToReturnDTO>> getHotels();
        public Task<IEnumerable<RoomToReturnDTO>> getHotelRooms(int id);
        public Task<RoomToReturnDTO> addRoom(RoomToInsertDTO roomTiInsertDTO);
        public Task<RoomToReturnDTO> getRoom(int id);

        public Task<FloorToReturntDTO> addFloor(FloorToInsertDTO floorToInsertDTO);
        public Task<FloorToReturntDTO> getFloor(int id);

        public Task<RoomTypeToReturnDTO> addRoomType(RoomTypeToInsertDTO roomTypeToInsertDTO);
        public Task<RoomTypeToReturnDTO> getRoomType(int id);
        
        
    }
}