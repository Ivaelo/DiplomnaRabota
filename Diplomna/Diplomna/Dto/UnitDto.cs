using System.ComponentModel.DataAnnotations;

namespace Diplomna.Dto
{
    public class UnitDto
    {
        public int Unitid { get; set; }
        public string UnitName { get; set; }
        public string test { get; set; }

        public int CourseId { get; set; }
    }
}
