using System.Reflection;

namespace ToDoWebApp.Web.Models
{
	public class ToDoItem
	{
		public int Id { get; set; }
        public string Title { get; set; }
		public bool Completed { get; set; }
    }

}
