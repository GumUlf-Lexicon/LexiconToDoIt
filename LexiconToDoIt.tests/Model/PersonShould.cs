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
		[InlineData(null, null)]
		[InlineData(null, "Doe")]
		[InlineData("Jane", null)]
		[InlineData(null, "")]
		[InlineData("", null)]
		[InlineData("", "")]
		[InlineData("", "Doe")]
		[InlineData("Joe", "")]
		public void NotAllowANullOrEmptyNames(string firstName, string lastName)
		{
			_ = Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, 0));
		}
	}
}