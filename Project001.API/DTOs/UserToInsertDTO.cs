using System.ComponentModel.DataAnnotations;

namespace Project001.API.DTOs{
    public class UserToInsertDTO{
        [Required]
        [MinLength(8)]
        public string name{set;get;}
                
        [Required]
        [MinLength(8)]
        public string password{set;get;}
    }
}