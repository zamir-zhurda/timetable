using System.Collections.Generic;
namespace timetable.Resources
{
    public class DegetLendetResource
    {
        public int DegaId { get; set; }
        public string DegaName { get; set; }
        public IList<LendetResource> Lendet { get; set; }
    }
}