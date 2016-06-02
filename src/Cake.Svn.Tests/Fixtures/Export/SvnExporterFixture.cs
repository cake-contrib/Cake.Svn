using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Export;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Export
{
    internal sealed class SvnExporterFixture
    {
        public ICakeEnvironment Environment { get; set; }
        public ISvnClient SvnClient { get; set; }
        public SvnExportSettings Settings { get; set; }
        public Uri From { get; set; }
        public DirectoryPath To { get; set; }

        public SvnExporterFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnExportSettings();
            From = new Uri("svn://foo.bar/svn/repo");
            To = "/working/repo";
        }

        public SvnExporter CreateExporter()
        {
            return new SvnExporter(Environment, () => SvnClient);
        }

        public SvnExportResult Export()
        {
            return CreateExporter().Export(From, To, Settings);
        }
    }
}
