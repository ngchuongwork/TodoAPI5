using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Entities
{
    public class TodoList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        public string? description { get; set; }
        public DateTime? datetime { get; set; }
        public int? status { get; set; }
    }
}
