using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gyakorlas.Pages.Notification
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public TodoItemState State { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}