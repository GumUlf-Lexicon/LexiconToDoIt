using System;
using Xunit;
using LexiconToDoIt.Model;

namespace LexiconToDoIt.Tests.Model
{
	public class TodoShould
	{
		[Fact]
		public void HaveSameIdAfterConstrution()
		{
			// Arrange
			int todoId = 5;
			string decription = "Do a test!";
			
			// Act
			Todo sut = new Todo(todoId, decription);

			// Assert
			Assert.Equal(todoId, sut.TodoId);
		}

		[Fact]
		public void HaveSameDescriptionAfterConstrution()
		{
			// Arrange
			int todoId = 5;
			string decription = "Do a test!";

			// Act
			Todo sut = new Todo(todoId, decription);

			// Assert
			Assert.Equal(decription, sut.Description);
		}

		[Fact]
		public void HaveDoneSetToFalseAfterContruction()
		{
			// Arrange
			int todoId = 5;
			string decription = "Do a test!";

			// Act
			Todo sut = new Todo(todoId, decription);

			// Assert
			Assert.False(sut.Done);
		}

	}
}
