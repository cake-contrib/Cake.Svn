using SharpSvn;

namespace Cake.Svn.Internal.Extensions
{
    internal static class SvnNodeKindExtensions
    {
        internal static SvnKind ToSvnKind(this SvnNodeKind nodeKind)
        {
            switch (nodeKind)
            {
                case SvnNodeKind.None:
                    return SvnKind.None;
                case SvnNodeKind.File:
                    return SvnKind.File;
                case SvnNodeKind.Directory:
                    return SvnKind.Directory;
                case SvnNodeKind.SymbolicLink:
                    return SvnKind.SymbolicLink;
                default:
                    return SvnKind.Unknown;
            }
        }
    }
}
