using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn.Update
{
    /// <summary>
    /// Class for updating a checked out svn repository.
    /// </summary>
    public sealed class SvnUpdater : SvnTool<SvnUpdateSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnUpdater"/> class.
        /// </summary>
        /// <param name="environment">The Cake environemnt.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnUpdater(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod) : base(clientFactoryMethod)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            _environment = environment;
        }

        /// <summary>
        /// Update the file at <paramref name="filePath"/> that is a member of a Subversion 
        /// directory tree.
        /// </summary>
        /// <param name="filePath">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Result of the update operation.</returns>
        public SvnUpdateResult Update(FilePath filePath, SvnUpdateSettings settings)
        {
            filePath.NotNull(nameof(filePath));

            return Update(filePath.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Update the directory at <paramref name="directoryPath"/> that is a member of a 
        /// Subversion directory tree.
        /// </summary>
        /// <param name="directoryPath">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Result of the update operation.</returns>
        public SvnUpdateResult Update(DirectoryPath directoryPath, SvnUpdateSettings settings)
        {
            directoryPath.NotNull(nameof(directoryPath));

            return Update(directoryPath.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Update a Subversion directory tree or file.
        /// </summary>
        /// <param name="fileOrDirectoryPath">The local file or directory to update.</param>
        /// <param name="settings">The seetings.</param>
        /// <returns>Result of the update operation.</returns>
        private SvnUpdateResult Update(string fileOrDirectoryPath, SvnUpdateSettings settings)
        {
            fileOrDirectoryPath.NotNullOrWhiteSpace(nameof(fileOrDirectoryPath));

            CheckSettingsIsNotNull(settings);

            if (settings.Revision.HasValue && settings.Revision < 0)
            {
                throw new ArgumentException("A negative revision is not allowed", nameof(settings));
            }

            using (var client = GetClient())
            {
                client.TrustServerCertificate = settings.Insecure;
                if (settings.Credentials != null)
                {
                    client.ForceCredentials(settings.Credentials);
                }

                return client.Update(fileOrDirectoryPath, settings);
            }
        }
    }
}
