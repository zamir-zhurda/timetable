using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timetable.Models
{
    public partial class ImportLendet
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Dega { get; set; }
        public int Viti { get; set; }
        [Required]
        [StringLength(250)]
        public string Lenda { get; set; }
        [Required]
        [StringLength(250)]
        public string Paraleli { get; set; }
        [Required]
        [StringLength(250)]
        public string Tipi { get; set; }
        [Required]
        [StringLength(250)]
        public string Pedagog { get; set; }
        public int Kapur { get; set; }
        public int IdTipi { get; set; }
        public int Zgjedhje { get; set; }
    }
}
