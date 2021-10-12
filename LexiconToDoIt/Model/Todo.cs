namespace LexiconToDoIt.Model
{
	public class Todo
	{
		// Identifies the todo
		private readonly int todoId;
		// Descibes what to do
		private string description;
		// Has the todo become a isdone
		private bool done = false;
		// Who is should do
		Person assignee;

		public int TodoId => todoId;
		public string Description { get => description; set => description = value; }
		public Person Assignee { get => assignee; set => assignee = value; }
		public bool Done { get => done; set => done = value; }

		// Constructor to create a todo, that is undone.
		public Todo(int todoId, string description)
		{
			this.todoId = todoId;
			Description = description;
		}

	}
}
