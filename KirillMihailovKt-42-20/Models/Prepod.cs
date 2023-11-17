using System.Text.Json.Serialization;

namespace KirillMihailovKt_42_20.Models
{
    public class Prepod
    {
        public int PrepodId { get; set; }
        public string? FirstName { get; set; }  
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }

        public int KafedraId { get; set; }
        public int AcademicDegreeId { get; set; }
        [JsonIgnore]

        public Kafedra? Kafedra { get; set; }
        [JsonIgnore]
        public AcademicDegree? AcademicDegree { get; set; }

        public bool IsvalidPrepodFirstName()
        {
            if (FirstName.Length == 0 || FirstName.Length <= 1)
            {
                return false;
            }
            return true;
        }
    }
}
