using System.Collections.Generic;
using AutoMapper;
using Project001.API.DTOs;
using Project001.API.Models;

namespace Project001.API.Profiles{
    public class HotelProfile : Profile{

         public HotelProfile(){
         CreateMap<Hotel,HotelToReturnDTO>();
         CreateMap<HotelToInsertDTO,Hotel>();
         CreateMap<Floor,FloorToReturntDTO>();
         CreateMap<FloorToInsertDTO,Floor>();
         CreateMap<Room,RoomToReturnDTO>();
         CreateMap<RoomToInsertDTO,Room>();
         CreateMap<RoomType,RoomTypeToReturnDTO>();
         CreateMap<RoomTypeToInsertDTO,RoomType>();
         CreateMap<User,UserToreturnDTO>();
         CreateMap<UserToreturnDTO,User>();

         }
    }
}