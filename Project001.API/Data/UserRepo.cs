using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project001.API.DTOs;
using Project001.API.Models;

namespace Project001.API.Data{
    public class UserRepo : IUserRepo
    {
        private DataContext _db;
        private IMapper _mapper;

        public UserRepo(DataContext db,IMapper mapper){
            _db=db;
            _mapper=mapper;
        }
        public async Task<UserToreturnDTO> login(UserToInsertDTO userToInsertDTO)
        {
            User user = await _db.users.FirstOrDefaultAsync(x=>x.name==userToInsertDTO.name);
            if(user==null){
                return null;
            }

            if(user.password!=userToInsertDTO.password){
                return null;
            }



           return await getUser(user.id);
        }

        public async Task<UserToreturnDTO> signup(UserToInsertDTO userToInsertDTO)
        {
            if(await _db.users.AnyAsync(x=>x.name==userToInsertDTO.name)){
                return null;
            }

            User user = new User();
            user.name=userToInsertDTO.name;
            user.password=userToInsertDTO.password;


            await _db.users.AddAsync(user);
            await _db.SaveChangesAsync();
            return await getUser(user.id);

        }
        public async Task<UserToreturnDTO> getUser(int id){
            User user = await _db.users.FirstOrDefaultAsync(x=>x.id==id);
            if(user==null){
                return null;
            }

            UserToreturnDTO userToreturnDTO = _mapper.Map<UserToreturnDTO>(user);
            return userToreturnDTO;            
        }

        

       
    }
}