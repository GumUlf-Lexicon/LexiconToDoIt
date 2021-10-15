using LexiconToDoIt.Model;
using System;

namespace LexiconToDoIt.Data
{
	public class People
	{
		// persons are used an database to store the persons.
		private static Person[] persons = new Person[0];

		// Returns the number of persons stored.
		public int Size()
		{
			return persons.Length;
		}

		// Returns an array with all people, or if none are found
		// an empty array is returned.
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

		// Creates a new person and inserts into the People database.
		// The newly created person is returned.
		// Throws argument exception if firstName or/and lastName
		// is null or empty.
		public Person NewPerson(string firstName, string lastName)
		{
			// Names are checked so that they are correct and new person can be created
			if(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("Neither firstName nor lastName can be null or empty!");
			}
			else if(string.IsNullOrEmpty(firstName))
			{
				throw new ArgumentException("firstName can not be null or empty!");
			}
			else if(string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("lastName can not be null or empty!");
			}

			// A new unique personId is needed to create the new person
			int personId = PersonSequencer.NextPersonId();

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
