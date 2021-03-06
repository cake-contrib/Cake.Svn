﻿using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Info
{
    internal static class SvnInfoSettingsExtensions
    {
        internal static SvnInfoArgs ToSvnInfoArgs(this SvnInfoSettings settings)
        {
            settings.NotNull(nameof(settings));

            return (new SvnInfoArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                Revision = !settings.Revision.HasValue ? new SvnRevision() : 
                    (settings.Revision < 0 ? SvnRevision.Head : new SvnRevision(settings.Revision.Value)),
                IncludeExternals = settings.IncludeExternals,
                RetrieveActualOnly = settings.RetrieveActualOnly,
                RetrieveExcluded = settings.RetrieveExcluded
            }).SetBaseSettings(settings);
        }
    }
}
