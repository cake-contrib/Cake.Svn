using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Delete;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Delete
{
    internal sealed class SvnDeleterFixture
    {
        internal ISvnClient SvnClient { get; set; }
        internal ICakeEnvironment Environment { get; set; }
        internal SvnDeleteSettings Settings { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal FilePath FilePath { get; set; }
        internal Func<ISvnClient> GetSvnClient;
        internal SvnDeleterFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnDeleteSettings();
            DirectoryPath = new DirectoryPath(@"C:\test\");
            FilePath = new FilePath(@"C:\test\test.cs");
            GetSvnClient = () => SvnClient;
        }

        internal SvnDeleter CreateDeleter()
        {
            return new SvnDeleter(Environment, GetSvnClient);
        }

        internal bool Delete()
        {
            var deleter = CreateDeleter();
            return deleter.Delete(DirectoryPath, Settings) & deleter.Delete(FilePath, Settings);
        }
    }
}
