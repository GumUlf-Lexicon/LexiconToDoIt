using LexiconToDoIt.Data;
using Xunit;

namespace LexiconToDoIt.Tests.Data
{
	public class PersonSequencerShould
	{
		[Fact]
		public void IncreaseIdWithOneWithNextPersonId()
		{
			// Arrange 
			int before = PersonSequencer.PersonId;

			// Act
			int ReturnedPersonId = PersonSequencer.nextPersonId();
			int after = PersonSequencer.PersonId;

			// Assert
			Assert.True(before < after);
			Assert.Equal(ReturnedPersonId + 1, after);
		}

		[Fact]
		public void TheCurrentNextPersonIdWithNextPersonId()
		{
			// Arrange
			int current = PersonSequencer.PersonId;

			// Act
			int returnedPersonId = PersonSequencer.nextPersonId();

			// Assert
			Assert.Equal(current, returnedPersonId);

		}

		[Fact]
		public void SetPersonIdToZeroWithReset()
		{
			// Arrange
			// Getting PersonId to be larger than 0 before reset
			_ = PersonSequencer.nextPersonId();
			_ = PersonSequencer.nextPersonId();
			int before = PersonSequencer.PersonId;

			// Act
			PersonSequencer.reset();
			int after = PersonSequencer.PersonId;

			// Assert
			// If personId already is zero, the test is meaningless
			Assert.True(before != 0);
			Assert.Equal(0, after);
		}

	}
}