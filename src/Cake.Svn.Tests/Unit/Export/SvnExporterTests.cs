using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Svn.Export;
using Cake.Svn.Tests.Fixtures.Export;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Export
{
    public sealed class SvnExporterTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnExporterFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateExporter());
            }
        }

        public sealed class TheExportMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnExporterFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.Export());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Null()
            {
                // Given
                var fixture = new SvnExporterFixture
                {
                    Settings = new SvnExportSettings
                    {
                        Credentials = null
                    }
                };

                // When
                fixture.Export();

                // Then
                fixture.SvnClient.DidNotReceive().ForceCredentials(Arg.Any<SvnCredentials>());
            }

            [Fact]
            public void Should_Force_Credentials_If_Not_Null()
            {
                // Given
                var credentials = new SvnCredentials
                {
                    Username = "username",
                    Password = "p@ssw0rd"
                };

                var fixture = new SvnExporterFixture
                {
                    Settings = new SvnExportSettings
                    {
                        Credentials = credentials
                    }
                };

                // When
                fixture.Export();

                // Then
                fixture.SvnClient.Received(1).ForceCredentials(credentials);
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnExporterFixture();

                // When
                fixture.Export();

                // Then
                fixture.SvnClient.Received(1).Export(fixture.From.ToString(), fixture.To.ToString(), fixture.Settings);
            }
        }
    }
}
