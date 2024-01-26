using TodoListAPI.Entities;
using TodoListAPI.Implements;
using TodoListAPI.Models;

namespace TodoListAPI.Services
{
    public class TodoListService : ITodoListService
    {
        private EFDataContext _context;

        public TodoListService(EFDataContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
                TodoList todoItem = _context.TodoLists.Find(id);

                if (todoItem != null)
                {
                    _context.TodoLists.Remove(todoItem);
                    _context.SaveChanges();
                    return 1; // Deletion successful
                }
                else
                {
                    return 0; // Item not found
                }
        }

        public TodoList Get(int id )
        {
            return _context.TodoLists.Find(id);
        }

        public IEnumerable<TodoList> GetAll()
        {
            return _context.TodoLists.ToList();
        }

        public TodoList Post(FormTodoListView _TodoList)
        {
            var todoItem = new TodoList()
            {
                description = _TodoList.description,
                datetime = _TodoList.datetime,
                status = _TodoList.status
            };

            _context.TodoLists.Add(todoItem);

            try
            {
                _context.SaveChanges();
                return todoItem;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int Put(int id, FormTodoListView updatedTodoList)
        {
            var existingTodoList = _context.TodoLists.Find(id);

            if (existingTodoList == null)
            {
                return 0; // TodoList with the given id not found
            }

            // Update properties of the existingTodoList with values from updatedTodoList
            existingTodoList.description = updatedTodoList.description;
            existingTodoList.status = updatedTodoList.status;

            _context.TodoLists.Update(existingTodoList);
            _context.SaveChanges();

            return 1;
        }

        
    }
}
