using Cake.Svn.Info;
using Xunit;

namespace Cake.Svn.Tests.Unit.Export
{
    public sealed class SvnInfoSettingsTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Set_Infity_Depth_By_Default()
            {
                // Given, When
                var settings = new SvnInfoSettings();

                // Then
                Assert.Equal(SvnDepth.Infinity, settings.Depth);
            }

            [Fact]
            public void Should_RetrieveActualOnly_By_Default()
            {
                // Given, When
                var settings = new SvnInfoSettings();

                // Then
                Assert.True(settings.RetrieveActualOnly);
            }

            [Fact]
            public void Should_RetrieveExcluded_By_Default()
            {
                // Given, When
                var settings = new SvnInfoSettings();

                // Then
                Assert.True(settings.RetrieveExcluded);
            }

            [Fact]
            public void Should_Not_IncludeExternals_By_Default()
            {
                // Given, When
                var settings = new SvnInfoSettings();

                // Then
                Assert.False(settings.IncludeExternals);
            }

            [Fact]
            public void Should_Set_Revision_Minus_One_By_Default()
            {
                // Given, When
                var settings = new SvnInfoSettings();

                // Then
                Assert.Equal(-1, settings.Revision);
            }
        }
    }
}
