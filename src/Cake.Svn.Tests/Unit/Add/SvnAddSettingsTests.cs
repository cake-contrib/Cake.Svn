using Cake.Svn.Add;
using Xunit;

namespace Cake.Svn.Tests.Unit.Add
{
    public sealed class SvnAddSettingsTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Set_Infity_Depth_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.Equal(SvnDepth.Infinity, settings.Depth);
            }

            [Fact]
            public void Should_Add_Parents_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.True(settings.AddParents);
            }

            [Fact]
            public void Should_Not_Force_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.False(settings.Force);
            }

            [Fact]
            public void Should_Not_Auto_Props_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.True(settings.AutoProperties );
            }

            [Fact]
            public void Should_Not_Ignore_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.True(settings.Ignore);
            }

            [Fact]
            public void Should_Set_ThrowOnCancel_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.True(settings.ThrowOnCancel);
            }

            [Fact]
            public void Should_Set_ThrowOnError_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.True(settings.ThrowOnError);
            }

            [Fact]
            public void Should_Set_ThrowOnWarning_By_Default()
            {
                // Given, When
                var settings = new SvnAddSettings();

                // Then
                Assert.False(settings.ThrowOnWarning);
            }
        }
    }
}
