using LexiconToDoIt.Model;
using System;

namespace LexiconToDoIt.Data
{
	public class TodoItems
	{

		private static Todo[] todos = new Todo[0];

		public int Size()
		{
			return todos.Length;
		}

		public Todo[] FindAll()
		{
			// Copy array to not return a referense to the original.
			Todo[] returnTodoArray = new Todo[todos.Length];
			Array.Copy(todos, returnTodoArray, todos.Length);

			return returnTodoArray;
		}

		// Finds and returns a todo by ID. If not found returns null.
		public Todo FindById(int todoId)
		{
			return Array.Find(todos, t => t.TodoId == todoId);
		}

		// Creates a new todo and inserts into the TodoItems database
		public Todo NewTodo(string todoDescription)
		{

			// A new unique todoId is needed to create the new todoItem
			int todoId = TodoSequencer.nextTodoId();

			Todo newTodo = new Todo(todoId, todoDescription);

			// Resize the array so that there is room for a new todo item
			Array.Resize(ref todos, todos.Length + 1);

			// To get the array into a valid state with the new person
			todos[^1] = newTodo;

			return newTodo;
		}

		// Empties the TodoItems database
		public void Clear()
		{
			todos = Array.Empty<Todo>();
		}


	}
}
