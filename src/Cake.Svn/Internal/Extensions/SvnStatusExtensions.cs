namespace Cake.Svn.Internal.Extensions
{
    internal static class SvnStatusExtensions
    {
        internal static SvnStatus ToSvnStatus(this SharpSvn.SvnStatus svnStatus)
        {
            switch (svnStatus)
            {
                case SharpSvn.SvnStatus.None:
                    return SvnStatus.None;
                case SharpSvn.SvnStatus.NotVersioned:
                    return SvnStatus.NotVersioned;
                case SharpSvn.SvnStatus.Normal:
                    return SvnStatus.Normal;
                case SharpSvn.SvnStatus.Added:
                    return SvnStatus.Added;
                case SharpSvn.SvnStatus.Missing:
                    return SvnStatus.Missing;
                case SharpSvn.SvnStatus.Deleted:
                    return SvnStatus.Deleted;
                case SharpSvn.SvnStatus.Replaced:
                    return SvnStatus.Replaced;
                case SharpSvn.SvnStatus.Modified:
                    return SvnStatus.Modified;
                case SharpSvn.SvnStatus.Merged:
                    return SvnStatus.Merged;
                case SharpSvn.SvnStatus.Conflicted:
                    return SvnStatus.Conflicted;
                case SharpSvn.SvnStatus.Ignored:
                    return SvnStatus.Ignored;
                case SharpSvn.SvnStatus.Obstructed:
                    return SvnStatus.Obstructed;
                case SharpSvn.SvnStatus.External:
                    return SvnStatus.External;
                case SharpSvn.SvnStatus.Incomplete:
                    return SvnStatus.Incomplete;
                default:
                    return SvnStatus.Zero;
            }
        }
    }
}
