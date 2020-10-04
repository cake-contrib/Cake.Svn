using Cake.Svn.Revert;
using Xunit;

namespace Cake.Svn.Tests.Unit.Revert
{
    public sealed class SvnRevertSettingsTests
    {
        /// <summary>
        /// Ensures the constructor sets the settings
        /// to the correct defaults, which are the same defaults
        /// that SharpSVN uses.
        /// </summary>
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_ChangeLists_Be_Empty_By_default()
            {
                // Given, When
                var settings = new SvnRevertSettings();

                // Then
                Assert.Equal(0, settings.ChangeLists.Count);
            }

            [Fact]
            public void Should_MetaDataOnly_Be_False_By_default()
            {
                // Given, When
                var settings = new SvnRevertSettings();

                // Then
                Assert.False(settings.MetaDataOnly);
            }

            [Fact]
            public void Should_ClearChangeLists_Be_False_By_Default()
            {
                // Given, When
                var settings = new SvnRevertSettings();

                // Then
                Assert.False(settings.ClearChangeLists);
            }

            [Fact]
            public void Should_Depth_Be_Empty_By_Default()
            {
                // Given, When
                var settings = new SvnRevertSettings();

                // Then
                Assert.Equal(SvnDepth.Empty, settings.Depth);
            }
        }
    }
}
