namespace LexiconToDoIt.Data
{
	public class TodoSequencer
	{
		private static int todoId = 0;
		public static int TodoId  => todoId;

		// Get the next availible todoId
		public static int nextTodoId()
		{
			return todoId++;
		}

		// Reset the todoId to 0
		public static void zeroOut() // You said to use different method names. :-D
		{
			todoId = 0;
		}
	}
}
