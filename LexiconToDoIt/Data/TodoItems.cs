using LexiconToDoIt.Model;
using System;

namespace LexiconToDoIt.Data
{
	public class TodoItems
	{
		// To be used as an database to store the todos
		private static Todo[] todos = new Todo[0];

		// Returns the number of todos
		public int Size()
		{
			return todos.Length;
		}

		// Returns an Array with all found Todos, if non found an
		// empty array is returned.
		public Todo[] FindAll()
		{
			// Copy array to not return a referense to the original array.
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
			int todoId = TodoSequencer.NextTodoId();

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

		// Returns all Todos that have the asked for done status (true
		// or false). An empty array is retrued if no todos are found.
		public Todo[] FindByDoneStatus(bool doneStatus)
		{
			return Array.FindAll(todos, t => t.Done == doneStatus);
		}

		// Finds and returns all Todos that are assigned to persons
		// with a specific ID. An empty array is returned if no todos
		// assigned to the specific ID is found.
		public Todo[] FindByAssignee(int personId)
		{
			return Array.FindAll(todos, t =>
			{
				// FindAll expects a bool and cannot handle
				// if t.Assignee is null. Therefore we check for it.
				if(t.Assignee is null) 
					return false;

				return t.Assignee.PersonId == personId;
			});
		}

		// Finds and returns all Todos that are assigned to a specific
		// person. An empty array is returned if no todos assigned to
		// the specific person is found.
		public Todo[] FindByAssignee(Person assigne)
		{
			return Array.FindAll(todos, t =>
			{
				if(t.Assignee is null)
					return false;

				return t.Assignee == assigne;
			});
		}

		// Finds and returns all todos that are unassigned. If none
		// are found an empty array is returned.
		public Todo[] FindUnassignedTodoItems()
		{
			return Array.FindAll(todos, t => t.Assignee is null);
		}

	}
}
