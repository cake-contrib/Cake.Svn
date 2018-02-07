using System;
using Cake.Svn.Internal.Extensions;
using SharpSvn;

namespace Cake.Svn.Checkout
{
    internal static class SvnCheckoutSettingsExtensions
    {
        internal static SvnCheckOutArgs ToSharpSvn(this SvnCheckoutSettings settings)
        {
            settings.NotNull(nameof(settings));

            SvnRevision revision;

            if (settings.Revision == null )
            {
                revision = SvnRevision.Head;
            }
            else
            {
                revision = new SvnRevision((long)settings.Revision);
            }

            return (new SvnCheckOutArgs
            {
                Depth = settings.Depth.ToSharpSvn(),
                    IgnoreExternals = settings.IgnoreExternals,
                    AllowObstructions = settings.AllowObstructions,
                    Revision = revision
            }).SetBaseSettings(settings);
        }
    }
}