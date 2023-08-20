/*using System.ComponentModel.DataAnnotations;

namespace DssProjectElephant.ViewModels
{
    public class EditNewsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

    }
}*/

using System.ComponentModel.DataAnnotations;

namespace DssProjectElephant.ViewModels
{
    public class EditNewsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Image { get; set; }

        // Add any other properties you need for editing news
    }
}

