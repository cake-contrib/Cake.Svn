using System;
using System.Globalization;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using SharpSvn;

namespace Cake.Svn.Export
{
    /// <summary>
    /// Class for exporting Subversion directory trees.
    /// </summary>
    public sealed class SvnExporter : SvnTool<SvnExportSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnExporter"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnExporter(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            _environment = environment;
        }

        /// <summary>
        /// Export a Subversion directory tree.
        /// </summary>
        /// <param name="repositoryUrl">The URL of the Subversion repository.</param>
        /// <param name="path">The local directory name.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Result of the export operation.</returns>
        public SvnExportResult Export(Uri repositoryUrl, DirectoryPath path, SvnExportSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var absolutePath = path.MakeAbsolute(_environment).ToString();

            using (var client = GetClient())
            {
                client.TrustServerCertificate = settings.Insecure;
                if (settings.Credentials != null)
                {
                    client.ForceCredentials(settings.Credentials);
                }

                return client.Export(repositoryUrl.ToString(), absolutePath, settings);
            }
        }
    }
}
