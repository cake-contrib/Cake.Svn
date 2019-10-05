using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.CleanUp
{
    internal static class SvnCleanUpSettingsExtensions
    {
        internal static SvnCleanUpArgs ToSvnCleanUpArgs( this SvnCleanUpSettings settings )
        {
            settings.NotNull( nameof( settings ) );

            return ( new SvnCleanUpArgs
            {
                BreakLocks = settings.BreakLocks,
                ClearDavCache = settings.ClearDavCache,
                FixTimestamps = settings.FixTimeStamps,
                IncludeExternals = settings.IncludeExternals,
                VacuumPristines = settings.VacuumPristines
            }
            ).SetBaseSettings( settings );
        }
    }
}
