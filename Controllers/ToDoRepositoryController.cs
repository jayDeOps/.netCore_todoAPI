using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
	[Route("api/[controller]")]
	public class ToDoRepositoryController : Controller
	{

		private readonly ILogger<ToDoRepositoryController> _logger;

		public ToDoRepositoryController(IToDoRepository todoItems, 
						ILogger<ToDoRepositoryController> logger)
		{
			ToDoItems = todoItems;
			_logger	= logger;
		}

		public IToDoRepository ToDoItems { get; set; }

		[HttpGet]
		public IEnumerable<ToDoItem> GetAll()
		{
			return ToDoItems.GetAll();
		}

		[HttpGet("{Id}", Name = "GetToDo")]
		public IActionResult GetById(string Id)
		{
    			_logger.LogInformation("Getting item {0}", Id);
			var item = ToDoItems.Find(Id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}
	}
}
