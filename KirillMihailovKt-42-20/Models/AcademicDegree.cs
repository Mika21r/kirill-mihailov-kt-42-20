using System.Text.Json.Serialization;

namespace KirillMihailovKt_42_20.Models
{
    public class AcademicDegree
    {
        public int AcademicDegreeId { get; set; }
        public string? AcademicDegreeName { get; set; }
        [JsonIgnore]
        public List<Prepod>? Prepod { get; set; }
    }
}
