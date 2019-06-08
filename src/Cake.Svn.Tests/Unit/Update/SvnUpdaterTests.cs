using System;
using Cake.Svn.Update;
using Cake.Svn.Tests.Fixtures.Update;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Update
{
    public sealed class SvnUpdaterTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnUpdaterFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateUpdater());
            }
        }

        public sealed class TheUpdateDirectoryMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnUpdaterFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.UpdateDirectory());
            }

            [Fact]
            public void Should_Throw_If_Revision_Less_Than_Zero()
            {
                // Given
                var fixture = new SvnUpdaterFixture
                {
                    Settings = new SvnUpdateSettings{
                        Revision = -1
                    }
                };

                // When
                // Then
                Assert.Throws<ArgumentException>("settings", () => fixture.UpdateDirectory());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Null()
            {
                // Given
                var fixture = new SvnUpdaterFixture
                {
                    Settings = new SvnUpdateSettings
                    {
                        Credentials = null
                    }
                };

                // When
                fixture.UpdateDirectory();

                // Then
                fixture.SvnClient.DidNotReceive().ForceCredentials(Arg.Any<SvnCredentials>());
            }

            [Fact]
            public void Should_Force_Credentials_If_Not_Null()
            {
                // Given
                var credentials = new SvnCredentials
                {
                    Username = "username",
                    Password = "p@ssw0rd"
                };

                var fixture = new SvnUpdaterFixture
                {
                    Settings = new SvnUpdateSettings
                    {
                        Credentials = credentials
                    }
                };

                // When
                fixture.UpdateDirectory();

                // Then
                fixture.SvnClient.Received(1).ForceCredentials(credentials);
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnUpdaterFixture();

                // When
                fixture.UpdateDirectory();

                // Then
                fixture.SvnClient.Received(1).Update(fixture.DirectoryPath.ToString(), fixture.Settings);
            }
        }

        public sealed class TheUpdateFileMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnUpdaterFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.UpdateFile());
            }

            [Fact]
            public void Should_Throw_If_Revision_Less_Than_Zero()
            {
                // Given
                var fixture = new SvnUpdaterFixture
                {
                    Settings = new SvnUpdateSettings{
                        Revision = -1
                    }
                };

                // When
                // Then
                Assert.Throws<ArgumentException>("settings", () => fixture.UpdateFile());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Null()
            {
                // Given
                var fixture = new SvnUpdaterFixture
                {
                    Settings = new SvnUpdateSettings
                    {
                        Credentials = null
                    }
                };

                // When
                fixture.UpdateFile();

                // Then
                fixture.SvnClient.DidNotReceive().ForceCredentials(Arg.Any<SvnCredentials>());
            }

            [Fact]
            public void Should_Force_Credentials_If_Not_Null()
            {
                // Given
                var credentials = new SvnCredentials
                {
                    Username = "username",
                    Password = "p@ssw0rd"
                };

                var fixture = new SvnUpdaterFixture
                {
                    Settings = new SvnUpdateSettings
                    {
                        Credentials = credentials
                    }
                };

                // When
                fixture.UpdateFile();

                // Then
                fixture.SvnClient.Received(1).ForceCredentials(credentials);
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnUpdaterFixture();

                // When
                fixture.UpdateFile();

                // Then
                fixture.SvnClient.Received(1).Update(fixture.FilePath.ToString(), fixture.Settings);
            }
        }
    }
}