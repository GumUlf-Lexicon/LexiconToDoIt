using System;
namespace LexiconToDoIt.Model
{
	public class Todo: IEquatable<Todo>
	{
		// To identifie the todo
		private readonly int todoId;
		public int TodoId => todoId;

		// To descibe what to do
		private string description;
		public string Description { get => description; set => description = value; }

		// To know if todo become isdone
		private bool done = false;
		public bool Done { get => done; set => done = value; }

		// To know who is reponisble to do the todo
		Person assignee;
		public Person Assignee { get => assignee; set => assignee = value; }


		// Constructor to create a todo, that is undone.
		public Todo(int todoId, string description)
		{
			this.todoId = todoId;
			Description = description;
		}


		// Implementing comparisons to be able to make testing easier
		// Uses value equality

		public override bool Equals(object obj)
		{
			//Check for null and compare run-time types.
			if((obj is null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}

			return Equals((Todo)obj);
		}

		public bool Equals(Todo other)
		{
			return !(other is null)
				&& TodoId == other.TodoId
				&& Description == other.Description
				&& Done == other.Done
				&& Assignee == other.Assignee;

		}

		public override int GetHashCode()
		{
			return HashCode.Combine(todoId, description, done, assignee);
		}
	}
}
