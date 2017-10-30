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
        /// <example>
        /// <para>Export a SVN repository and output revision ID:</para>
        /// <code>
        /// <![CDATA[
        ///     var result = SvnExport(
        ///         new Uri("https://svn.example.com"),
        ///         @"c:\repo");
        ///
        ///     Verbose("Revision: {0}", result.Revision);
        /// ]]>
        /// </code>
        /// </example>
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
        /// Export a Subversion directory tree with specific settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="repositoryUrl">The URL of the Subversion repository.</param>
        /// <param name="path">The local directory name.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Result of the export operation.</returns>
        /// <example>
        /// <para>Export root files from a SVN repository while overwriting files in the target location and output revision ID:</para>
        /// <code>
        /// <![CDATA[
        ///     var settings =
        ///         new SvnExportSettings 
        ///         { 
        ///             Overwrite = true,
        ///             Depth = SvnDepth.Files 
        ///         };
        ///         
        ///     var result = SvnExport(
        ///         new Uri("https://svn.example.com"),
        ///         @"c:\repo",
        ///         settings);
        ///
        ///     Verbose("Revision: {0}", result.Revision);
        /// ]]>
        /// </code>
        /// </example>
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
