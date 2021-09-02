using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project001.API.Data;
using Project001.API.DTOs;

namespace Project001.API.Controllers{
    [Controller]
    [ApiController]
    [Route("Hotel")]
    public class HotelController:ControllerBase{
        private IHotelRepo _db;

        public HotelController(IHotelRepo db){
            _db=db;
        }
       
       [HttpGet("getHotelRooms/{id}")]
        public async Task<ActionResult<IEnumerable<HotelToReturnDTO>>> getHotelRooms(int id){
            IEnumerable<RoomToReturnDTO> roomToReturnDTOList = (IEnumerable<RoomToReturnDTO>)await _db.getHotelRooms(id);
            if(roomToReturnDTOList==null){
                return NotFound();
            }
            return Ok(roomToReturnDTOList);
        }

       [HttpPost("addRoom")]
        public async Task<ActionResult<IEnumerable<HotelToReturnDTO>>> addRoom(RoomToInsertDTO roomToInsertDTO){
            RoomToReturnDTO roomToReturnDTO = await _db.addRoom(roomToInsertDTO);
            if(roomToInsertDTO==null){
                return BadRequest("room wasn't added");
            }
          
        
            return Ok(roomToReturnDTO);
        }

        [HttpPost("addFloor")]
        public async Task<ActionResult<IEnumerable<HotelToReturnDTO>>> addFloor(FloorToInsertDTO floorToInsertDTO){
            FloorToReturntDTO floorToReturntDTO = await _db.addFloor(floorToInsertDTO);
            if(floorToReturntDTO==null){
                return BadRequest("Floor wasn't added");
            }
          
        
            return Ok(floorToReturntDTO);
        }
        [HttpPost("addRoomType")]
        public async Task<ActionResult<IEnumerable<HotelToReturnDTO>>> addRoomType(RoomTypeToInsertDTO roomTypeToInsertDTO){
            RoomTypeToReturnDTO roomTypeToReturnDTO = await _db.addRoomType(roomTypeToInsertDTO);
            if(roomTypeToReturnDTO==null){
                return BadRequest("Room Type wasn't added");
            }
          
        
            return Ok(roomTypeToReturnDTO);
        }
       [HttpGet("getHotel/{id}")]
        public async Task<ActionResult<HotelToReturnDTO>> getHotel(int id){
            HotelToReturnDTO hotelToReturnDTO =  await _db.getHotel(id);
            if(hotelToReturnDTO==null){
                return NotFound();
            }
            return Ok(hotelToReturnDTO);
        }
       [HttpGet("getHotels")]
        public async Task<ActionResult<IEnumerable<HotelToReturnDTO>>> getHotels(){
            IEnumerable<HotelToReturnDTO> hotelsToReturnDTO =  await _db.getHotels();
            if(hotelsToReturnDTO==null){
                return NotFound();
            }
            return Ok(hotelsToReturnDTO);
        }

        [HttpGet("getFloor")]
        public async Task<ActionResult<FloorToReturntDTO>> getFloor(int id){
            FloorToReturntDTO floorToReturntDTO =  await _db.getFloor(id);
            if(floorToReturntDTO==null){
                return NotFound();
            }
            return Ok(floorToReturntDTO);
        }

        [HttpPost("addHotel")]
        public async Task<ActionResult<HotelToReturnDTO>> addHotel(HotelToInsertDTO hotelToInsertDTO){
            HotelToReturnDTO hotel = await _db.addHotel(hotelToInsertDTO);
            if(hotel==null){
                return BadRequest("Hotel wasn't added");
            }
            return Ok(hotel);
        }
    }
}