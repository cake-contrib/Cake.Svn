using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Checkout;
using NSubstitute;

namespace Cake.Svn.Tests.Fixtures.Checkout
{
    internal sealed class SvnCheckouterFixture
    {
        public ICakeEnvironment Environment { get; set; }
        public ISvnClient SvnClient { get; set; }
        public SvnCheckoutSettings Settings { get; set; }
        public Uri From { get; set; }
        public DirectoryPath To { get; set; }

        public SvnCheckouterFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            SvnClient = Substitute.For<ISvnClient>();
            Settings = new SvnCheckoutSettings();
            From = new Uri("svn://foo.bar/svn/repo");
            To = "/working/repo";
        }

        public SvnCheckouter CreateCheckouter()
        {
            return new SvnCheckouter(Environment, ()=> SvnClient);
        }

        public SvnCheckoutResult Checkout()
        {
            return CreateCheckouter().Checkout(From, To, Settings);
        }
    }
}