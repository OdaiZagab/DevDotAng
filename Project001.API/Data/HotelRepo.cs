using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project001.API.DTOs;
using Project001.API.Models;

namespace Project001.API.Data{
    public class HotelRepo : IHotelRepo
    {
        private DataContext _db;
        private IMapper _mapper;

        public HotelRepo(DataContext db,IMapper mapper){
            _db=db;
            _mapper=mapper;
        }
       
        public async Task<FloorToReturntDTO> addFloor(FloorToInsertDTO floorToInsertDTO)
        {
            Hotel hotel = await _db.hotels.Include(x=>x.floors).FirstOrDefaultAsync(x=>x.id==floorToInsertDTO.hotelId);
            if(hotel==null||floorToInsertDTO==null||hotel.floors.Any(x=>x.number==floorToInsertDTO.number)){
                 return null;
            }

      
 
            Floor floor = _mapper.Map<Floor>(floorToInsertDTO);
            hotel.floors.Add(floor);
            await _db.SaveChangesAsync();

            return _mapper.Map<FloorToReturntDTO>(floor);
            }

        public async Task<HotelToReturnDTO> addHotel(HotelToInsertDTO hotelToInsertDTO)
        {
            if(await _db.hotels.AnyAsync(x=>x.name==hotelToInsertDTO.name)){
                return null;}

            Hotel hotel = _mapper.Map<Hotel>(hotelToInsertDTO);
            
            await _db.hotels.AddAsync(hotel);
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelToReturnDTO>(hotel);}

        public async Task<RoomToReturnDTO> addRoom(RoomToInsertDTO roomTiInsertDTO)
        {   
            Hotel hotel = await _db.hotels.Include(x=>x.floors).Include(x=>x.roomTypes).Include(x=>x.rooms).FirstOrDefaultAsync(x=>x.id==roomTiInsertDTO.hotelId);
             if(hotel==null||
             !hotel.floors.Any(x=>x.id==roomTiInsertDTO.floorId)||
             !hotel.roomTypes.Any(x=>x.id==roomTiInsertDTO.roomTypeId)){
                return null;
            }
 
            Room room = _mapper.Map<Room>(roomTiInsertDTO);
            if(room==null){
                return null;
            }
            
            hotel.rooms.Add(room);
            await _db.SaveChangesAsync();
 
            return _mapper.Map<RoomToReturnDTO>(room);
        }

        public async Task<RoomTypeToReturnDTO> addRoomType(RoomTypeToInsertDTO roomTypeToInsertDTO)
        {
            Hotel hotel=await _db.hotels.Include(x=>x.roomTypes).FirstOrDefaultAsync(x=>x.id==roomTypeToInsertDTO.hotelId);
            
            if(hotel==null||hotel.roomTypes.Any(x=>x.type==roomTypeToInsertDTO.type)){
                return null;
            }
            RoomType roomType = _mapper.Map<RoomType>(roomTypeToInsertDTO);
            hotel.roomTypes.Add(roomType);
            await _db.SaveChangesAsync();
            
            return  _mapper.Map<RoomTypeToReturnDTO>(roomType);
        }

        public async Task<FloorToReturntDTO> getFloor(int id)
        {
            Hotel hotel = await _db.hotels.Include(x=>x.floors).FirstOrDefaultAsync(x=>x.floors.Any(x=>x.id==id));
            
            if(hotel==null){
                return null;//floor exists
            }
 
            return _mapper.Map<FloorToReturntDTO>(hotel.floors.FirstOrDefault(x=>x.id==id));
        }

        public async Task<HotelToReturnDTO> getHotel(int id)
        {
            Hotel hotel = await _db.hotels.Include(x=>x.floors).Include(x=>x.rooms).Include(x=>x.roomTypes).FirstOrDefaultAsync(x=>x.id==id);
            if(hotel==null){
                return null;
            }
            List<RoomToReturnDTO> roomToReturnDTOList = new List<RoomToReturnDTO>();
            List<FloorToReturntDTO> floorToReturntDTOList = new List<FloorToReturntDTO>() ;
            List<RoomTypeToReturnDTO> roomTypeToReturnDTOList = new List<RoomTypeToReturnDTO>() ;

            foreach (var item in hotel.rooms)
            {
                RoomToReturnDTO room = _mapper.Map<RoomToReturnDTO>(item);
                roomToReturnDTOList.Append(room);
            }
            
            foreach (var item in hotel.roomTypes)
            {
                RoomTypeToReturnDTO roomTypeToReturnDTO =_mapper.Map<RoomTypeToReturnDTO>(item);
                roomTypeToReturnDTOList.Append(roomTypeToReturnDTO);
            }
            
            foreach (var item in hotel.floors)
            {
                FloorToReturntDTO floorToReturntDTO = _mapper.Map<FloorToReturntDTO>(item);
                floorToReturntDTOList.Append(floorToReturntDTO);

            }
            HotelToReturnDTO hotelToReturnDTO = _mapper.Map<HotelToReturnDTO>(hotel);
            return hotelToReturnDTO;
        }
        public async Task<IEnumerable<RoomToReturnDTO>> getHotelRooms(int id)
        {

            Hotel hotel = await _db.hotels.Include(x=>x.floors).Include(x=>x.rooms).Include(x=>x.roomTypes).FirstOrDefaultAsync(x=>x.id==id);
            if(hotel==null){return null;}
            List<RoomToReturnDTO> list  = new List<RoomToReturnDTO>();

            foreach (var item in hotel.rooms)
            {   
                RoomToReturnDTO roomToReturnDTO=_mapper.Map<RoomToReturnDTO>(item);
                 list.Add(roomToReturnDTO);
            }
            return list;
        }

        public async Task<IEnumerable<HotelToReturnDTO>> getHotels()
        {
            List<Hotel> hotels = await _db.hotels.Include(x=>x.rooms).Include(x=>x.floors).Include(x=>x.roomTypes).ToListAsync();
            List<HotelToReturnDTO> hotelsToReturnDTO = new List<HotelToReturnDTO>();
            {            foreach (var item in hotels)

                hotelsToReturnDTO.Add(_mapper.Map<HotelToReturnDTO>(item));
            }

            return hotelsToReturnDTO;
        }

        public async Task<RoomToReturnDTO> getRoom(int id)
        {
            if(!await _db.rooms.AnyAsync(x=>x.id==id)){
                return null;
            }
            Hotel hotel = await _db.hotels.Include(x=>x.floors).Include(x=>x.rooms).Include(x=>x.roomTypes).FirstOrDefaultAsync(x=>x.rooms.Any(p=>p.id==id));
           
            if(hotel==null){ return null; }
            RoomToReturnDTO roomToReturnDTO = _mapper.Map<RoomToReturnDTO>(hotel.rooms.FirstOrDefault(x=>x.id==id));
            return roomToReturnDTO;
        }

        public async Task<RoomTypeToReturnDTO> getRoomType(int id)
        {  
            RoomType roomType = await _db.roomTypes.FirstOrDefaultAsync(x=>x.id==id);
            if (roomType==null){
                return null; }
            RoomTypeToReturnDTO roomTypeToReturnDTO = _mapper.Map<RoomTypeToReturnDTO>(roomType);
            return roomTypeToReturnDTO;

        }
    }
}