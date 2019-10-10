using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Status
{
    /// <summary>
    /// Class for getting file and directory status for Subversion directory trees.
    /// </summary>
    public sealed class SvnStatusTool : SvnTool<SvnStatusSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnStatusTool"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnStatusTool(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            environment.NotNull(nameof(environment));
            clientFactoryMethod.NotNull(nameof(clientFactoryMethod));

            _environment = environment;
        }

        /// <summary>
        /// Gets Subversion status about the directory at <paramref name="directoryPath"/>.
        /// </summary>
        /// <param name="directoryPath">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion status.</returns>
        public IEnumerable<SvnStatusResult> Status(DirectoryPath directoryPath, SvnStatusSettings settings)
        {
            settings.NotNull(nameof(settings));
            directoryPath.NotNull(nameof(directoryPath));

            return Status(directoryPath.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Gets Subversion status about the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion status.</returns>
        public IEnumerable<SvnStatusResult> Status(FilePath filePath, SvnStatusSettings settings)
        {
            settings.NotNull(nameof(settings));
            filePath.NotNull(nameof(filePath));

            return Status(filePath.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Gets Subversion status about the file or directory at <paramref name="fileOrDirectoryPath"/>.
        /// </summary>
        /// <param name="fileOrDirectoryPath">The file or directory path.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion status.</returns>
        private IEnumerable<SvnStatusResult> Status(string fileOrDirectoryPath, SvnStatusSettings settings)
        {
            settings.NotNull(nameof(settings));
            fileOrDirectoryPath.NotNullOrWhiteSpace(nameof(fileOrDirectoryPath));

            using (var client = GetClient())
            {
                client.TrustServerCertificate = settings.Insecure;
                if (settings.Credentials != null)
                {
                    client.ForceCredentials(settings.Credentials);
                }

                return client.Status(fileOrDirectoryPath, settings);
            }
        }
    }
}
