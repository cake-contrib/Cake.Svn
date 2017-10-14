using Cake.Svn.Export;
using Xunit;

namespace Cake.Svn.Tests.Unit.Export
{
    public sealed class SvnExportSettingsTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Set_Infity_Depth_By_Default()
            {
                // Given, When
                var settings = new SvnExportSettings();

                // Then
                Assert.Equal(SvnDepth.Infinity, settings.Depth);
            }

            [Fact]
            public void Should_Ignore_Externals_By_Default()
            {
                // Given, When
                var settings = new SvnExportSettings();

                // Then
                Assert.True(settings.IgnoreExternals);
            }

            [Fact]
            public void Should_Not_Ignore_Keywords_By_Default()
            {
                // Given, When
                var settings = new SvnExportSettings();

                // Then
                Assert.False(settings.IgnoreKeywords);
            }

            [Fact]
            public void Should_Set_Default_LineStyle_By_Default()
            {
                // Given, When
                var settings = new SvnExportSettings();

                // Then
                Assert.Equal(SvnLineStyle.Default, settings.LineStyle);
            }

            [Fact]
            public void Should_Not_Overwrite_By_Default()
            {
                // Given, When
                var settings = new SvnExportSettings();

                // Then
                Assert.False(settings.Overwrite);
            }

            [Fact]
            public void Should_Set_Head_Revision_By_Default()
            {
                // Given, When
                var settings = new SvnExportSettings();

                // Then
                Assert.Equal(-1, settings.Revision);
            }
        }
    }
}
