using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.CleanUp;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.CleanUp
{
    internal sealed class SvnCleanUpFixture
    {
        internal ICakeEnvironment Environment { get; set; }
        internal ISvnClient SvnClient { get; set; }
        internal SvnCleanUpSettings Settings { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal Func<ISvnClient> GetSvnClient;

        internal SvnCleanUpFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnCleanUpSettings();
            DirectoryPath = new DirectoryPath( @"C:\test\" );
            GetSvnClient = () => SvnClient;
        }

        internal SvnCleanUper CreateCleanUper()
        {
            return new SvnCleanUper(Environment, GetSvnClient);
        }

        internal bool CleanUp()
        {
            var cleaner = CreateCleanUper();
            return cleaner.CleanUp(DirectoryPath, Settings);
        }
    }
}
