using System;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Status
{
    /// <summary>
    /// Result for <see cref="SvnStatusTool"/>.
    /// </summary>
    public sealed class SvnStatusResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvnStatusResult"/> class.
        /// </summary>
        /// <param name="repositoryId">The UUID of the Subversion repository.</param>
        /// <param name="repositoryRoot">The repository root Uri.</param>
        /// <param name="lastChangedAuthor">The author of the last revision.</param>
        /// <param name="revision">The revision of the node.</param>
        /// <param name="lastChangedRevision">The last changed revision of the node.</param>
        /// <param name="uri">The full Uri of the node.</param>
        /// <param name="path">The path of the file. The local path if requisting working version,
        /// otherwise the name of the file at the specified version.</param>
        /// <param name="fullPath">The path in a normalized format.</param>
        /// <param name="svnStatus">The status of the Subversion node.</param>
        public SvnStatusResult(
            Guid repositoryId,
            Uri repositoryRoot,
            string lastChangedAuthor,
            long revision,
            long lastChangedRevision,
            Uri uri,
            string path,
            string fullPath,
            SvnStatus svnStatus)
        {
#pragma warning disable SA1123 // Do not place regions within elements
            #region DupFinder Exclusion
#pragma warning restore SA1123 // Do not place regions within elements

            repositoryRoot.NotNull(nameof(repositoryRoot));
            uri.NotNull(nameof(uri));
            path.NotNull(nameof(path));

            RepositoryId = repositoryId;
            RepositoryRoot = repositoryRoot;
            LastChangedAuthor = lastChangedAuthor;
            LastChangedRevision = lastChangedRevision;
            Revision = revision;
            Uri = uri;
            Path = path;
            FullPath = fullPath;
            SvnStatus = svnStatus;

            #endregion
        }

        /// <summary>
        /// Gets the UUID of the repository (if available). Otherwise <see cref="Guid.Empty"/>.
        /// </summary>
        public Guid RepositoryId { get; }

        /// <summary>
        ///  Gets the repository root Uri.
        /// </summary>
        public Uri RepositoryRoot { get; }

        /// <summary>
        ///  Gets the author of the last revision in which the node (or one of its descendants) changed.
        /// </summary>
        public string LastChangedAuthor { get; }

        /// <summary>
        /// Gets The revision of the node item.
        /// </summary>
        public long Revision { get; }

        /// <summary>
        /// Gets the last changed revision of the node item.
        /// </summary>
        public long LastChangedRevision { get; }

        /// <summary>
        /// Gets the full Uri of the node.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// Gets the path of the file. The local path if requisting working version, otherwise
        /// the name of the file at the specified version.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the path in normalized format.
        /// </summary>
        public string FullPath { get; }

        /// <summary>
        /// Gets the status of the subversion node.
        /// </summary>
        public SvnStatus SvnStatus { get; }
    }
}
