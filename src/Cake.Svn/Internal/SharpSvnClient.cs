using System.Net;
using Cake.Svn.Export;
using Cake.Svn.Internal.Extensions;
using SharpSvn.Security;

namespace Cake.Svn.Internal
{
    internal class SvnSharpClient : SharpSvn.SvnClient, ISvnClient
    {
        private SvnCredentials _svnCredentials;

        public bool TrustServerCertificate { get; set; }


        public void ForceCredentials(SvnCredentials credentials)
        {
            _svnCredentials = credentials;

            Authentication.Clear();
            Authentication.ClearAuthenticationCache();
            Authentication.DefaultCredentials = new NetworkCredential(credentials.Username, credentials.Password);

            //Re-register handlers
            Authentication.SslServerTrustHandlers += OnAuthenticationOnSslServerTrustHandlers;
            Authentication.UserNameHandlers += OnAuthenticationUserNameHandlers;
            Authentication.UserNamePasswordHandlers += OnAuthenticationUserNamePasswordHandlers;
        }

        private void OnAuthenticationUserNamePasswordHandlers(object sender, SvnUserNamePasswordEventArgs args)
        {
            if (_svnCredentials == null)
            {
                return;
            }

            args.UserName = _svnCredentials.Username;
            args.Password = _svnCredentials.Password;
            args.Save = false;
            args.Break = true;
        }

        private void OnAuthenticationUserNameHandlers(object sender, SvnUserNameEventArgs args)
        {
            if (_svnCredentials == null)
            {
                return;
            }

            args.UserName = _svnCredentials.Username;
            args.Save = false;
            args.Break = true;
        }

        public SvnSharpClient()
        {
            //Register handlers
            Authentication.SslServerTrustHandlers += OnAuthenticationOnSslServerTrustHandlers;
        }

        private void OnAuthenticationOnSslServerTrustHandlers(object sender, SvnSslServerTrustEventArgs args)
        {
            if (!TrustServerCertificate)
            {
                return;
            }

            args.AcceptedFailures = args.Failures;
            args.Save = false;
        }

        public SvnExportResult Export(string from, string to, SvnExportSettings settings)
        {
            var arguments = settings.ToSharpSvn();

            SharpSvn.SvnUpdateResult result;
            Export(from, to, arguments, out result);

            return new SvnExportResult(result.Revision);
        }
    }
}
