using System;
using Cake.Svn.Export;

namespace Cake.Svn
{
    /// <summary>
    /// Interface for a Subversion client.
    /// </summary>
    public interface ISvnClient : IDisposable
    {
        /// <summary>
        /// Gets or sets a value indicating whether insecure SSL certificates should be trusted.
        /// </summary>
        bool TrustServerCertificate { get; set; }

        /// <summary>
        /// Defines credentials to use for connecting to the repository.
        /// </summary>
        /// <param name="credentials">Credentials to use for connecting to the repository.</param>
        void ForceCredentials(SvnCredentials credentials);

        /// <summary>
        /// Export a Subversion directory tree.
        /// </summary>
        /// <param name="from">URL of remote repository or path of local working copy from where the directory tree should be exported.</param>
        /// <param name="to">Path to the local directory where the directory tree should be exported to.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>Result of the export operation.</returns>
        SvnExportResult Export(string from, string to, SvnExportSettings settings);
    }
}
