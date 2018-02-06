using System;
using Cake.Svn.Checkout;
using Cake.Svn.Tests.Fixtures.Checkout;
using NSubstitute;
using Xunit;

namespace Cake.Svn.Tests.Unit.Checkout
{
    public sealed class SvnCheckouterTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new SvnCheckouterFixture
                {
                    Environment = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("environment", () => fixture.CreateCheckouter());
            }
        }

        public sealed class TheCheckoutMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new SvnCheckouterFixture
                {
                    Settings = null
                };

                // When
                // Then
                Assert.Throws<ArgumentNullException>("settings", () => fixture.Checkout());
            }

            [Fact]
            public void Should_Throw_If_Revision_Less_Than_Zero()
            {
                // Given
                var fixture = new SvnCheckouterFixture
                {
                    Settings = new SvnCheckoutSettings{
                        Revision = -1
                    }
                };

                // When
                // Then
                Assert.Throws<ArgumentException>("settings", () => fixture.Checkout());
            }

            [Fact]
            public void Should_Not_Force_Credentials_If_Null()
            {
                // Given
                var fixture = new SvnCheckouterFixture
                {
                    Settings = new SvnCheckoutSettings
                    {
                    Credentials = null
                    }
                };

                // When
                fixture.Checkout();

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

                var fixture = new SvnCheckouterFixture
                {
                    Settings = new SvnCheckoutSettings
                    {
                    Credentials = credentials
                    }
                };

                // When
                fixture.Checkout();

                // Then
                fixture.SvnClient.Received(1).ForceCredentials(credentials);
            }

            [Fact]
            public void Should_Proxy_Call_To_SvnClient()
            {
                // Given
                var fixture = new SvnCheckouterFixture();

                // When
                fixture.Checkout();

                // Then
                fixture.SvnClient.Received(1).Checkout(fixture.From.ToString(), fixture.To.ToString(), fixture.Settings);
            }
        }
    }
}