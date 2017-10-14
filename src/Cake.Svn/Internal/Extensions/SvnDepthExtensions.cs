namespace Cake.Svn.Internal.Extensions
{
    internal static class SvnDepthExtensions
    {
        internal static SharpSvn.SvnDepth ToSharpSvn(this SvnDepth depth)
        {
            switch (depth)
            {
                case SvnDepth.Empty:
                    return SharpSvn.SvnDepth.Empty;
                case SvnDepth.Files:
                    return SharpSvn.SvnDepth.Files;
                case SvnDepth.Immediates:
                    return SharpSvn.SvnDepth.Children;
                case SvnDepth.Infinity:
                    return SharpSvn.SvnDepth.Infinity;
                default:
                    return SharpSvn.SvnDepth.Unknown;
            }
        }
    }
}
