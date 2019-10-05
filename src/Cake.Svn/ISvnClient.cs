using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core.IO;
using Cake.Svn.Add;
using Cake.Svn.Checkout;
using Cake.Svn.CleanUp;
using Cake.Svn.Delete;
using Cake.Svn.Export;
using Cake.Svn.Info;
using Cake.Svn.Update;

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
        /// Checkout a Subversion directory tree
        /// </summary>
        /// <param name="from">URL of remote repository</param>
        /// <param name="to">Path to the local directory where the directory tree should be checked out to.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>Result of the export operation.</returns>
        SvnCheckoutResult Checkout(string from, string to, SvnCheckoutSettings settings);

        /// <summary>
        /// Export a Subversion directory tree.
        /// </summary>
        /// <param name="from">URL of remote repository or path of local working copy from where the directory tree should be exported.</param>
        /// <param name="to">Path to the local directory where the directory tree should be exported to.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>Result of the export operation.</returns>
        SvnExportResult Export(string from, string to, SvnExportSettings settings);

        /// <summary>
        /// Remove a file or a directory from Subversion.
        /// </summary>
        /// <param name="fileOrDirectoryPath">The absolute path to the file or directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns><c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.</returns>
        bool Delete(string fileOrDirectoryPath, SvnDeleteSettings settings);

        /// <summary>
        /// Add a file or a directory to Subversion.
        /// </summary>
        /// <param name="fileOrDirectoryPath">The absolute path to the file or directory.</param>
        /// <param name="settings">The settings for adding the file or directory.</param>
        /// <returns><c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.</returns>
        bool Add(string fileOrDirectoryPath, SvnAddSettings settings);

        /// <summary>
        /// Gets the information whether the <paramref name="fileOrDirectoryPath"/> is a working copy or not.
        /// </summary>
        /// <param name="fileOrDirectoryPath">The path to the local file or directory.</param>
        /// <returns>
        /// <c>true</c> if the <paramref name="fileOrDirectoryPath"/> is a working path. 
        /// Otherwise <c>false</c> will be returned.
        /// </returns>
        bool IsWorkingCopy(string fileOrDirectoryPath);

        /// <summary>
        /// Gets Subversion information about the file or directory at <paramref name="fileOrDirectoryPath"/> (local or remote).
        /// </summary>
        /// <param name="fileOrDirectoryPath">The path to the file or directory (local or remote).</param>
        /// <param name="settings">The settings.</param>
        /// <returns>An information result about the Subversion repository.</returns>
        IEnumerable<SvnInfoResult> GetInfo(string fileOrDirectoryPath, SvnInfoSettings settings);

        /// <summary>
        /// Update a Subversion directory tree.
        /// </summary>
        /// <param name="fileOrDirectoryPath">The path to the local file or directory.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>Result of the export operation.</returns>
        SvnUpdateResult Update(string fileOrDirectoryPath, SvnUpdateSettings settings);

        /// <summary>
        /// Cleans up the directory with an SVN working copy.
        /// </summary>
        /// <param name="directoryPath">The path in the working copy to clean up.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.</returns>
        bool CleanUp( string directoryPath, SvnCleanUpSettings settings );
    }
}
