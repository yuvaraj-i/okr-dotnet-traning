using System;
using System.ComponentModel.DataAnnotations;

namespace okrDemoApp.Models
{
	public class Skill
	{
        [Key]
        public int skillId { get; set; }
        [Required]
        [StringLength(1000)]
        public String? skillDescription { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}

