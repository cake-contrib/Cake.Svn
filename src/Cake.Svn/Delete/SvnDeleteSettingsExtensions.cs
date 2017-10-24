using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Delete
{
    internal static class SvnDeleteSettingsExtensions
    {
        internal static SvnDeleteArgs ToSvnDeleteArgs(this SvnDeleteSettings settings)
        {
            settings.NotNull(nameof(settings));

            return (new SvnDeleteArgs
            {
                KeepLocal = settings.KeepLocal,
                Force = settings.Force
            }).SetBaseSettings(settings);
        }
    }
}
