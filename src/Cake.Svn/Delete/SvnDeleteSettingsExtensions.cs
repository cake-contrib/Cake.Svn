using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Delete
{
    internal static class SvnDeleteSettingsExtensions
    {
        internal static SharpSvn.SvnDeleteArgs ToSvnDeleteArgs(this SvnDeleteSettings settings)
        {
            settings.NotNull(nameof(settings));

            return new SharpSvn.SvnDeleteArgs
            {
                KeepLocal = settings.KeepLocal,
                Force = settings.Force
            };
        }
    }
}
