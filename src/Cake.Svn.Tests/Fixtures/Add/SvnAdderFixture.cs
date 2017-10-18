using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Add;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Add
{
    internal sealed class SvnAdderFixture
    {
        internal ICakeEnvironment Environment { get; set; }
        internal ISvnClient SvnClient { get; set; }
        internal SvnAddSettings Settings { get; set; }
        internal DirectoryPath DirectoryPath { get; set; }
        internal FilePath FilePath { get; set; }
        internal Func<ISvnClient> GetSvnClient;

        internal SvnAdderFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnAddSettings();
            DirectoryPath = new DirectoryPath( @"C:\test\");
            FilePath = new FilePath(@"C:\test\test.cs");
            GetSvnClient = () => SvnClient;
        }

        internal SvnAdder CreateAdder()
        {
            return new SvnAdder(Environment, GetSvnClient);
        }

        internal bool Add()
        {
            var adder = CreateAdder();
            return adder.Add(DirectoryPath, Settings) & adder.Add(FilePath, Settings);
        }
    }
}
