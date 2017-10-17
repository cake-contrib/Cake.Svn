using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Info;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Info
{
    internal sealed class SvnInfoFixture
    {
        internal ICakeEnvironment Environment { get; set; }
        internal ISvnClient SvnClient { get; set; }
        internal SvnInfoSettings Settings { get; set; }
        internal Uri RepositoryUri { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal FilePath FilePath { get; set; }
        internal Func<ISvnClient> GetSvnClient;

        internal SvnInfoFixture()
        {
            SvnClient = Substitute.For<ISvnClient>();
            Environment = Substitute.For<ICakeEnvironment>();
            Settings = new SvnInfoSettings();
            RepositoryUri = new Uri("https://svn.example.com/");
            DirectoryPath = @"C:\test\";
            FilePath = @"C:\test\test.cs";
            GetSvnClient = () => SvnClient;
        }

        internal SvnInfo CreateInfo()
        {
            return new SvnInfo(Environment, GetSvnClient);
        }

        internal Boolean IsWorkingCopy()
        {
            var svnInfo = CreateInfo();
            return svnInfo.IsDirectoryInSvnWorkingCopy(DirectoryPath) & svnInfo.IsFileInSvnWorkingCopy(FilePath);
        }

        internal IEnumerable<SvnInfoResult> GetInfo()
        {
            var svnInfo = CreateInfo();
            var list = new List<SvnInfoResult>();
            list.AddRange(svnInfo.GetInfo(RepositoryUri, Settings));
            list.AddRange(svnInfo.GetInfo(DirectoryPath, Settings));
            list.AddRange(svnInfo.GetInfo(FilePath, Settings));

            return list;
        }
    }
}
