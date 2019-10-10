using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Status
{
    internal static class SvnStatusSettingsExtensions
    {
        internal static SvnStatusArgs ToSvnStatusArgs(this SvnStatusSettings settings)
        {
            settings.NotNull(nameof(settings));

            return (new SvnStatusArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                Revision = !settings.Revision.HasValue ? new SvnRevision() :
                    (settings.Revision < 0 ? SvnRevision.Head : new SvnRevision(settings.Revision.Value)),
                IgnoreExternals = settings.IgnoreExternals,
                IgnoreWorkingCopyStatus = settings.IgnoreWorkingCopyStatus,
                KeepDepth = settings.KeepDepth,
                RetrieveAllEntries = settings.RetrieveAllEntries,
                RetrieveIgnoredEntries = settings.RetrieveIgnoredEntries,
                RetrieveRemoteStatus = settings.RetrieveRemoteStatus
            }).SetBaseSettings(settings);
        }
    }
}
