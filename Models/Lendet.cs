using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timetable.Models
{
    public partial class Lendet
    {
        public int Id { get; set; }
        [StringLength(250)]
        public string Lenda { get; set; }
        [Column("DEGA")]
        [StringLength(250)]
        public string Dega { get; set; }
    }
}
