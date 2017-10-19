using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Info
{
    /// <summary>
    /// Class for retrieving information about a Subversion controlled file or directory.
    /// </summary>
    public sealed class SvnInfo : SvnTool<SvnRemoteSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnInfo"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnInfo(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod): base(clientFactoryMethod)
        {
            environment.NotNull(nameof(environment));
            clientFactoryMethod.NotNull(nameof(clientFactoryMethod));

            _environment = environment;
        }

        /// <summary>
        /// Gets the information whether the <paramref name="directoryPath"/> was added to the Subversion working copy.
        /// </summary>
        /// <param name="directoryPath">The directory.</param>
        /// <returns>
        /// <c>true</c> if the <paramref name="directoryPath"/> is a working path. 
        /// Otherwise <c>false</c> will be returned.
        /// </returns>
        public bool IsDirectoryInSvnWorkingCopy(DirectoryPath directoryPath)
        {
            directoryPath.NotNull(nameof(directoryPath));

            return IsWorkingCopy(directoryPath.MakeAbsolute(_environment).ToString());
        }

        /// <summary>
        /// Gets the information whether the <paramref name="filePath"/> was added to the Subversion working copy.
        /// </summary>
        /// <param name="filePath">The file.</param>
        /// <returns>
        /// <c>true</c> if the <paramref name="filePath"/> is a working path. 
        /// Otherwise <c>false</c> will be returned.
        /// </returns>
        public bool IsFileInSvnWorkingCopy(FilePath filePath)
        {
            filePath.NotNull(nameof(filePath));

            return IsWorkingCopy(filePath.MakeAbsolute(_environment).ToString());
        }

        /// <summary>
        /// Gets Subversion information about the directory at <paramref name="directoryPath"/>.
        /// </summary>
        /// <param name="directoryPath">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion information.</returns>
        public IEnumerable<SvnInfoResult> GetInfo(DirectoryPath directoryPath, SvnInfoSettings settings)
        {
            settings.NotNull(nameof(settings));
            directoryPath.NotNull(nameof(directoryPath));

            return GetInfo(directoryPath.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Gets Subversion information about the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion information.</returns>
        public IEnumerable<SvnInfoResult> GetInfo(FilePath filePath, SvnInfoSettings settings)
        {
            settings.NotNull(nameof(settings));
            filePath.NotNull(nameof(filePath));

            return GetInfo(filePath.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Gets Subversion information about the file or directory at <paramref name="repositoryUrl"/>.
        /// </summary>
        /// <param name="repositoryUrl">The URL of the repository.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion information.</returns>
        public IEnumerable<SvnInfoResult> GetInfo(Uri repositoryUrl, SvnInfoSettings settings)
        {
            settings.NotNull(nameof(settings));
            repositoryUrl.NotNull(nameof(repositoryUrl));

            if (repositoryUrl.IsFile)
            {
                throw new ArgumentException("Directory of file are not allowed.", nameof(repositoryUrl));
            }

            return GetInfo(repositoryUrl.ToString(), settings);
        }

        /// <summary>
        /// Gets the information whether the <paramref name="fileOrDirectoryPath"/> is a working copy or not.
        /// </summary>
        /// <param name="fileOrDirectoryPath">The file or directory.</param>
        /// <returns>
        /// <c>true</c> if the <paramref name="fileOrDirectoryPath"/> is a working path. 
        /// Otherwise <c>false</c> will be returned.
        /// </returns>
        private bool IsWorkingCopy(string fileOrDirectoryPath)
        {
            using (var client = GetClient())
            {
                return client.IsWorkingCopy(fileOrDirectoryPath);
            }
        }

        /// <summary>
        /// Gets Subversion information about the file or directory at <paramref name="repositoryUrl"/>.
        /// </summary>
        /// <param name="repositoryUrl">The URL of the repository.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion information.</returns>
        private IEnumerable<SvnInfoResult> GetInfo(string repositoryUrl, SvnInfoSettings settings)
        {
            settings.NotNull(nameof(settings));
            repositoryUrl.NotNullOrWhiteSpace(nameof(repositoryUrl));

            using (var client = GetClient())
            {
                client.TrustServerCertificate = settings.Insecure;
                if (settings.Credentials != null)
                {
                    client.ForceCredentials(settings.Credentials);
                }

                return client.GetInfo(repositoryUrl, settings);
            }
        }
    }
}
