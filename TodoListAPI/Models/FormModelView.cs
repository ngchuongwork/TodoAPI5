using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Models
{
        public class FormTodoListView
        {

            public int id { get; set; }
            public string description { get; set; }

            public DateTime datetime { get; set; }
            public int? status { get; set; }
    }
}
