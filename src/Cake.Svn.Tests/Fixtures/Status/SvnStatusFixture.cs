using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Status;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Status
{
    internal sealed class SvnStatusFixture
    {
        internal ICakeEnvironment Environment { get; set; }
        internal ISvnClient SvnClient { get; set; }
        internal SvnStatusSettings Settings { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal FilePath FilePath { get; set; }
        internal Func<ISvnClient> GetSvnClient;

        internal SvnStatusFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnStatusSettings();
            DirectoryPath = new DirectoryPath(@"C:\test\");
            FilePath = new FilePath(@"C:\test\test.cs");
            GetSvnClient = () => SvnClient;
        }

        internal SvnStatusTool CreateStatus()
        {
            return new SvnStatusTool(Environment, GetSvnClient);
        }

        internal IEnumerable<SvnStatusResult> Status()
        {
            var svnStatus = CreateStatus();
            var list = new List<SvnStatusResult>();
            list.AddRange(svnStatus.Status(DirectoryPath, Settings));
            list.AddRange(svnStatus.Status(FilePath, Settings));

            return list;
        }
    }
}
