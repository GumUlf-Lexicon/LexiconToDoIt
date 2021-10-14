using LexiconToDoIt.Model;
using System;

namespace LexiconToDoIt.Data
{
	public class People
	{
		private static Person[] persons = new Person[0];

		public int Size()
		{
			return persons.Length;
		}

		public Person[] FindAll()
		{
			// Copy array to not return a referense to the original.
			Person[] returnPersonArray = new Person[persons.Length];
			Array.Copy(persons, returnPersonArray, persons.Length);

			return returnPersonArray;
		}

		// Finds and returns person by ID. If not found returns null.
		public Person FindById(int personId)
		{
			return Array.Find(persons, p => p.PersonId == personId);
		}

		// Creates a new person and inserts into the People database
		// Throws argument exception if firstName or/and lastName
		// is null or empty.
		public Person NewPerson(string firstName, string lastName)
		{
			// Names are checked so that they are correct and new person can be created
			if(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("Neither fistName or lastName may be null or empty!");
			}
			else if(string.IsNullOrEmpty(firstName))
			{
				throw new ArgumentException("firstName may not be null or empty!");
			}
			else if(string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("lastName may not be null or empty!");
			}

			// A new unique personId is needed to create the new person
			int personId = PersonSequencer.nextPersonId();

			Person newPerson = new Person(firstName, lastName, personId);

			// Resize the array so that there is room for a new person
			Array.Resize(ref persons, persons.Length + 1);

			// To get the database into a valid state with the new person
			persons[^1] = newPerson;
			
			return newPerson;
		}

		// Empties the People database
		public void Clear()
		{
			persons = Array.Empty<Person>();
		}

	}
}
