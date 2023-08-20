using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DssProjectElephant.Models
{
    public class AppUser : IdentityUser
    {
        // Other properties

        [Key]
        public override string Id { get; set; }
        public int? Users { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<TheNews> TheNews { get; set; }
    }
}
