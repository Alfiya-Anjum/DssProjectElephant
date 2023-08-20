using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DssProjectElephant.Data.Enum;

namespace DssProjectElephant.Models
{
    public class TheNews
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public NewsCategory NewsCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? TheAppUserID { get; set; }
        public AppUser? TheAppUser { get; set; }
    }
}
