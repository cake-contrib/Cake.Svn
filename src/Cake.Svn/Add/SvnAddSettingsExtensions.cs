using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Add
{
    internal static class SvnAddSettingsExtensions
    {
        internal static SharpSvn.SvnAddArgs ToSvnAddArgs(this SvnAddSettings settings)
        {
            settings.NotNull(nameof(settings));

            return new SharpSvn.SvnAddArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                AddParents = settings.AddParents,
                Force = settings.Force,
                NoAutoProps = !settings.AutoProperties,
                NoIgnore = !settings.Ignore
            };
        }
    }
}
