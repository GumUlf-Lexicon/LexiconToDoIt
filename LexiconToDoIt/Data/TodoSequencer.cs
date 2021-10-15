namespace LexiconToDoIt.Data
{
	public class TodoSequencer
	{
		// To keep track of the lastly assigned todoId
		private static int todoId = 0;
		public static int TodoId  => todoId;

		// Get the next availible todoId
		public static int NextTodoId()
		{
			return ++todoId;
		}

		// Reset the todoId to 0
		public static void Reset()
		{
			todoId = 0;
		}
	}
}
