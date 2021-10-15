using System;
using Xunit;
using LexiconToDoIt.Model;

namespace LexiconToDoIt.Tests.Model
{
	public class PersonShould
	{

		[Fact]
		public void BeAbleToCreateANewPerson()
		{
			// Arrange
			string firstName = "Jane";
			string lastName = "Doe";
			int personId = 42;

			// Act
			Person sut = new Person(firstName, lastName, personId);

			// Assert
			Assert.Equal(firstName, sut.FirstName);
			Assert.Equal(lastName, sut.LastName);
			Assert.Equal(personId, sut.PersonId);
		}

		[Theory]
		[InlineData(null, null, "Neither firstName nor lastName can be null or empty!")]
		[InlineData(null, "Doe", "firstName can not be null or empty!")]
		[InlineData("Jane", null, "lastName can not be null or empty!")]
		[InlineData(null, "", "Neither firstName nor lastName can be null or empty!")]
		[InlineData("", null, "Neither firstName nor lastName can be null or empty!")]
		[InlineData("", "", "Neither firstName nor lastName can be null or empty!")]
		[InlineData("", "Doe", "firstName can not be null or empty!")]
		[InlineData("Joe", "", "lastName can not be null or empty!")]
		public void NotAllowANullOrEmptyNamesInConstructor(string firstName, string lastName, string errorMessage)
		{
			ArgumentException exception = Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, 0));
			Assert.Equal(errorMessage, exception.Message);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotAllowFirstNameToBeSetToNullOrEmpty(string firstName)
		{
			// Arrange
			Person sut = new Person("Jane", "Doe", 42);
			string errorMessage = "FirstName can not be null or empty!";

			// Act and Assert
			ArgumentException exception = Assert.Throws<ArgumentException>(() => sut.FirstName = firstName);
			Assert.Equal(errorMessage, exception.Message);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void NotAllowLastNameToBeSetToNullOrEmpty(string lastName)
		{
			// Arrange
			Person sut = new Person("Jane", "Doe", 42);
			string errorMessage = "LastName can not be null or empty!";
			
			// Act and Assert
			ArgumentException exception = Assert.Throws<ArgumentException>(() => sut.LastName = lastName);
			Assert.Equal(errorMessage, exception.Message);
		}


	}
}