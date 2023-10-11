using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Keep_Note4.Model
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public string NoteStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public Category category { get; set; }

        public int CreatedBy { get; set; }
        public User user { get; set; }

        public int ReminderId { get; set; }
        public Reminder reminder { get; set; }
    }
}
