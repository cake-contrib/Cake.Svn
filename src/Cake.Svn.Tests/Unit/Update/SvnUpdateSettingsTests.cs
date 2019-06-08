using Cake.Svn.Update;
using Xunit;

namespace Cake.Svn.Tests.Unit.Update
{
    public sealed class SvnUpdateSettingsTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Set_Infity_Depth_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.Equal(SvnDepth.Infinity, settings.Depth);
            }

            [Fact]
            public void Should_Ignore_Externals_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.True(settings.IgnoreExternals);
            }

            [Fact]
            public void Should_Not_Overwrite_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.False(settings.AllowObstructions);
            }

            [Fact]
            public void Should_Set_Head_Revision_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.Null(settings.Revision);
            }

            [Fact]
            public void Should_Not_Update_Parents_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.False(settings.UpdateParents);
            }

            [Fact]
            public void Should_Not_Keep_Depth_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.False(settings.KeepDepth);
            }

            [Fact]
            public void Should_Not_Add_As_Modifications_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.False(settings.AddAsModifications);
            }

            [Fact]
            public void Should_Set_ThrowOnCancel_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.True(settings.ThrowOnCancel);
            }

            [Fact]
            public void Should_Set_ThrowOnError_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.True(settings.ThrowOnError);
            }

            [Fact]
            public void Should_Set_ThrowOnWarning_By_Default()
            {
                // Given, When
                var settings = new SvnUpdateSettings();

                // Then
                Assert.False(settings.ThrowOnWarning);
            }
        }
    }
}