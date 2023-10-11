using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Keep_Note4.Model
{

    public class Reminder
    {
        public int ReminderId { get; set; }
        public string ReminderName { get; set; }
        public string ReminderDescription { get; set; }
        public string ReminderType { get; set; }
        public DateTime RemniderCreatedDate { get; set; } = DateTime.Now;

        public User users { get; set; }
        public ICollection<Note> notes { get; set; }

    }
}
