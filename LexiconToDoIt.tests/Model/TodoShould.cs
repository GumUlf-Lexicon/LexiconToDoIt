using System;
using Xunit;
using LexiconToDoIt.Model;

namespace LexiconToDoIt.Tests.Model
{
	public class TodoShould
	{
		Todo sut;
		int todoId;
		string decription;

		// Creates shareble objects between the tests
		public TodoShould()
		{
			todoId = 5;
			decription = "Do a test!";
			sut = new Todo(todoId, decription);
		}

		[Fact]
		public void HaveSameIdAfterConstrution()
		{
			Assert.Equal(todoId, sut.TodoId);
		}

		[Fact]
		public void HaveSameDescriptionAfterConstrution()
		{
			Assert.Equal(decription, sut.Description);
		}

		[Fact]
		public void HaveDoneSetToFalseAfterContruction()
		{
			Assert.False(sut.Done);
		}

	}
}
