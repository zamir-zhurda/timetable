using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timetable.Models
{
    public partial class Ditet
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Dita { get; set; }
    }
}
