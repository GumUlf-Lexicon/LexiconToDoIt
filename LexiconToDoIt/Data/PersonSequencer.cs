namespace LexiconToDoIt.Data
{
	public class PersonSequencer
	{
		// To keep track of the lastly assigned personId
		private static int personId = 0;
		public static int PersonId => personId;

		// Get the next availible personId
		public static int NextPersonId()
		{
			return ++personId;
		}

		// Reset the personId to 0
		public static void Reset()
		{
			personId = 0;
		}
	}
}
