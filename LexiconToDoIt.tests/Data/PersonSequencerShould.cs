using Xunit;
using LexiconToDoIt.Data;

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
			int after = PersonSequencer.nextPersonId();

			// Assert
			Assert.Equal(before + 1, after);
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