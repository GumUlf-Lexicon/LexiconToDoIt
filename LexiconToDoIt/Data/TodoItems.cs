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

			// The array has no room for the new todo item so the array
			// has to be resized to make room.
			Array.Resize(ref todos, todos.Length + 1);

			// The new todo needs to be inserted into the todos array,
			// and is therefore inserted at the end of the array.
			todos[^1] = newTodo;

			return newTodo;
		}

		// Empties the TodoItems database
		public void Clear()
		{
			Array.Resize(ref todos, 0);
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
				// FindAll expects a bool and cannot handle
				// if t.Assignee is null. Therefore we check for it.
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


		// Removes a todo from TodoItems by Todo-object.
		// If todo exists and is removed, true is returned.
		// If todo doesn't exist false is returend.
		public bool RemoveTodoItem(Todo todoToRemove)
		{
			return RemoveTodoItemInTodosByIndex(Array.FindIndex(todos, todo => todo == todoToRemove));
		}

		// Removes a todo from TodoItems by todoId.
		// If todo exists and is removed, true is returned.
		// If todo doesn't exist false is returend.
		public bool RemoveTodoItem(int todoId)
		{
			return RemoveTodoItemInTodosByIndex(Array.FindIndex(todos, todo => todo.TodoId == todoId));
		}

		// Removes a todo from todos by array index.
		// If index exists and remove is successfull true is returned.
		// If index does not exist, is out of bounds, false is returned.
		private bool RemoveTodoItemInTodosByIndex(int index)
		{
			if(index == -1 || index >= todos.Length)
			{
				// The index is out of bounds
				return false;
			}

			if(index < todos.Length)
			{
				// The index is not the last in the array, so we have to move items
				Array.Copy(todos, index + 1, todos, index, todos.Length - index - 1);
			}

			// The array todos is to long, and the last position contains "garbage".
			// We fix that by resizing the array.
			Array.Resize(ref todos, todos.Length - 1);

			return true;
		}
	}
}
