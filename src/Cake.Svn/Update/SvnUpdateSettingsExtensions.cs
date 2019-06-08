using Cake.Svn.Internal.Extensions;
using SharpSvn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn.Update
{
    internal static class SvnUpdateSettingsExtensions
    {
        internal static SvnUpdateArgs ToSvnUpdateArgs(this SvnUpdateSettings settings)
        {
            settings.NotNull(nameof(settings));

            return (new SvnUpdateArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                IgnoreExternals = settings.IgnoreExternals,
                AllowObstructions = settings.AllowObstructions,
                Revision = settings.SvnRevision,
                UpdateParents = settings.UpdateParents,
                KeepDepth = settings.KeepDepth,
                AddsAsModifications = settings.AddAsModifications
            }).SetBaseSettings(settings);
        }
    }
}
