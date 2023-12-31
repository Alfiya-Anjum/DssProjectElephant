﻿using System.ComponentModel.DataAnnotations;

namespace DssProjectElephant.ViewModels
{
    public class EditClubViewModels
    {
        public class EditClubViewModel
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Description { get; set; }
            public string Image { get; set; }
        }

    }
}
