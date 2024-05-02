using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Web.Context;
using ToDoWebApp.Web.Models;

namespace ToDoWebApp.Web.Services
{
    public class ToDoServices:IToDoServices
    {
        private readonly ToDoDbContext _context;

        public ToDoServices(ToDoDbContext context)
        {
            _context = context;    
        }

        public ToDoItem AddToDo(string title)
        {
            var todo = new ToDoItem { Title = title, Completed = false };
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public List<ToDoItem> GetTodos()
        {
            return _context.Todos.ToList();
        }

        public bool DeleteToDo(int id)
        {
            var item = _context.Todos.Find(id);

            if (item == null)
            {
                return false;
            }
            else
            {
                _context.Todos.Remove(item);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ToggleToDo(int id,bool completed)
        {
            var item = _context.Todos.Find(id);

            if (item == null)
            {
                return false;
            }
            else
            {
                item.Completed = completed;
                _context.SaveChanges();
                return true;
            }
        }
    }
}
