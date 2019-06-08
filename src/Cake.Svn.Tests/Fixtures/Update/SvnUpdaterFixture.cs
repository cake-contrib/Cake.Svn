using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Update;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn.Tests.Fixtures.Update
{
    internal sealed class SvnUpdaterFixture
    {
        public ICakeEnvironment Environment { get; set; }
        public ISvnClient SvnClient { get; set; }
        public SvnUpdateSettings Settings { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal FilePath FilePath { get; set; }

        public SvnUpdaterFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnUpdateSettings();
            DirectoryPath = @"C:\test\";
            FilePath = @"C:\test\test.cs";
        }

        public SvnUpdater CreateUpdater()
        {
            return new SvnUpdater(Environment, () => SvnClient);
        }

        internal SvnUpdateResult UpdateFile()
        {
            var svnUpdater = CreateUpdater();
            return svnUpdater.Update(FilePath, Settings);
        }

        internal SvnUpdateResult UpdateDirectory()
        {
            var svnUpdater = CreateUpdater();
            return svnUpdater.Update(DirectoryPath, Settings);
        }
    }
}
