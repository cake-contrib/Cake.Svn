using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Export;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Export a Subversion directory tree.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="repositoryUrl">The URL of the Subversion repository.</param>
        /// <param name="path">The local directory name.</param>
        /// <returns>Result of the export operation.</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Export")]
        [CakeNamespaceImport("Cake.Svn.Export")]
        public static SvnExportResult SvnExport(
            this ICakeContext context,
            Uri repositoryUrl,
            DirectoryPath path
            )
        {
            return SvnExport(context, repositoryUrl, path, null);
        }

        /// <summary>
        /// Export a Subversion directory tree.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="repositoryUrl">The URL of the Subversion repository.</param>
        /// <param name="path">The local directory name.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Result of the export operation.</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Export")]
        [CakeNamespaceImport("Cake.Svn.Export")]
        public static SvnExportResult SvnExport(
            this ICakeContext context,
            Uri repositoryUrl,
            DirectoryPath path,
            SvnExportSettings settings
            )
        {
            var exporter = new SvnExporter(context.Environment, SvnClientFactoryMethod);

            return exporter.Export(repositoryUrl, path, settings ?? new SvnExportSettings());
        }
    }
}
