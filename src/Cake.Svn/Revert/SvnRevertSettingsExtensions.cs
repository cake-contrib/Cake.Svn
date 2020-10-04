using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Revert
{
    internal static class SvnRevertSettingsExtensions
    {
        internal static SvnRevertArgs ToSvnRevertArgs(this SvnRevertSettings settings)
        {
            settings.NotNull(nameof(settings));

            var args = new SvnRevertArgs
            {
                ClearChangelists = settings.ClearChangeLists,
                Depth = settings.Depth.ToSharpSvn(),
                MetaDataOnly = settings.MetaDataOnly
            };
            args.SetBaseSettings(settings);

            foreach(string changeList in settings.ChangeLists)
            {
                args.ChangeLists.Add(changeList);
            }

            return args;
        }
    }
}
