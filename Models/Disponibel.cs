using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timetable.Models
{
    public partial class Disponibel
    {
        public int DitaId { get; set; }
        public int OraId { get; set; }
        public int KlasaId { get; set; }
        public bool Perdorur { get; set; }
    }
}
