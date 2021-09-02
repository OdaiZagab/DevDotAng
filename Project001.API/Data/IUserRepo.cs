using System.Threading.Tasks;
using Project001.API.DTOs;

namespace Project001.API.Data{
    public interface IUserRepo{

        public Task<UserToreturnDTO> login(UserToInsertDTO userToInsertDTO);
        public Task<UserToreturnDTO> signup(UserToInsertDTO userToInsertDTO);
        public Task<UserToreturnDTO> getUser(int userId);
    }
}