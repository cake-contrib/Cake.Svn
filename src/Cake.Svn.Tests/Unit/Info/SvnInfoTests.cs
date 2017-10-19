using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Info;
using Cake.Svn.Internal;
using Cake.Svn.Tests.Fixtures.Info;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Info
{
    public sealed class SvnInfoTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_NotThrow_If_Parameters_AreSet()
            {
                // Given
                var fixture = new SvnInfoFixture();

                // When
                fixture.CreateInfo();
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateInfo());
            }

            [Fact]
            public void Should_Throw_If_GetSvnClient_Is_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    GetSvnClient = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("clientFactoryMethod", () => fixture.CreateInfo());
            }
        }

        public sealed class TheGetInfo
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.GetInfo());
            }

            [Fact]
            public void Should_Throw_If_FileOrDirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    RepositoryUri = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("repositoryUrl", () => fixture.GetInfo());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    Settings = new SvnInfoSettings
                    {
                        Credentials = null
                    }
                };

                // When
                fixture.GetInfo();

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

                var fixture = new SvnInfoFixture
                {
                    Settings = new SvnInfoSettings
                    {
                        Credentials = credentials
                    }
                };

                // When
                fixture.GetInfo();

                // Then
                fixture.SvnClient.Received(3).ForceCredentials(credentials);
            }

            [Fact]
            public void Should_Throw_If_RepositoryUri_Is_Directory()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    RepositoryUri = new Uri(@"C:\project\src\")
                };

                // Then
                Assert.Throws<ArgumentException>("repositoryUrl", () => fixture.GetInfo());
            }

                  [Fact]
            public void Should_Throw_If_RepositoryUri_Is_File()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    RepositoryUri = new Uri(@"C:\project\src\file.cs")
                };

                // Then
                Assert.Throws<ArgumentException>("repositoryUrl", () => fixture.GetInfo());
            }

            [Fact]
            public void Should_Proxy_Call_To_GetInfo_OnSvnClient()
            {
                // Given
                var fixture = new SvnInfoFixture();

                // When
                fixture.GetInfo();

                // Then
                fixture.SvnClient.Received(1).GetInfo(fixture.RepositoryUri.ToString(), fixture.Settings);
                fixture.SvnClient.Received(1).GetInfo(fixture.DirectoryPath.ToString(), fixture.Settings);
                fixture.SvnClient.Received(1).GetInfo(fixture.FilePath.ToString(), fixture.Settings);
            }
        }

        public sealed class TheIsWorkingCopy
        {
            [Fact]
            public void Should_Not_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    Settings = null
                };

                // When
                fixture.IsWorkingCopy();
            }

            [Fact]
            public void Should_Throw_If_DirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    DirectoryPath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("directoryPath", () => fixture.IsWorkingCopy());
            }

            [Fact]
            public void Should_Throw_If_FilePath_Is_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    FilePath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("filePath", () => fixture.IsWorkingCopy());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Null()
            {
                // Given
                var fixture = new SvnInfoFixture
                {
                    Settings = new SvnInfoSettings
                    {
                        Credentials = null
                    }
                };

                // When
                fixture.IsWorkingCopy();

                // Then
                fixture.SvnClient.DidNotReceive().ForceCredentials(Arg.Any<SvnCredentials>());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Not_Null()
            {
                // Given
                SvnCredentials credentials = new SvnCredentials
                {
                    Username = "username",
                    Password = "p@ssw0rd"
                };

                var fixture = new SvnInfoFixture
                {
                    Settings = new SvnInfoSettings
                    {
                        Credentials = credentials
                    }
                };

                // When
                fixture.IsWorkingCopy();

                // Then
                fixture.SvnClient.DidNotReceive().ForceCredentials(credentials);
            }

            [Fact]
            public void Should_Proxy_Call_To_GetInfo_OnSvnClient()
            {
                // Given
                var fixture = new SvnInfoFixture();

                // When
                fixture.IsWorkingCopy();

                // Then
                fixture.SvnClient.Received(1).IsWorkingCopy(fixture.DirectoryPath.ToString());
                fixture.SvnClient.Received(1).IsWorkingCopy(fixture.FilePath.ToString());
            }
        }
    }
}
