namespace Cake.Svn.Vacuum
{
    /// <summary>
    /// Settings for <see cref="SvnVacuum"/>
    /// </summary>
    public sealed class SvnVacuumSettings : SvnSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether vacuum should also process externals
        /// defined by svn:externals properties.
        /// Defaulted to <c>false</c>.
        /// </summary>
        public bool IncludeExternals { get; set; } = false;
    }
}
