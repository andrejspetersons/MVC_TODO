using ToDoWebApp.Web.Models;

namespace ToDoWebApp.Web.Services
{
    public interface IToDoServices
    {
        public ToDoItem AddToDo(string title);
        public List<ToDoItem> GetTodos();
        public bool DeleteToDo(int id);
        public bool ToggleToDo(int id,bool completed);
    }
}
