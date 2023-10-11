using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Keep_Note4.Model
{

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryCreatedBy { get; set; }
        public DateTime CategoryCreatedAt { get; set; } = DateTime.Now;

        public ICollection<Note> notes { get; set; }
        public User users { get; set; }
    }
}
