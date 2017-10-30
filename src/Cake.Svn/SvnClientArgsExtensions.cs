using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn
{
    internal static class SvnClientArgsExtensions
    {
        internal static T SetBaseSettings<T>(this T args, SvnSettings settings)
            where T : SvnClientArgs
        {
            args.NotNull(nameof(args));
            settings.NotNull(nameof(settings));

            args.ThrowOnCancel = settings.ThrowOnCancel;
            args.ThrowOnError = settings.ThrowOnError;
            args.ThrowOnWarning = settings.ThrowOnWarning;

            return args;
        }
    }
}
