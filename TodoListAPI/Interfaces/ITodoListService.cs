using TodoListAPI.Entities;
using TodoListAPI.Models;

namespace TodoListAPI.Implements
{
    public interface ITodoListService
    {
        public IEnumerable<TodoList> GetAll();
        public TodoList Get(int id);
        public TodoList Post(FormTodoListView _TodoList);
        public int Put(int id, FormTodoListView updatedTodoList);
        public int Delete (int id);
    }
}
