using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timetable.Models
{
    public partial class Deget
    {
        public int Id { get; set; }
        [StringLength(250)]
        public string Dega { get; set; }
    }
}
