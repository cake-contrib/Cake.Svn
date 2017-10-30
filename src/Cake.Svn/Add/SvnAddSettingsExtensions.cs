using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Add
{
    internal static class SvnAddSettingsExtensions
    {
        internal static SvnAddArgs ToSvnAddArgs(this SvnAddSettings settings)
        {
            settings.NotNull(nameof(settings));

            return (new SvnAddArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                AddParents = settings.AddParents,
                Force = settings.Force,
                NoAutoProps = !settings.AutoProperties,
                NoIgnore = !settings.Ignore
            }).SetBaseSettings(settings);
        }
    }
}
