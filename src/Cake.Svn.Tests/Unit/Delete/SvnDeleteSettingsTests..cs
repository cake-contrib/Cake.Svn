using Cake.Svn.Delete;
using Xunit;

namespace Cake.Svn.Tests.Unit.Delete
{
    public sealed class SvnDeleteSettingsTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Not_Keep_Local_By_Default()
            {
                // Given, When
                var settings = new SvnDeleteSettings();

                // Then
                Assert.False(settings.KeepLocal);
            }

            [Fact]
            public void Should_Not_Force_By_Default()
            {
                // Given, When
                var settings = new SvnDeleteSettings();

                // Then
                Assert.False(settings.Force);
            }

            [Fact]
            public void Should_Set_ThrowOnCancel_By_Default()
            {
                // Given, When
                var settings = new SvnDeleteSettings();

                // Then
                Assert.True(settings.ThrowOnCancel);
            }

            [Fact]
            public void Should_Set_ThrowOnError_By_Default()
            {
                // Given, When
                var settings = new SvnDeleteSettings();

                // Then
                Assert.True(settings.ThrowOnError);
            }

            [Fact]
            public void Should_Set_ThrowOnWarning_By_Default()
            {
                // Given, When
                var settings = new SvnDeleteSettings();

                // Then
                Assert.False(settings.ThrowOnWarning);
            }
        }
    }
}
