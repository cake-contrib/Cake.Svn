using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Revert;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Revert
{
    internal sealed class SvnRevertFixture
    {
        internal ICakeEnvironment Environment { get; set; }
        internal ISvnClient SvnClient { get; set; }
        internal SvnRevertSettings Settings { get; set; }
        internal FilePath FilePath { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal FilePathCollection FilePaths { get; set; }
        internal DirectoryPathCollection DirectoryPaths { get; set; }

        internal Func<ISvnClient> GetSvnClient { get; set; }

        internal ICollection<string> FilePathsAsStrings
        {
            get
            {
                var list = new List<string>();
                if(FilePaths != null)
                {
                    foreach(FilePath path in FilePaths)
                    {
                        list.Add(path.ToString());
                    }
                }

                return list;
            }
        }

        internal ICollection<string> DirectoryPathsAsStrings
        {
            get
            {
                var list = new List<string>();
                if(DirectoryPaths != null)
                {
                    foreach(DirectoryPath path in DirectoryPaths)
                    {
                        list.Add(path.ToString());
                    }
                }

                return list;
            }
        }

        internal SvnRevertFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnRevertSettings();
            FilePath = new FilePath(@"c:\repo\src\Program.cs");
            DirectoryPath = new DirectoryPath(@"c:\repo\src\");
            FilePaths = new FilePathCollection(
                new List<FilePath>
                {
                    new FilePath(@"c:\repo\src\Cake.Svn\Cake.Svn.csproj"),
                    new FilePath(@"c:\repo\src\Cake.Svn.Tests\Cake.Svn.Tests.csproj")
                }
            );
            DirectoryPaths = new DirectoryPathCollection(
                new List<DirectoryPath>
                {
                    new DirectoryPath(@"c:\repo\src\Cake.Svn\"),
                    new DirectoryPath(@"c:\repo\src\Cake.Svn.Tests/")
                }
            );
            GetSvnClient = () => SvnClient;
        }

        internal SvnReverter CreateReverter()
        {
            return new SvnReverter(Environment, GetSvnClient);
        }

        internal bool RevertFilePath()
        {
            var reverter = CreateReverter();

            return reverter.Revert(FilePath, Settings);
        }

        internal bool RevertDirectoryPath()
        {
            var reverter = CreateReverter();

            return reverter.Revert(DirectoryPath, Settings);
        }

        internal bool RevertFilePathCollection()
        {
            var reverter = CreateReverter();

            return reverter.Revert(FilePaths, Settings);
        }

        internal bool RevertDirectoryPathCollection()
        {
            var reverter = CreateReverter();

            return reverter.Revert(DirectoryPaths, Settings);
        }

        internal bool RevertFileAndDirectoryPathCollections()
        {
            var reverter = CreateReverter();

            return reverter.Revert(FilePaths, DirectoryPaths, Settings);
        }
    }
}
