using System;
using System.Net;
using Cake.Core.IO;
using Cake.Svn.Export;
using Cake.Svn.Internal.Extensions;
using SharpSvn.Security;

namespace Cake.Svn.Internal
{
    internal class SvnSharpClient : SharpSvn.SvnClient, ISvnClient
    {
        public bool Insecure { get; set; }


        public void ForceCredentials(SvnCredentials credentials)
        {
            Authentication.Clear();
            Authentication.ClearAuthenticationCache();
            var foobar = Authentication.GetC​achedItems(SvnAuthen​ticationCacheType.Us​erNamePassword);
            Authentication.DefaultCredentials = new NetworkCredential(credentials.Username, credentials.Password);
            Authentication.ForceCredentials(credentials.Username, credentials.Password);

            //Re-register handlers
            Authentication.SslServerTrustHandlers += OnAuthenticationOnSslServerTrustHandlers;
        }

        public SvnSharpClient()
        {
            //Register handlers
            Authentication.SslServerTrustHandlers += OnAuthenticationOnSslServerTrustHandlers;
        }

        private void OnAuthenticationOnSslServerTrustHandlers(object sender, SvnSslServerTrustEventArgs args)
        {
            if (!Insecure)
            {
                return;
            }

            args.AcceptedFailures = args.Failures;
            args.Save = true;
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
