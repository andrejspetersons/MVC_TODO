using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Web.Context;
using ToDoWebApp.Web.Services;

namespace ToDoWebApp.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContextPool<ToDoDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("ToDo"))
				);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddTransient<IToDoServices, ToDoServices>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
