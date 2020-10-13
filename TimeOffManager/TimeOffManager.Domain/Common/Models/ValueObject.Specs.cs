namespace TimeOffManager.Domain.Common.Models
{
    using FluentAssertions;
    using Vacations.Models.Requests;
    using Xunit;

    public class ValueObjectSpec
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new Options(true, true, true, true);
            var second = new Options(true, true, true, true);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new Options(true, true, true, false);
            var second = new Options(true, true, true, true);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}