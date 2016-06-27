using System;
using System.Globalization;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using SharpSvn;

namespace Cake.Svn.Export
{
    public sealed class SvnExporter : SvnTool<SvnExportSettings>
    {
        private readonly ICakeEnvironment _environment;

        public SvnExporter(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            _environment = environment;
        }

        public SvnExportResult Export(Uri repositoryUrl, DirectoryPath path, SvnExportSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var absolutePath = path.MakeAbsolute(_environment).ToString();

            using (var client = GetClient())
            {
                client.Insecure = settings.Insecure;
                if (settings.Credentials != null)
                {
                    client.ForceCredentials(settings.Credentials);
                }

                return client.Export(repositoryUrl.ToString(), absolutePath, settings);
            }
        }
    }
}
