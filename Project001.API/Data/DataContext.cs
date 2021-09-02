using Microsoft.EntityFrameworkCore;
using Project001.API.Models;

namespace Project001.API.Data{
    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext> options ) : base(options){}

        public DbSet<User> users{set;get;}
        public DbSet<Admin> admins{set;get;}
        public DbSet<Floor> floors{set;get;}
        public DbSet<Hotel> hotels{set;get;}
        public DbSet<Room> rooms{set;get;}
        public DbSet<RoomType> roomTypes{set;get;}
        
    }
}