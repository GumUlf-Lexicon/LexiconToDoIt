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
					throw new ArgumentException("FirstName cannot be null or empty!");
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
					throw new ArgumentException("LastName cannot be null or empty!");
				}

				lastName = value;
			}
		}

		// Constructor for a person with that sets FirstName, LastName and PersonId
		// Throws ArguemtException if firstName or lastName is null or empty.
		public Person(string firstName, string lastName, int personId)
		{

			if(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("firstName and lastName cannot be null or empty!");
			}
			else if(string.IsNullOrEmpty(firstName))
			{
				throw new ArgumentException("firstName cannot be null or empty!");
			}
			else if(string.IsNullOrEmpty(lastName))
			{
				throw new ArgumentException("lastName cannot be null or empty!");
			}

			FirstName = firstName;
			LastName = lastName;
			this.personId = personId;
		}


		// Implementing comparisons to be able to make testing easier
		public static bool operator ==(Person a, Person b)
		{
			if(a == null && b == null)
				return true;
			else if(a == null || b == null)
				return false;

			return a.FirstName == b.FirstName
				&& a.LastName == b.LastName
				&& a.PersonId == b.PersonId;
		}

		public static bool operator !=(Person a, Person b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			//Check for null and compare run-time types.
			if((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Person person = (Person)obj;
				return this == person;
			}
		}

		public bool Equals(Person other)
		{
			return (other != null) && (this == other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(personId, firstName, lastName);
		}
	}
}
