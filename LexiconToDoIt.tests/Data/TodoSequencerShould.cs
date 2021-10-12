using LexiconToDoIt.Data;
using Xunit;

namespace LexiconToDoIt.Tests.Data
{
	public class TodoSequencerShould
	{
		[Fact]
		public void IncreaseIdWithOneWithNextTodoId()
		{
			// Arrange
			int before = TodoSequencer.TodoId;

			// Act
			_ = TodoSequencer.nextTodoId();
			int after = TodoSequencer.TodoId;

			// Assert
			Assert.Equal(before + 1, after);
		}

		[Fact]
		public void TheCurrentNextTodoIdWithNextTodoId()
		{
			// Arrange
			int current = TodoSequencer.TodoId;

			// Act
			int returnedTodoId = TodoSequencer.nextTodoId();

			// Assert
			Assert.Equal(current, returnedTodoId);

		}

		[Fact]
		public void SetTodoIdToZeroWithZeroOut()
		{
			// Arrange
			// Getting TodoId to be larger than 0 before reset
			_ = TodoSequencer.nextTodoId();
			_ = TodoSequencer.nextTodoId();
			int before = TodoSequencer.TodoId;

			// Act
			TodoSequencer.zeroOut();
			int after = TodoSequencer.TodoId;

			// Assert
			// If TodoId already is zero, the test is meaningless
			Assert.True(before != 0);
			Assert.Equal(0, after);
		}
	}
}
