using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Models
{
    public class Book
    {
        
        public int Id { get; set; }
        public string? Photo {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } 
        public string Author { get; set; }
        public int? UserId { get; set; } 

      
        [ForeignKey("UserId")]
        public User? User { get; set; } 
    }
}
