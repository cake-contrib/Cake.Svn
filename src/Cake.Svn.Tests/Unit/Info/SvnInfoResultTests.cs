using System;
using Cake.Svn.Info;
using Xunit;

namespace Cake.Svn.Tests.Unit.Info
{
    public sealed class SvnInfoResultTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_RepositoryRoot_Is_Null()
            {
                // Given
                var testSvnInfoResult = new TestSvnInfoResult()
                {
                    RepositoryRoot = null 
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("repositoryRoot", () =>
                    GetSvnInfoResultFromParameterList(testSvnInfoResult));
            }

            [Fact]
            public void Should_Not_Throw_If_LastChangedAuthor_Is_Null()
            {
                // Given
                var testSvnInfoResult = new TestSvnInfoResult()
                {
                    LastChangedAuthor = null
                };

                // When
                var svnInfoResult = GetSvnInfoResultFromParameterList(testSvnInfoResult);

                // Then
                Assert.Null(svnInfoResult.LastChangedAuthor);
            }

            [Fact]
            public void Should_Throw_If_Uri_Is_Null()
            {
                // Given
                var testSvnInfoResult = new TestSvnInfoResult()
                {
                    Uri = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("uri", () =>
                    GetSvnInfoResultFromParameterList(testSvnInfoResult));
            }

            [Fact]
            public void Should_Throw_If_Path_Is_Null()
            {
                // Given
                var testSvnInfoResult = new TestSvnInfoResult()
                {
                    Path = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("path", () =>
                    GetSvnInfoResultFromParameterList(testSvnInfoResult));
            }

            [Fact]
            public void Should_Not_Throw_If_FullPath_Is_Null()
            {
                // Given
                var testSvnInfoResult = new TestSvnInfoResult()
                {
                    FullPath = null
                };

                // When
                var svnInfoResult = GetSvnInfoResultFromParameterList(testSvnInfoResult);

                // Then
                Assert.Null(svnInfoResult.FullPath);
            }

            [Fact]
            public void Should_Return_Correct_Guid_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal(Guid.Empty, testSvnInfoResult.RepositoryId);
            }

            [Fact]
            public void Should_Return_Correct_RepositoryRoot_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal("https://svn.example.com/", testSvnInfoResult.RepositoryRoot.ToString());
            }

            [Fact]
            public void Should_Return_Correct_LastChangedAuthor_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal("administrator", testSvnInfoResult.LastChangedAuthor);
            }

            [Fact]
            public void Should_Return_Correct_Revision_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal(1234, testSvnInfoResult.Revision);
            }

            [Fact]
            public void Should_Return_Correct_LastChangedRevision_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal(1235, testSvnInfoResult.LastChangedRevision);
            }

            [Fact]
            public void Should_Return_Correct_NodeUri_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal("https://svn.example.com/", testSvnInfoResult.Uri.ToString());
            }

            [Fact]
            public void Should_Return_Correct_Path_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal(@"src/folder/file.cs", testSvnInfoResult.Path);
            }

            [Fact]
            public void Should_Return_Correct_FullPath_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal(@"https://svn.example.com/src/folder/file.cs", testSvnInfoResult.FullPath);
            }

            [Fact]
            public void Should_Return_Correct_NodeKind_If_SvnInfoResult_CreatedSuccesful()
            {
                // Given
                var testSvnInfoResult = GetSvnInfoResultFromParameterList(new TestSvnInfoResult());

                // Then
                Assert.Equal(SvnKind.Unknown, testSvnInfoResult.NodeKind);
            }

            private SvnInfoResult GetSvnInfoResultFromParameterList(TestSvnInfoResult infoResult)
            {
                return new SvnInfoResult(
                    infoResult.RepositoryId,
                    infoResult.RepositoryRoot,
                    infoResult.LastChangedAuthor,
                    infoResult.Revision,
                    infoResult.LastChangedRevision,
                    infoResult.Uri,
                    infoResult.Path,
                    infoResult.FullPath,
                    infoResult.NodeKind);
            }

            private sealed class TestSvnInfoResult
            {
                internal TestSvnInfoResult()
                {
                    RepositoryId = Guid.Empty;
                    RepositoryRoot = new Uri("https://svn.example.com/");
                    LastChangedAuthor = "administrator";
                    Revision = 1234;
                    LastChangedRevision = 1235;
                    Uri = new Uri("https://svn.example.com/");
                    Path = @"src/folder/file.cs";
                    FullPath = @"https://svn.example.com/src/folder/file.cs";
                    NodeKind = SvnKind.Unknown;
                }

                internal Guid RepositoryId;
                internal Uri RepositoryRoot;
                internal string LastChangedAuthor;
                internal long Revision;
                internal long LastChangedRevision;
                internal Uri Uri;
                internal string Path;
                internal string FullPath;
                internal SvnKind NodeKind;
            }
        }
    }
}
