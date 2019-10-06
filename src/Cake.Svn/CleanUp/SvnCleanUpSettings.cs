namespace Cake.Svn.CleanUp
{
    /// <summary>
    /// Settings used for <see cref="SvnCleaner"/>
    /// </summary>
    public sealed class SvnCleanUpSettings : SvnSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether write locks should be removed
        /// from the working copy.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool BreakLocks { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Dav Cache should be cleared.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool ClearDavCache { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether timestamps should be fixed.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool FixTimeStamps { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether cleanup should also process externals
        /// defined by svn:externals properties.
        /// Defaulted to <c>false</c>.
        /// </summary>
        public bool IncludeExternals { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether unreferenced pristines should be removed from the .svn directory.
        /// Defaulted to <c>true</c>.
        /// </summary>
        public bool VacuumPristines { get; set; } = true;
    }
}