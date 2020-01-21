using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timetable.Models
{
    public partial class Klasat
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Klasa { get; set; }
        public int? Kapaciteti { get; set; }
        public int? Tipi { get; set; }
        [StringLength(50)]
        public string Godina { get; set; }
        public int? Kati { get; set; }
        public bool Perdoret { get; set; }
        [StringLength(50)]
        public string KlasaNew { get; set; }
    }
}
