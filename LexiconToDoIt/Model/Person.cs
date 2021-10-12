using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconToDoIt.Model
{
	public class Person
	{
		private static int nextFreePersonId = 0;
		private readonly int personId;
		private string firstName, lastName;

		// Property to get a persons ID number
		public int PersonId => personId;
		
		// Property to set and get a persons firstname
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

		// Constructor for a person with Firstname firstName and LastName lastName
		public Person(string firstName, string lastName)
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
			personId = nextFreePersonId++;
		}

		// Constructor for a default person with "Unkown" as FirstName and LastName.
		public Person()
		{
			FirstName = "Unkown";
			LastName = "Unkown";
			personId = nextFreePersonId++;
		}

	}
}
