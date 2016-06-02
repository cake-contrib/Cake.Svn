using System;
using Cake.Core.IO;
using Cake.Svn.Export;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Internal
{
    internal class SvnSharpClient : SharpSvn.SvnClient, ISvnClient
    {
        public void ForceCredentials(SvnCredentials credentials)
        {
            Authentication.ForceCredentials(credentials.Username, credentials.Password);
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
