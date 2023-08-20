using System.ComponentModel.DataAnnotations;

namespace DssProjectElephant.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public string Country { get; set; }
      
    }
}
