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

			// Creating a new empty array, to not return a reference to persons,
			// to not do unneeded work with copying the array if empty.
			if(persons.Length == 0)
				return Array.Empty<Person>();

			// Copying persons array to not return a reference to the original.
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
			Array.Resize(ref persons, 0);
		}

		// Removes a person from People by Person-object.
		// If person exists and is removed, true is returned.
		// If person doesn't exist false is returned.
		public bool RemovePerson(Person personToRemove)
		{
			return RemovePersonInPersonsByIndex(Array.FindIndex(persons, person => person.Equals(personToRemove)));
		}

		// Removes a person from People by PersonId.
		// If person exists and is removed, true is returned.
		// If person doesn't exist false is returned.
		public bool RemovePerson(int personId)
		{
			return RemovePersonInPersonsByIndex(Array.FindIndex(persons, person => person.PersonId == personId));
		}

		// Removes a person from persons by array index.
		// If index exists and remove is successfull true is returned.
		// If index does not exist, is out of bounds, false is returned.
		private bool RemovePersonInPersonsByIndex(int index)
		{
			// The index is out of bounds
			if(index == -1 || index >= persons.Length)
			{
				return false;
			}

			// The index is not the last in the array, so we have move items
			if(index < persons.Length)
			{
				Array.Copy(persons, index + 1, persons, index, persons.Length - index - 1);
			}

			// The array persond is to long, and the last position contains "garbage".
			// We fix that by resizing the array.
			Array.Resize(ref persons, persons.Length - 1);

			return true;
		}

	}
}
