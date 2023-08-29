//using DssProjectElephant.Models;
//using Microsoft.EntityFrameworkCore;
//namespace DssProjectElephant.Data
//{
//    public class ApplicationDbContent : IdentityDbContext<AppUser>
//    {
//        public ApplicationDbContent(DbContextOptions<ApplicationDbContent> options) : base(options)
//        {

//        }
//        public DbSet<TheNews> TheNews { get; set; }
//        public DbSet<Club> Clubs { get; set; }
//        public DbSet<Address> Addresses { get; set; }
//    }
//}

using DssProjectElephant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DssProjectElephant.Data
{
    public class ApplicationDbContent : IdentityDbContext<AppUser>
    {
        public ApplicationDbContent(DbContextOptions<ApplicationDbContent> options) : base(options)
        {

        }

       
        public DbSet<TheNews> TheNews { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Address> Addresses { get; set; }

        
    }
}




