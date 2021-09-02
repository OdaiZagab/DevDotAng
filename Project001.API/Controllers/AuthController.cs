using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project001.API.Data;
using Project001.API.DTOs;
using Project001.API.Models;

namespace Project001.API.Controllers{
    [ApiController]
    [Controller]
    [Route("api/auth")]
    public class AuthController: ControllerBase{
        private IUserRepo _db;
        private IConfiguration _configration;

        public AuthController(IUserRepo db,IConfiguration configuration){
            _db=db;
            _configration=configuration;
        }
        [HttpPost("signup")]
        public async Task<ActionResult<UserToreturnDTO>> signup(UserToInsertDTO userToInsertDTO){
            UserToreturnDTO user = await _db.signup(userToInsertDTO);
            if(user==null){
                return BadRequest("Please try again");
            }
            return Ok( await _db.getUser(user.id));
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserToreturnDTO>> login(UserToInsertDTO userToInsertDTO){
            UserToreturnDTO user = await _db.login(userToInsertDTO);
            if(user==null){
                return BadRequest("Please try again");

            }
 
                 
            var claims = new []{
                new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
                new Claim(ClaimTypes.Name,user.name)
            };
 
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configration.GetSection("apiKey")+""));
            
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
       
            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Subject= new ClaimsIdentity(claims);
            tokenDescriptor.Expires=DateTime.Now.AddDays(1);
            tokenDescriptor.SigningCredentials=creds;

            var tokenHandler =new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);


            return Ok(    new {
                   token= tokenHandler.WriteToken(token)
                });
        }

        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<UserToreturnDTO>> getUser(int id){
            UserToreturnDTO userToreturnDTO =await _db.getUser(id);
            if(userToreturnDTO==null){
                return NotFound();
            }
            return Ok(userToreturnDTO);
        }

    }
}