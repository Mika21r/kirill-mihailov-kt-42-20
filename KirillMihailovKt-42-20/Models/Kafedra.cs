namespace KirillMihailovKt_42_20.Models
{
    public class Kafedra
    {
        public int KafedraId { get; set; }
        public string? KafedraName { get; set; }
        public DateTime DateFoundation { get; set; }

        public int PrepodCount {  get; set; }

        public List<Prepod>? Prepod { get; set; }
    }
}
