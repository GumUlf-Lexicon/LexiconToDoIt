using LexiconToDoIt.Data;
using LexiconToDoIt.Model;
using System;
using Xunit;

namespace LexiconToDoIt.Tests.Data
{
	public class PeopleShould
	{


		private void ArrangePeople(out Person[] persons, out People people)
		{
			// Arrange

			// personId is set to -1 bc we don't know the real ID yet
			// The persons in persons will be replaced with new persons
			// with the correct ID set in the for-loop below.
			persons = new Person[4];
			persons[0] = new Person("Jane", "Doe", -1);
			persons[1] = new Person("Joe", "Doe", -1);
			persons[2] = new Person("Svea", "Svensson", -1);
			persons[3] = new Person("Sven", "Svensson", -1);

			people = new People();
			people.Clear();

			for(int i = 0; i < persons.Length; i++)
			{
				Person person = persons[i];
				persons[i] = people.NewPerson(person.FirstName, person.LastName);
			}
		}

		[Fact]
		public void HaveTheRightSize()
		{
			// Arrange
			ArrangePeople(out Person[] persons, out People people);

			// Act
			int peopleSize = people.Size();

			// Assert
			Assert.Equal(persons.Length, peopleSize);
		}

		[Fact]
		public void BeAbleToFindAllPersons()
		{
			// Arrange
			ArrangePeople(out Person[] persons, out People people);

			// Act
			Person[] sut = people.FindAll();

			// Assert
			Assert.Equal(persons.Length, sut.Length);

			foreach(Person person in persons)
			{
				Assert.Contains(sut, sutPerson => sutPerson == person);
			}
		}

		[Fact]
		public void BeAbleToFindPersonById()
		{
			// Arrange
			ArrangePeople(out Person[] persons, out People people);

			foreach(Person person in persons)
			{
				// Act
				Person sut = people.FindById(person.PersonId);

				// Assert
				Assert.Equal(person, sut);
			}
		}

		[Fact]
		public void BeAbleToCreateNewPerson()
		{
			// Arrange
			string firstName = "Kim";
			string lastName = "Karlsson";
			People people = new People();
			
			// Act
			Person sut = people.NewPerson(firstName, lastName);

			// Assert
			Assert.Equal(sut.FirstName, firstName);
			Assert.Equal(sut.LastName, lastName);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, "Doe")]
		[InlineData("Jane", null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "Doe")]
		[InlineData("Joe", "")]
		public void NotAllowANewPersonWithNullOrEmptyNames(string firstName, string lastName)
		{
			// Arrange
			People people = new People();

			// Act and Assert
			_ = Assert.Throws<ArgumentException>(() => people.NewPerson(firstName, lastName));

		}

		[Fact]
		public void BeAbleToGetCleared()
		{
			// Arrange
			ArrangePeople(out _, out People people);
			int peopleSizeBefore = people.Size();

			// Act
			people.Clear();

			// Assert
			Assert.True(peopleSizeBefore > 0);
			Assert.Equal(0, people.Size());
		}

	}
}
