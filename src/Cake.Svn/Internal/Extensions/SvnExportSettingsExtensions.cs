using System;
using Cake.Svn.Export;

namespace Cake.Svn.Internal.Extensions
{
    internal static class SvnExportSettingsExtensions
    {
        internal static SharpSvn.SvnExportArgs ToSharpSvn(this SvnExportSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return new SharpSvn.SvnExportArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                IgnoreExternals = settings.IgnoreExternals,
                IgnoreKeywords = settings.IgnoreKeywords,
                LineStyle = settings.LineStyle.ToSharpSvn(),
                Overwrite = settings.Overwrite,
                Revision = settings.Revision < 0 ? SharpSvn.SvnRevision.Head : new SharpSvn.SvnRevision(settings.Revision),
            };
        }
    }
}
