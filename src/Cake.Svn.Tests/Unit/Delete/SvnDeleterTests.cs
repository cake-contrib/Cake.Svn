using System;
using Cake.Svn.Tests.Fixtures.Delete;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Delete
{
    public sealed class SvnDeleterTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_NotThrow_If_Parameters_AreSet()
            {
                // Given
                var fixture = new SvnDeleterFixture();

                // When
                fixture.CreateDeleter();
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnDeleterFixture()
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateDeleter());
            }

            [Fact]
            public void Should_Throw_If_SvnClientAction_Is_Null()
            {
                // Given
                var fixture = new SvnDeleterFixture()
                {
                    GetSvnClient = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("clientFactoryMethod", () => fixture.CreateDeleter());
            }
        }

        public sealed class TheDeleteMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnDeleterFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.Delete());
            }

            [Fact]
            public void Should_Throw_If_FilePath_Is_Null()
            {
                // Given
                var fixture = new SvnDeleterFixture
                {
                    FilePath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("file", () => fixture.Delete());
            }

            [Fact]
            public void Should_Throw_If_DirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnDeleterFixture
                {
                    DirectoryPath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("directory", () => fixture.Delete());
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnDeleterFixture();

                // When
                fixture.Delete();

                // Then
                fixture.SvnClient.Received(1).Delete(fixture.DirectoryPath.ToString(), fixture.Settings);
                fixture.SvnClient.Received(1).Delete(fixture.FilePath.ToString(), fixture.Settings);
            }
        }
    }
}
