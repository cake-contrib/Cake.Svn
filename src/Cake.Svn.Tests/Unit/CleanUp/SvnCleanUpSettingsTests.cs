using Cake.Svn.CleanUp;
using Xunit;

namespace Cake.Svn.Tests.Unit.CleanUp
{
    public sealed class SvnCleanUpSettingsTests
    {
        /// <summary>
        /// Ensures the constructor sets the the settings
        /// to the correct defaults, which are the same defaults
        /// that SharpSVN uses.
        /// </summary>
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Set_Break_Locks_By_Default()
            {
                // Given, When
                var settings = new SvnCleanUpSettings();

                // Then
                Assert.True(settings.BreakLocks);
            }

            [Fact]
            public void Should_Set_Clear_Dav_Cache_By_Default()
            {
                // Given, When
                var settings = new SvnCleanUpSettings();

                // Then
                Assert.True(settings.ClearDavCache);
            }

            [Fact]
            public void Should_Set_Fix_Time_Stamps_By_Default()
            {
                // Given, When
                var settings = new SvnCleanUpSettings();

                // Then
                Assert.True(settings.FixTimeStamps );
            }

            [Fact]
            public void Should_Not_Set_Include_Externals_By_Default()
            {
                // Given, When
                var settings = new SvnCleanUpSettings();

                // Then
                Assert.False(settings.IncludeExternals);
            }

            [Fact]
            public void Should_Set_Vacuum_Pristines_By_Default()
            {
                // Given, When
                var settings = new SvnCleanUpSettings();

                // Then
                Assert.True(settings.VacuumPristines);
            }
        }
    }
}
