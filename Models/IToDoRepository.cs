using System.Collections.Generic;

namespace ToDoAPI.Models
{
	public interface IToDoRepository
	{
		void Add(ToDoItem item);

		IEnumerable<ToDoItem> GetAll();

		ToDoItem Find(string key);

		ToDoItem Remove(string key);

		void Update(ToDoItem item);
	}
}
