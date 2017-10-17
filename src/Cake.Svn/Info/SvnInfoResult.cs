using System;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Info
{
    /// <summary>
    /// Result for <see cref="SvnInfo"/>.
    /// </summary>
    public sealed class SvnInfoResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvnInfoResult"/> class.
        /// </summary>
        /// <param name="repositoryId">The UUID of the Subversion repository.</param>
        /// <param name="repositoryRoot">The repository root Uri.</param>
        /// <param name="lastChangedAuthor">The author of the last revision.</param>
        /// <param name="revision">The revision of the node.</param>
        /// <param name="uri">The full Uri of the node.</param>
        /// <param name="path">The path of the file. The local path if requisting working version, 
        /// otherwise the name of the file at the specified version.</param>
        /// <param name="fullPath">The path in a normalized format.</param>
        /// <param name="nodeKind">The kind of the Subversion node.</param>
        public SvnInfoResult(
            Guid repositoryId, 
            Uri repositoryRoot, 
            string lastChangedAuthor,
            long revision,
            Uri uri,
            string path,
            string fullPath,
            SvnKind nodeKind)
        {
            repositoryRoot.NotNull(nameof(repositoryRoot));
            lastChangedAuthor.NotNull(nameof(lastChangedAuthor));
            uri.NotNull(nameof(uri));
            path.NotNull(nameof(path));
            fullPath.NotNull(nameof(fullPath));

            RepositoryId = repositoryId;
            RepositoryRoot = repositoryRoot;
            LastChangedAuthor = lastChangedAuthor;
            Revision = revision;
            Uri = uri;
            Path = path;
            FullPath = fullPath;
            NodeKind = nodeKind;
        }

        /// <summary>
        /// Gets the UUID of the repository (if available). Otherwise Guid.Empty.
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
        /// Gets the kind of the subversion node.
        /// </summary>
        public SvnKind NodeKind { get; }
    }
}
