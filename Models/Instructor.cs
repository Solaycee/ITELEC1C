namespace DyITELEC1C.Models
{   public enum Rank
    {
        Instructor, AssistProf, Prof
    }
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateHired { get; set;}
        public Rank Rank { get; set;}
        public String IsTenured { get; set;}
    }
}
