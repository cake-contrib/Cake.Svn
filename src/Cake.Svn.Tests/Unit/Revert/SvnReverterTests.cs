using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Svn.Tests.Fixtures.Revert;
using NSubstitute;
using Xunit;


namespace Cake.Svn.Tests.Unit.Revert
{
    public sealed class SvnReverterTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Not_Throw_If_Parameters_Are_Set()
            {
                // Given
                var fixture = new SvnRevertFixture();

                // When
                fixture.CreateReverter();
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateReverter());
            }

            [Fact]
            public void Should_Throw_If_SvnClient_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    GetSvnClient = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("clientFactoryMethod", () => fixture.CreateReverter());
            }
        }

        public sealed class TheRevertFilePathMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.RevertFilePath());
            }

            [Fact]
            public void Should_Throw_If_FilePath_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    FilePath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("filePath", () => fixture.RevertFilePath());
            }

            [Fact]
            public void Should_Proxy_Call_To_Svn_Client()
            {
                // Given
                var fixture = new SvnRevertFixture();

                // When
                fixture.RevertFilePath();

                // Then
                fixture.SvnClient.Received(1).Revert(fixture.FilePath.ToString(), fixture.Settings);
            }
        }

        public sealed class TheRevertDirectoryPathMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.RevertDirectoryPath());
            }

            [Fact]
            public void Should_Throw_If_DirectoryPath_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    DirectoryPath = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("directoryPath", () => fixture.RevertDirectoryPath());
            }

            [Fact]
            public void Should_Proxy_Call_To_Svn_Client()
            {
                // Given
                var fixture = new SvnRevertFixture();

                // When
                fixture.RevertDirectoryPath();

                // Then
                fixture.SvnClient.Received(1).Revert(fixture.DirectoryPath.ToString(), fixture.Settings);
            }
        }

        public sealed class TheRevertFilePathCollectionMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.RevertFilePathCollection());
            }

            [Fact]
            public void Should_Throw_If_FilePaths_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    FilePaths = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("filePaths", () => fixture.RevertFilePathCollection());
            }

            [Fact]
            public void Should_Proxy_Call_To_Svn_Client()
            {
                // Given
                var fixture = new SvnRevertFixture();

                // When
                fixture.RevertFilePathCollection();

                // Then
                fixture.SvnClient.Received(1).Revert(
                    Arg.Is<ICollection<string>>(paths => fixture.FilePathsAsStrings.SequenceEqual(paths)),
                    fixture.Settings
                );
            }
        }

        public sealed class TheRevertDirectoryPathCollectionMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.RevertDirectoryPathCollection());
            }

            [Fact]
            public void Should_Throw_If_DirectoryPaths_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    DirectoryPaths = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("directoryPaths", () => fixture.RevertDirectoryPathCollection());
            }

            [Fact]
            public void Should_Proxy_Call_To_Svn_Client()
            {
                // Given
                var fixture = new SvnRevertFixture();

                // When
                fixture.RevertDirectoryPathCollection();

                // Then
                fixture.SvnClient.Received(1).Revert(
                    Arg.Is<ICollection<string>>(paths => fixture.DirectoryPathsAsStrings.SequenceEqual(paths)),
                    fixture.Settings
                );
            }
        }

        public sealed class TheRevertFilePathCollectionAndDirectoryPathCollectionMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.RevertFileAndDirectoryPathCollections());
            }

            [Fact]
            public void Should_Throw_If_FilePaths_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    FilePaths = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("filePaths", () => fixture.RevertFileAndDirectoryPathCollections());
            }

            [Fact]
            public void Should_Throw_If_DirectoryPaths_Is_Null()
            {
                // Given
                var fixture = new SvnRevertFixture
                {
                    DirectoryPaths = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("directoryPaths", () => fixture.RevertFileAndDirectoryPathCollections());
            }

            [Fact]
            public void Should_Proxy_Call_To_Svn_Client()
            {
                // Given
                var fixture = new SvnRevertFixture();
                var expectedPaths = new List<string>();
                expectedPaths.AddRange(fixture.FilePathsAsStrings);
                expectedPaths.AddRange(fixture.DirectoryPathsAsStrings);

                // When
                fixture.RevertFileAndDirectoryPathCollections();

                // Then
                fixture.SvnClient.Received(1).Revert(
                    Arg.Is<ICollection<string>>(paths => expectedPaths.SequenceEqual(paths)),
                    fixture.Settings
                );
            }
        }
    }
}
