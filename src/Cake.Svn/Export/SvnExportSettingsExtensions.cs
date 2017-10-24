using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Export
{
    internal static class SvnExportSettingsExtensions
    {
        internal static SvnExportArgs ToSharpSvn(this SvnExportSettings settings)
        {
            settings.NotNull(nameof(settings));

            return (new SvnExportArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                IgnoreExternals = settings.IgnoreExternals,
                IgnoreKeywords = settings.IgnoreKeywords,
                LineStyle = settings.LineStyle.ToSharpSvn(),
                Overwrite = settings.Overwrite,
                Revision = settings.Revision < 0 ? SvnRevision.Head : new SvnRevision(settings.Revision)
            }).SetBaseSettings(settings);
        }
    }
}
