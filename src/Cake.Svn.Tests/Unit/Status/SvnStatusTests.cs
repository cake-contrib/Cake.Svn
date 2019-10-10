using System;
using Cake.Svn.Status;
using Cake.Svn.Tests.Fixtures.Status;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Status
{
    public sealed class SvnStatusTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_NotThrow_If_Parameters_AreSet()
            {
                // Given
                var fixture = new SvnStatusFixture();

                // When
                fixture.CreateStatus();
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnStatusFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateStatus());
            }

            [Fact]
            public void Should_Throw_If_GetSvnClient_Is_Null()
            {
                // Given
                var fixture = new SvnStatusFixture
                {
                    GetSvnClient = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("clientFactoryMethod", () => fixture.CreateStatus());
            }
        }

        public sealed class TheStatusMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnStatusFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.Status());
            }

            [Fact]
            public void Should_Throw_If_DirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnStatusFixture
                {
                    DirectoryPath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("directoryPath", () => fixture.Status());
            }

            [Fact]
            public void Should_Throw_If_FilePath_Is_Null()
            {
                // Given
                var fixture = new SvnStatusFixture
                {
                    FilePath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("filePath", () => fixture.Status());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Null()
            {
                // Given
                var fixture = new SvnStatusFixture
                {
                    Settings = new SvnStatusSettings
                    {
                        Credentials = null
                    }
                };

                // When
                fixture.Status();

                // Then
                fixture.SvnClient.DidNotReceive().ForceCredentials(Arg.Any<SvnCredentials>());
            }

            [Fact]
            public void Should_Force_Credentials_If_Not_Null()
            {
                // Given
                SvnCredentials credentials = new SvnCredentials
                {
                    Username = "username",
                    Password = "p@ssw0rd"
                };

                var fixture = new SvnStatusFixture
                {
                    Settings = new SvnStatusSettings
                    {
                        Credentials = credentials
                    }
                };

                // When
                fixture.Status();

                // Then
                fixture.SvnClient.Received(2).ForceCredentials(credentials);
            }

            [Fact]
            public void Should_Proxy_Call_To_CreateStatus_OnSvnClient()
            {
                // Given
                var fixture = new SvnStatusFixture();

                // When
                fixture.Status();

                // Then
                fixture.SvnClient.Received(1).Status(fixture.DirectoryPath.ToString(), fixture.Settings);
                fixture.SvnClient.Received(1).Status(fixture.FilePath.ToString(), fixture.Settings);
            }
        }
    }
}
