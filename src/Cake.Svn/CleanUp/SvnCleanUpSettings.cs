
namespace Cake.Svn.CleanUp
{
    /// <summary>
    /// Settings used for <see cref="SvnCleanUper"/>
    /// </summary>
    public sealed class SvnCleanUpSettings : SvnSettings
    {
        /// <summary>
        /// Initalizes a new insance of the <see cref="SvnCleanUpSettings"/> class.
        /// Everything is set to the same defaults that SharpSvn sets in its settings.
        /// </summary>
        public SvnCleanUpSettings()
        {
            this.BreakLocks = true;
            this.ClearDavCache = true;
            this.FixTimeStamps = true;
            this.IncludeExternals = false;
            this.VacuumPristines = true;
        }

        /// <summary>
        /// If set to <c>true</c>, this removes all write locks from the working copy.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool BreakLocks { get; set; }

        /// <summary>
        /// If set to <c>true</c>, cleanup clears the Dav Cache.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool ClearDavCache { get; set; }

        /// <summary>
        /// Fix timestamps.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool FixTimeStamps { get; set; }

        /// <summary>
        /// Also operate on externals defined by svn:externals properties.
        /// Defaulted to <c>false</c>.
        /// </summary>
        public bool IncludeExternals { get; set; }

        /// <summary>
        /// If set to <c>true</c>, this removes unreferenced pristines from the .svn directory.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool VacuumPristines { get; set; }
    }
}
