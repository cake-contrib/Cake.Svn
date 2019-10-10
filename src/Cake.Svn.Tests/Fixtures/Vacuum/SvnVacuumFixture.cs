using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Vacuum;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Vacuum
{
    internal sealed class SvnVacuumFixture
    {
        internal ICakeEnvironment Environment { get; set; }
        internal ISvnClient SvnClient { get; set; }
        internal SvnVacuumSettings Settings { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal Func<ISvnClient> GetSvnClient;

        internal SvnVacuumFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnVacuumSettings();
            DirectoryPath = new DirectoryPath(@"C:\test\");
            GetSvnClient = () => SvnClient;
        }

        internal SvnVacuum CreateSvnVacuum()
        {
            return new SvnVacuum(Environment, GetSvnClient);
        }

        internal bool Vacuum()
        {
            var vacuum = CreateSvnVacuum();
            return vacuum.Vacuum(DirectoryPath, Settings);
        }
    }
}
