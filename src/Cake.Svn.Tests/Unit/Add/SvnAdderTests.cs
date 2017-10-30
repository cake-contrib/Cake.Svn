using System;
using Cake.Svn.Add;
using Cake.Svn.Tests.Fixtures.Add;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Add
{
    public sealed class SvnAdderTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Not_Throw_If_Paremeters_Are_Set()
            {
                // Given
                var fixture = new SvnAdderFixture{};

                // When
                fixture.CreateAdder();
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnAdderFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateAdder());
            }

            [Fact]
            public void Should_Throw_If_SvnClient_Is_Null()
            {
                // Given
                var fixture = new SvnAdderFixture
                {
                    GetSvnClient = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("clientFactoryMethod", () => fixture.CreateAdder());
            }
        }

        public sealed class TheAddMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnAdderFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.Add());
            }

            [Fact]
            public void Should_Throw_If_DirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnAdderFixture
                {
                    DirectoryPath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("directory", () => fixture.Add());
            }

            [Fact]
            public void Should_Throw_If_FilePath_Is_Null()
            {
                // Given
                var fixture = new SvnAdderFixture
                {
                    FilePath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("file", () => fixture.Add());
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnAdderFixture();

                // When
                fixture.Add();

                // Then
                fixture.SvnClient.Received(1).Add(fixture.DirectoryPath.ToString(), fixture.Settings);
                fixture.SvnClient.Received(1).Add(fixture.FilePath.ToString(), fixture.Settings);
            }
        }
    }
}
