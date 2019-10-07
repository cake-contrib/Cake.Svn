using Cake.Svn.Status;
using Xunit;

namespace Cake.Svn.Tests.Unit.Status
{

    public class SvnStatusSettingsTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Set_Infinity_Depth_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.Equal(SvnDepth.Infinity, settings.Depth);
            }

            [Fact]
            public void Should_IgnoreExternals_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.True(settings.IgnoreExternals);
            }

            [Fact]
            public void Should_Not_IgnoreWorkingCopyStatus_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.False(settings.IgnoreWorkingCopyStatus);
            }

            [Fact]
            public void Should_Not_KeepDepth_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.False(settings.KeepDepth);
            }

            [Fact]
            public void Should_Not_RetrieveAllEntries_ByDefault()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.False(settings.RetrieveAllEntries);
            }

            [Fact]
            public void Should_Not_RetrieveIgnoredEntries_ByDefault()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.False(settings.RetrieveIgnoredEntries);
            }

            [Fact]
            public void Should_Not_RetrieveRemoteStatus_ByDefault()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.False(settings.RetrieveRemoteStatus);
            }

            [Fact]
            public void Should_Set_Revision_To_Null_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.Null(settings.Revision);
            }

            [Fact]
            public void Should_Set_ThrowOnCancel_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.True(settings.ThrowOnCancel);
            }

            [Fact]
            public void Should_Set_ThrowOnError_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.True(settings.ThrowOnError);
            }

            [Fact]
            public void Should_Set_ThrowOnWarning_By_Default()
            {
                // Given, When
                var settings = new SvnStatusSettings();

                // Then
                Assert.False(settings.ThrowOnWarning);
            }
        }
    }
}
