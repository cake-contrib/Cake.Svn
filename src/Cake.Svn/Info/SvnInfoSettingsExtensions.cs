using System;
using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Info
{
    internal static class SvnInfoSettingsExtensions
    {
        internal static SvnInfoArgs ToSvnInfoArgs(this SvnInfoSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return new SvnInfoArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                Revision = settings.Revision < 0 ? SvnRevision.Head : new SvnRevision(settings.Revision),
                IncludeExternals = settings.IncludeExternals,
                RetrieveActualOnly = settings.RetrieveActualOnly,
                RetrieveExcluded = settings.RetrieveExcluded
            };
        }
    }
}
