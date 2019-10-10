using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Vacuum
{
    internal static class SvnVacuumSettingsExtensions
    {
        internal static SvnVacuumArgs ToSvnVacuumArgs(this SvnVacuumSettings settings)
        {
            settings.NotNull(nameof(settings));

            return (new SvnVacuumArgs
            {
                IncludeExternals = settings.IncludeExternals
            }
            ).SetBaseSettings(settings);
        }
    }
}
