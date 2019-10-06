using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Svn.Tests.Fixtures.CleanUp;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.CleanUp
{
    public sealed class SvnCleanUperTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Not_Throw_If_Parameters_Are_Set()
            {
                // Given
                var fixture = new SvnCleanUpFixture();

                // When
                fixture.CreateCleanUper();
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnCleanUpFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>( "environment", () => fixture.CreateCleanUper() );
            }

            [Fact]
            public void Should_Throw_If_SvnClient_Is_Null()
            {
                // Given
                var fixture = new SvnCleanUpFixture
                {
                    GetSvnClient = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>( "clientFactoryMethod", () => fixture.CreateCleanUper() );
            }
        }

        public sealed class TheCleanUpMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnCleanUpFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>( "settings", () => fixture.CleanUp() );
            }

            [Fact]
            public void Should_Throw_If_DirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnCleanUpFixture
                {
                    DirectoryPath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>( "path", () => fixture.CleanUp() );
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnCleanUpFixture();

                // When
                fixture.CleanUp();

                // Then
                fixture.SvnClient.Received( 1 ).CleanUp( fixture.DirectoryPath.ToString(), fixture.Settings );
            }
        }
    }
}
