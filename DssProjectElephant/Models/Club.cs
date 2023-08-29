using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DssProjectElephant.Data.Enum;

namespace DssProjectElephant.Models
{
    public class Club
    {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ClubCategory ClubCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? TheAppUserID { get; set; }
        public AppUser? TheAppUser { get; set; }
    }
}

// Club.cs
//using DssProjectElephant.Data.Enum;
//using DssProjectElephant.Models;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//public class Club
//{
//    public int Id { get; set; }
//    [Required]
//    public string Name { get; set; }
//    [Required]
//    public string Description { get; set; }
//    public string Image { get; set; }
//    public ClubCategory ClubCategory { get; set; }
//    public Address Address { get; set; }
//}

//// ClubDbContext.cs
//public class ClubDbContext : DbContext
//{
//    public ClubDbContext(DbContextOptions<ClubDbContext> options)
//        : base(options)
//    {
//    }

//    public DbSet<Club> Clubs { get; set; }
//}

