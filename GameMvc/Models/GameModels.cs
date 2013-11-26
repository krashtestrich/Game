using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameMvc.Models
{
    public class UICharacterModel
    {
        [Required]
        [Display(Name = "Character name")]
        public string Name
        { get; set; }

        [Required]
        [Display(Name = "Health")]
        public int Health { get; set; }
    }
}