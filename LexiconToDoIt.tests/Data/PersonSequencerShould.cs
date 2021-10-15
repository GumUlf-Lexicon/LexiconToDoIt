using LexiconToDoIt.Data;
using Xunit;

namespace LexiconToDoIt.Tests.Data
{
	public class PersonSequencerShould
	{
		[Fact]
		public void IncreaseIdWithNextPersonId()
		{
			// Arrange 
			int before = PersonSequencer.PersonId;

			// Act
			_ = PersonSequencer.NextPersonId();
			int after = PersonSequencer.PersonId;

			// Assert
			Assert.True(before < after);
		}

		[Fact]
		public void ReturnTheUpdatedNextPersonIdWithNextPersonId()
		{
			// Arrange
			int before = PersonSequencer.PersonId;

			// Act
			int returnedPersonId = PersonSequencer.NextPersonId();

			// Assert
			Assert.Equal(before + 1, returnedPersonId);
		}

		[Fact]
		public void SetPersonIdToZeroWithReset()
		{
			// Arrange
			// Getting PersonId to be larger than 0 before reset
			_ = PersonSequencer.NextPersonId();
			_ = PersonSequencer.NextPersonId();
			int before = PersonSequencer.PersonId;

			// Act
			PersonSequencer.Reset();
			int after = PersonSequencer.PersonId;

			// Assert
			// If personId already is zero, the test is meaningless
			Assert.True(before != 0);
			Assert.Equal(0, after);
		}

	}
}