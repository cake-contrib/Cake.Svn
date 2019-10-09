using System;
using Cake.Svn.Tests.Fixtures.Vacuum;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Vacuum
{
    public sealed class SvnVacuumTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Not_Throw_If_Parameters_Are_Set()
            {
                // Given
                var fixture = new SvnVacuumFixture();

                // When
                fixture.CreateSvnVacuum();
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnVacuumFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateSvnVacuum());
            }

            [Fact]
            public void Should_Throw_If_SvnClient_Is_Null()
            {
                // Given
                var fixture = new SvnVacuumFixture
                {
                    GetSvnClient = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("clientFactoryMethod", () => fixture.CreateSvnVacuum());
            }
        }

        public sealed class TheVacuumMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnVacuumFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.Vacuum());
            }

            [Fact]
            public void Should_Throw_If_DirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnVacuumFixture
                {
                    DirectoryPath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("path", () => fixture.Vacuum());
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnVacuumFixture();

                // When
                fixture.Vacuum();

                // Then
                fixture.SvnClient.Received(1).Vacuum(fixture.DirectoryPath.ToString(), fixture.Settings);
            }
        }
    }
}
