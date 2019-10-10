using Cake.Svn.Vacuum;
using Xunit;

namespace Cake.Svn.Tests.Unit.Vacuum
{
    public sealed class SvnVacuumSettingsTests
    {
        /// <summary>
        /// Ensures the constructor sets the settings to the correct defaults,
        /// which are the same defaults SharpSVN uses.
        /// </summary>
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Not_Set_Include_Externals_By_Default()
            {
                // Given, When
                var settings = new SvnVacuumSettings();

                // Then
                Assert.False(settings.IncludeExternals);
            }
        }
    }
}
