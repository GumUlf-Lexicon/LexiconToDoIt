using System;
using Xunit;
using LexiconToDoIt.Model;

namespace LexiconToDoIt.Tests.Model
{
	public class PersonShould
	{
		[Fact]
		public void NotHaveTheSameIdAsAnotherPerson()
		{
			Person sut = new Person();
			Person person2 = new Person();

			Assert.NotEqual(sut.PersonId, person2.PersonId);
		}

		[Fact]
		public void HaveNameUnkownAndUnkownAsNewDefault()
		{
			Person sut = new Person();

			Assert.Equal("Unkown", sut.FirstName);
			Assert.Equal("Unkown", sut.LastName);
		}

		[Fact]
		public void NotHaveEmptyOrNullNamesAsNewDefault()
		{
			Person sut = new Person();

			Assert.NotEmpty(sut.FirstName);
			Assert.NotNull(sut.FirstName);
			Assert.NotEmpty(sut.LastName);
			Assert.NotNull(sut.LastName);
		}

		[Fact]
		public void NotAllowEmptyNames()
		{
			_ = Assert.Throws<ArgumentException>(() => new Person("", ""));
		}

		[Fact]
		public void NotAllowNullNamesAsNew()
		{
			_ = Assert.Throws<ArgumentException>(() => new Person(null, null));
		}

		[Fact]
		public void NotAllowToSetNamesToEmpty(){
			Person sut = new Person();
			_ = Assert.Throws<ArgumentException>(() => sut.FirstName = string.Empty);
			_ = Assert.Throws<ArgumentException>(() => sut.LastName = string.Empty);
			_ = Assert.Throws<ArgumentException>(() => sut.FirstName = "");
			_ = Assert.Throws<ArgumentException>(() => sut.LastName = "");

		}

		[Fact]
		public void NotAllowToSetNamesToNull()
		{
			Person sut = new Person();
			_ = Assert.Throws<ArgumentException>(() => sut.FirstName = null);
			_ = Assert.Throws<ArgumentException>(() => sut.LastName = null);
		}


	}
}
