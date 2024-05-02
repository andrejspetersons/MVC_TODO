using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Web.Services;

namespace ToDoWebApp.Web.Controllers
{
    public class ToDoItemController : Controller
    {
        private IToDoServices _todoservices;
        public ToDoItemController(IToDoServices todoServices)
        {
            _todoservices = todoServices;
        }

        public IActionResult Index()
        {
            var todos = _todoservices.GetTodos();
            return View(todos);
        }

        [HttpPost]
        public IActionResult AddTodo(string title)
        {
            var todo = _todoservices.AddToDo(title);
            if (todo != null)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        [HttpGet]
        public IActionResult DeleteTodo(int id)
        {
            if ( _todoservices.DeleteToDo(id))
            {
                return RedirectToAction("Index");
            }

            return NotFound(id);
        }

        [HttpPost]
        public IActionResult ToggleTodo(int id,bool completed)
        {
            if (_todoservices.ToggleToDo(id,completed))
            {
                return RedirectToAction("Index");
            }

            return NotFound(id);
        }



    }
}
