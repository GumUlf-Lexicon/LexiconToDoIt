using System;

namespace LexiconToDoIt.Model
{
	public class Person: IEquatable<Person>
	{
		private readonly int personId;
		private string firstName, lastName;

		// Property to get a persons ID number
		public int PersonId => personId;

		// Property to set and get a persons firstname
		// Throws Argumet exception if trying to set to null or empty.
		public string FirstName
		{
			get => firstName;

			set
			{
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("FirstName can not be null or empty!");
				}

				firstName = value;
			}
		}

		// Property to set and get a persons lastname
		// Throws Argumet exception if trying to set to null or empty.
		public string LastName
		{
			get => lastName;

			set
			{
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("LastName can not be null or empty!");
				}

				lastName = value;
			}
		}

		// Constructor for a person with that sets FirstName, LastName and PersonId
		// Throws ArguemtException if firstName or lastName is null or empty.
		public Person(string firstName, string lastName, int personId)
		{
			// Neither the persons firstname or lastname may be null or empty
			// (Sorry Teller!)
			if(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("Neither firstName nor lastName can be null or empty!");
			}

			FirstName = firstName;
			LastName = lastName;
			this.personId = personId;
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

			return Equals((Person)obj);
		}

		public bool Equals(Person other)
		{
			return !(other is null)
				&& FirstName == other.FirstName
				&& LastName == other.LastName
				&& PersonId == other.PersonId;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(personId, firstName, lastName);
		}
	}
}
