using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Export;
using Cake.Svn.Internal;


namespace Cake.Svn
{
    public static partial class SvnAliases
    {
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
