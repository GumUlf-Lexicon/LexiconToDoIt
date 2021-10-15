using LexiconToDoIt.Data;
using Xunit;

namespace LexiconToDoIt.Tests.Data
{
	public class TodoSequencerShould
	{
		[Fact]
		public void IncreaseIdWithWithNextTodoId()
		{
			// Arrange
			int before = TodoSequencer.TodoId;

			// Act
			_ = TodoSequencer.NextTodoId();
			int after = TodoSequencer.TodoId;

			// Assert
			Assert.True(before < after);
		}

		[Fact]
		public void ReturnTheNextTodoIdWithNextTodoId()
		{
			// Arrange
			int before = TodoSequencer.TodoId;

			// Act
			int returnedTodoId = TodoSequencer.NextTodoId();

			// Assert
			Assert.Equal(before + 1, returnedTodoId);

		}

		[Fact]
		public void SetTodoIdToZeroWithReset()
		{
			// Arrange
			// Getting TodoId to be larger than 0 before reset
			_ = TodoSequencer.NextTodoId();
			_ = TodoSequencer.NextTodoId();
			int before = TodoSequencer.TodoId;

			// Act
			TodoSequencer.Reset();
			int after = TodoSequencer.TodoId;

			// Assert
			// If TodoId already is zero, the test is meaningless
			Assert.True(before != 0);
			Assert.Equal(0, after);
		}
	}
}
