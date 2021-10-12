

namespace LexiconToDoIt.Data
{
	public class PersonSequencer
	{
		private static int personId = 0;

		public static int PersonId { get => personId;}

		// Get the next availible personId
		public static int nextPersonId()
		{
			return personId++;
		}

		// Reset the personId to 0
		public static void reset()
		{
			personId = 0;
		}
	}
}
